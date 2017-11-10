using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreobrCalc
{
    public interface IBlock
    {
        bool Ready();
        void Check();
        Type GetType();
        void Apply(List<Point> in_p, List<Point> out_p);
    }

    public class BFilter : IBlock
    {
        Filter filt;
        int multiplier = 1;

        public Filter Filter { get => filt; }

        bool isInit = false;

        public bool IsInitialized { get; }
        public int Multiplier { get => multiplier; set => multiplier = value; }

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

        public bool Ready()
        {
            return isInit;
        }

        public bool Setup(Filter filt)
        {
            if (filt == null) return false;
            this.filt = filt;
            isInit = true;
            return isInit;
        }

        public void Check()
        {
            if (filt == null) return;
            isInit = true;
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {
            foreach (var item in in_p)
            {
                for (int i = 0; i < filt.Points.Count - 1; i++)
                {
                    if (filt.Points[i].Freq <= item.Freq && item.Freq <= filt.Points[i + 1].Freq)
                    {
                        double att = filt.Apply(item.Freq, item.Att, multiplier);
                        if (att > Properties.Settings.Default.LowerLimit)
                        {
                            out_p.Add(new Point(item.Freq, att));
                        }
                        break;
                    }
                    else if (item.Freq >= filt.Points.Last().Freq)
                    {
                        double att = item.Att + filt.Points.Last().Att * multiplier;
                        if (att > Properties.Settings.Default.LowerLimit)
                        {
                            out_p.Add(new Point(item.Freq, att));
                        }
                        break;
                    }
                }
            }
        }
    }

    public class BAttenuator : IBlock
    {
        double att = 0;
        bool isInit = false;

        public bool IsInitialized { get; }
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

        public bool Ready()
        {
            return isInit;
        }

        public bool Setup(double att = 0)
        {
            this.att = att;

            isInit = true;
            return isInit;
        }

        public void Check()
        {
            isInit = true;
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {
            foreach (var item in in_p)
            {
                if (item.Att + att > Properties.Settings.Default.LowerLimit)
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

        bool isInit = false;

        public double Freq { get => freq; set => freq = value; }
        public double Band { get => band; set => band = value; }
        public double Step { get => step; set => step = value; }
        public double Att { get => att; set => att = value; }
        public bool IsInitialized { get => isInit; }

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

        public bool Ready()
        {
            return isInit;
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {

        }

        public bool Setup(double freq, double step = 1, double band = 0, double att = 0)
        {
            if (freq <= 0) return false;
            this.freq = freq;

            if (band < 0 || ((freq - band / 2) <= 0)) return false;
            this.band = band;

            if (band <= 0 && (step <= 0 || step > band)) return false;
            this.step = step;

            this.att = att;

            isInit = true;
            return isInit;
        }

        public void Check()
        {
            if (freq <= 0) return;
            if (band < 0)
            {
                return;
            }
            else if (band > 0)
            {
                if ((freq - band / 2) <= 0)
                    return;
                if (step <= 0 || step > band)
                    return;
            }
            isInit = true;
        }

        public void Generate(List<Point> p)
        {
            if (band == 0)
            {
                p.Add(new Point(freq, att));
            }
            else
            {
                int steps = (int)(band / step) + 1;
                for (int i = 0; i < steps; i++)
                {
                    p.Add(new Point((freq - band / 2) + i * step, att));
                }
            }
        }
    }

    public class BMixer : IBlock
    {
        int order = 3;
        bool finBelowFget = false;
        double fget = 0;
        bool isInit = false;
        double fprch = 0;

        public bool IsInitialized { get; }
        public double Fget { get => fget; set => fget = value; }
        public bool FinBelowFget { get => finBelowFget; set => finBelowFget = value; }
        public int Order { get => order; set => order = value; }
        public double Fprch { get => fprch; set => fprch = value; }

        int[,] mix = {
            {   0, -35, -30, -45, -55, -60},
            { -20,   0, -20, -10, -25, -20},
            { -50, -55, -50, -50, -50, -50},
            { -45, -50, -70, -55, -70, -60},
            { -70, -80, -95, -95,-100, -90},
            { -90,-100,-100, -90,-110, -95}
        };

        public BMixer()
        {

        }

        public new Type GetType()
        {
            return typeof(BMixer);
        }

        public bool Ready()
        {
            return isInit;
        }

        public bool Setup(double Fget, int Order = 3, bool FinBelowFget = false)
        {
            if (Order < 3 || Order > 5) return false;
            order = Order;
            finBelowFget = FinBelowFget;
            if (Fget <= 0 || Fget >= 50000) return false;
            fget = Fget;
            isInit = true;
            return isInit;
        }

        public void Check()
        {
            if (Order < 3 || Order > 5) return;
            if (Fget <= 0 || Fget >= 100000) return;
            isInit = true;
        }

        public void Apply(List<Point> in_p, List<Point> out_p)
        {
            int a = 0, b = 0; //black magic
            foreach (var item in in_p)
            {
                for (int n = 0; n < order + 1; n++)
                {
                    for (int m = 0; m < order + 1; m++)
                    {
                        double att = item.Att + mix[m, n];
                        if (att > Properties.Settings.Default.LowerLimit)
                        {
                            double var1 = Math.Abs(n * fget - m * item.Freq), var2 = Math.Abs(n * fget + m * item.Freq) /*, var3 = (m * item.Freq - n * fget), var4 = ((-1 * n) * fget - m * item.Freq)*/;
                            if (var1 > 0)
                            {
                                out_p.Add(new Point(var1, att));
                                a++;
                            }
                            if (var2 > 0)
                            {
                                out_p.Add(new Point(var2, att));
                                b++;
                            }
                        }
                    }
                }
            }
        }
    }
}
