using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreobrCalc
{
    class Filter
    {
        private List<Point> points;
        private string _name;
        private bool _isTunable;
        private double _cntrFreq;
        private double _band;

        public string Name { get => _name; set => _name = value; }
        public bool IsTunable { get => _isTunable; set => _isTunable = value; }
        public double CenterFreq { get => _cntrFreq; set => _cntrFreq = value; }
        public double Band { get => _band; set => _band = value; }
        internal List<Point> Points { get => points; set => points = value; }

        public class Point
        {
            private double _freq;
            private double _att;

            public double Freq { get => _freq; set => _freq = value; }
            public double Att { get => _att; set => _att = value; }

            public Point(double freq, double att)
            {
                _freq = freq;
                _att = att;
            }
        }

        public Filter()
        {
            Points = new List<Point>();
            _name = "Default";
            _isTunable = false;
            _cntrFreq = 0;
            _band = 0;
        }

        public double Apply(double Freq, double att)
        {
            double newAtt = att;
            if (Freq == Points[0].Freq)
            {
                newAtt += Points[0].Att;
                return newAtt;
            }
            for (int i = 0; i < Points.Count - 1; i++)
            {
                if (Points[i].Freq < Freq && Points[i + 1].Freq >= Freq)
                {
                    newAtt += GetAtt(Freq, Points[i], Points[i + 1]);
                    break;
                }
            }
            return newAtt;
        }

        static double GetAtt(double Freq, Point L, Point R)
        {
            double att = 0;
            att = ((R.Att - L.Att) * (Freq - L.Freq)) / (R.Freq - L.Freq) + L.Att;
            return att;
        }

        public static Filter operator +(Filter filt1, Filter filt2)
        {
            Filter NewFilt = new Filter();
            double tempAtt = 0;
            Filter.Point last1=filt1.Points[0], last2=filt2.Points[0];
            //filt1.Points.Add(new Point(100000, filt1.Points[filt1.Points.Count - 1].Att));
            //filt2.Points.Add(new Point(100000, filt2.Points[filt2.Points.Count - 1].Att));
            while (filt1.Points.Count > 0 || filt2.Points.Count > 0)
            {
                tempAtt = 0;

                if (filt1.Points.Count == 0)
                {
                    for(int i = 0; i < filt2.Points.Count; i++)
                    {
                        NewFilt.Points.Add(new Filter.Point(filt2.Points[i].Freq, filt2.Points[i].Att+last1.Att));
                    }
                    break;
                }
                if (filt2.Points.Count == 0)
                {
                    for (int i = 0; i < filt1.Points.Count; i++)
                    {
                        NewFilt.Points.Add(new Filter.Point(filt1.Points[i].Freq, filt1.Points[i].Att + last2.Att));
                    }
                    break;
                }

                if (filt1.Points[0].Freq < filt2.Points[0].Freq)
                {
                    //if (filt2.Points.Count < 2)
                        tempAtt = GetAtt(filt1.Points[0].Freq, last2, filt2.Points[0]);
                    //else
                    //    tempAtt = GetAtt(filt1.Points[0].Freq, last2, filt2.Points[1]);
                    NewFilt.Points.Add(new Point(filt1.Points[0].Freq, filt1.Points[0].Att + tempAtt));
                    last1 = filt1.Points[0];
                    filt1.Points.RemoveAt(0);
                }
                else if (filt1.Points[0].Freq > filt2.Points[0].Freq)
                {
                    //if (filt1.Points.Count < 2)
                        tempAtt = GetAtt(filt2.Points[0].Freq, last1, filt1.Points[0]);
                    //else
                    //    tempAtt = GetAtt(filt2.Points[0].Freq, filt1.Points[0], filt1.Points[1]);
                    NewFilt.Points.Add(new Point(filt2.Points[0].Freq, filt2.Points[0].Att + tempAtt));
                    last2 = filt2.Points[0];
                    filt2.Points.RemoveAt(0);
                }
                else if (filt1.Points[0].Freq == filt2.Points[0].Freq)
                {
                    NewFilt.Points.Add(new Point(filt1.Points[0].Freq, filt1.Points[0].Att + filt2.Points[0].Att));
                    last1 = filt1.Points[0];
                    last2 = filt2.Points[0];
                    filt1.Points.RemoveAt(0);
                    filt2.Points.RemoveAt(0);
                }
                else
                {
                    throw (new Exception("Filter class error: operator+"));
                }
            }
            return NewFilt;
        }
    }
}
