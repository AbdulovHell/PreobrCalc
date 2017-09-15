using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreobrCalc
{
    public interface IBlock
    {
        Type GetType();
        void Apply(List<Point> in_p, List<Point> out_p);
    }

    public class BFilter : IBlock
    {
        Filter filt;

        public Filter Filter { get => filt; set => filt = value; }

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
        double att = 0;

        public double Att { get => att; set => att = value; }

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
                out_p.Add(new Point(item.Freq, item.Att + att));
            }
        }
    }

    public class BSource : IBlock
    {
        double freq = 0;
        double band = 0;
        double step = 0;
        double att = 0;

        public double Freq { get => freq; set => freq = value; }
        public double Band { get => band; set => band = value; }
        public double Step { get => step; set => step = value; }
        public double Att { get => att; set => att = value; }

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

    public class BMixer : IBlock
    {
        int order = 3;
        bool finBelowFget = false;
        double fget = 0;

        int[,] mix = {
            {   0, -35, -30, -45, -55, -60},
            { -20,   0, -20, -10, -25, -20},
            { -50, -55, -50, -50, -50, -50},
            { -45, -50, -70, -55, -70, -60},
            { -70, -80, -95, -95,-100, -90},
            { -90,-100,-100, -90,-110, -95}
        };

        public int Order { get => order; set => order = value; }
        public bool FinBelowFget { get => finBelowFget; set => finBelowFget = value; }
        public double Fget { get => fget; set => fget = value; }

        BMixer()
        {

        }

        public new Type GetType()
        {
            return typeof(BMixer);
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {
            foreach (var item in in_p)
            {
                for (int n = 0; n < order + 1; n++)
                {
                    for (int m = 0; m < order + 1; m++)
                    {
                        double var1 = (n * fget - m * item.Freq), var2 = (n * fget + m * item.Freq), var3 = (m * item.Freq - n * fget), var4 = ((-1 * n) * fget - m * item.Freq);
                        if (var1 > 0)
                        {
                            out_p.Add(new Point(var1, item.Att + mix[m, n]));
                        }
                        if (var2 > 0)
                        {
                            out_p.Add(new Point(var2, item.Att + mix[m, n]));
                        }
                        if (var3 > 0)
                        {
                            out_p.Add(new Point(var3, item.Att + mix[m, n]));
                        }
                        if (var4 > 0)
                        {
                            out_p.Add(new Point(var4, item.Att + mix[m, n]));
                        }
                    }
                }
            }
        }
    }
}
