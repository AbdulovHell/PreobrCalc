using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreobrCalc
{
    interface IBlock
    {
        Type GetType();
        void Apply(List<Point> in_p, List<Point> out_p);
    }

    public class BFilter : IBlock
    {
        Filter filt;

        public Filter Filter { set => filt = value; }

        public BFilter()
        {

        }

        public BFilter(Filter filter)
        {
            filt = filter;
        }

        public new Type GetType()
        {
            return typeof(BFilter);
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {
            foreach (var item in in_p)
            {
                for (int i = 0; i < filt.Points.Count - 1; i++)
                {
                    if (filt.Points[i].Freq <= item.Freq && item.Freq <= filt.Points[i + 1].Freq)
                    {
                        out_p.Add(new Point(item.Freq, filt.Apply(item.Freq, item.Att)));
                    }
                }
            }
        }
    }

    public class BAttenuator : IBlock
    {
        int att = 0;

        public int Att { set => att = value; }

        public BAttenuator()
        {

        }

        public BAttenuator(int att)
        {
            this.att = att;
        }

        public new Type GetType()
        {
            return typeof(BAttenuator);
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {
            foreach (var item in in_p)
            {
                out_p.Add(new Point(item.Freq,item.Att + att));
            }
        }
    }

    public class BSource : IBlock
    {
        double freq = 0;
        double band = 0;
        double step = 0;
        double att = 0;

        public BSource()
        {

        }

        public BSource(double freq, double att = 0)
        {
            this.freq = freq;
            this.att = att;
        }

        public BSource(double freq, double step, double band, double att = 0)
        {
            this.freq = freq;
            this.step = step;
            this.band = band;
            this.att = att;
        }

        public double Freq { set => freq = value; }
        public double Band { set => band = value; }
        public double Step { set => step = value; }
        public double Att { set => att = value; }

        public new Type GetType()
        {
            return typeof(BSource);
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {

        }

        public void Generate(List<Point> p)
        {
            if (band == 0)
            {
                p.Add(new Point(freq, att));
            }
            else
            {
                for (double i = freq - band / 2; i <= freq + band / 2; i += step)
                {
                    p.Add(new Point(i, att));
                }
            }
        }
    }
}
