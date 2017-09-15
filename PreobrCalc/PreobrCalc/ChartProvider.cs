using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreobrCalc
{
    public partial class ChartProvider : Form
    {
        public ChartProvider()
        {
            InitializeComponent();
        }

        public ChartProvider(List<Point> before,List<Point> after)
        {
            InitializeComponent();
            foreach (var item in before)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
            foreach (var item in after)
            {
                chart1.Series[1].Points.AddXY(item.Freq, item.Att);
            }
        }
        public ChartProvider(List<Point> before, List<Point> after,Filter filt)
        {
            InitializeComponent();
            foreach (var item in before)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
            foreach (var item in after)
            {
                chart1.Series[1].Points.AddXY(item.Freq, item.Att);
            }
            foreach (var item in filt.Points)
            {
                chart1.Series[2].Points.AddXY(item.Freq, item.Att);
            }
        }
    }
}
