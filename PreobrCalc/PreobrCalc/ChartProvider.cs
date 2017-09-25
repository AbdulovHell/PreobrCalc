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

        public ChartProvider(List<Point> before, List<Point> after)
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

        public ChartProvider(List<Point> points)
        {
            InitializeComponent();
            foreach (var item in points)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
            chart1.Series[0].LegendText = "Source";
            chart1.Series[1].IsVisibleInLegend = false;
        }

        public ChartProvider(List<Point> before, List<Point> after, Filter filt)
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

        private void SaveChartMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (e.Cancel) return;
            switch (saveFileDialog1.FilterIndex)
            {
                case 1:
                    chart1.SaveImage(saveFileDialog1.FileNames[0], System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case 2:
                    chart1.SaveImage(saveFileDialog1.FileNames[0], System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case 3:
                    chart1.SaveImage(saveFileDialog1.FileNames[0], System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                default:
                    return;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            Text = chart1.ChartAreas[0].CursorX.Position.ToString() + " MHz, " + chart1.ChartAreas[0].CursorY.Position.ToString() + " dBm";
        }
    }
}
