using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreobrCalc
{
    public partial class ChartProvider : Form
    {
        const byte FILTER = 0;
        const byte BEFORE = 1;
        const byte AFTER = 2;

        List<Point> Before;
        List<Point> After;
        Thread Thrd;

        private void AddChart(Chart c)
        {
            this.Controls.Add(c);
        }

        private void Draw2ListPointsThread()
        {
            Chart myChart = new Chart()
            {
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 24)
            };

            myChart.Legends.Add(new Legend());
            myChart.ChartAreas.Add(new ChartArea());
            myChart.ChartAreas.Last().CursorX.IsUserEnabled = true;
            myChart.ChartAreas.Last().CursorX.IsUserSelectionEnabled = true;
            myChart.ChartAreas.Last().CursorY.IsUserEnabled = true;
            myChart.ChartAreas.Last().CursorY.IsUserSelectionEnabled = true;
            myChart.ChartAreas.Last().AxisX.Title = "F, МГц";
            myChart.ChartAreas.Last().AxisY.Title = "s, dB";
            myChart.Series.Add("Filter");
            myChart.Series.Add("Before");
            myChart.Series.Add("After");

            myChart.Series[0].BorderWidth = 2;
            myChart.Series[1].BorderWidth = 2;
            myChart.Series[2].BorderWidth = 2;

            myChart.Series[0].BorderDashStyle = ChartDashStyle.Dash;
            myChart.Series[0].Color = Color.Black;

            myChart.Series[0].ChartType = SeriesChartType.Point;
            myChart.Series[1].ChartType = SeriesChartType.Point;
            myChart.Series[2].ChartType = SeriesChartType.Point;

            myChart.Series[1].MarkerColor = Color.Red;
            myChart.Series[2].MarkerColor = Color.Green;

            myChart.Series[1].MarkerSize = 10;
            myChart.Series[2].MarkerSize = 10;

            myChart.Series[1].MarkerStyle = MarkerStyle.Square;
            myChart.Series[2].MarkerStyle = MarkerStyle.Square;

            for (int i = 0; i < Before.Count; i++)
            {
                myChart.Series[BEFORE].Points.AddXY(Before[i].Freq, Before[i].Att);
            }
            for (int i = 0; i < After.Count; i++)
            {
                myChart.Series[AFTER].Points.AddXY(After[i].Freq, After[i].Att);
            }
            myChart.Series[FILTER].IsVisibleInLegend = false;

            myChart.Click += chart1_Click;
            Invoke(new Action<Chart>(AddChart), myChart);
        }

        public ChartProvider()
        {
            InitializeComponent();
        }

        public ChartProvider(List<Point> before, List<Point> after)
        {
            InitializeComponent();
            Before = before;
            After = after;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (Controls[i] == chart1)
                {
                    Controls.RemoveAt(i);
                    break;
                }
            }
            Thrd = new Thread(new ThreadStart(Draw2ListPointsThread));
            Thrd.Start();
        }

        public ChartProvider(List<Point> points)
        {
            InitializeComponent();
            foreach (var item in points)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
            chart1.Series[AFTER].LegendText = "Source";
            chart1.Series[BEFORE].IsVisibleInLegend = false;
            chart1.Series[FILTER].IsVisibleInLegend = false;
        }

        public ChartProvider(List<Point> before, List<Point> after, Filter filt, int FiltMult)
        {
            InitializeComponent();
            foreach (var item in before)
            {
                chart1.Series[BEFORE].Points.AddXY(item.Freq, item.Att);
            }
            foreach (var item in after)
            {
                chart1.Series[AFTER].Points.AddXY(item.Freq, item.Att);
            }
            foreach (var item in filt.Points)
            {
                chart1.Series[FILTER].Points.AddXY(item.Freq, item.Att * FiltMult);
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
            Text = ((Chart)sender).ChartAreas[0].CursorX.Position.ToString() + " MHz, " + ((Chart)sender).ChartAreas[0].CursorY.Position.ToString() + " dBm";
        }
    }
}
