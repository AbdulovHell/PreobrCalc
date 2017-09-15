using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreobrCalc
{
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
}
