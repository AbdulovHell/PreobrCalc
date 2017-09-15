﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Google.Protobuf;

namespace PreobrCalc
{
    public partial class FilterConstruct : Form
    {
        public FilterConstruct()
        {
            InitializeComponent();

            foreach (var item in Form1.Filters)
            {
                FiltersList.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Filter filt = new Filter();
            double tempFreq = 0, tempAtt = 0;
            foreach (DataGridViewRow item in FilterPointGrid.Rows)
            {
                if (item.Cells[0].Value == null || item.Cells[1].Value == null) continue;
                if (!Input.TryParse(item.Cells[0].Value.ToString(), out tempFreq))
                    continue;
                if (!Input.TryParse(item.Cells[1].Value.ToString(), out tempAtt))
                    continue;
                filt.Points.Add(new Point(tempFreq, tempAtt));
            }

            if (sender == button1) Form1.Filters.Add(filt);
            foreach (Point item in filt.Points)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();

            Filter filt = new Filter();
            double tempFreq = 0, tempAtt = 0;
            foreach (DataGridViewRow item in FilterPointGrid.Rows)
            {
                if (item.Cells[0].Value == null || item.Cells[1].Value == null) continue;
                if (!Input.TryParse(item.Cells[0].Value.ToString(), out tempFreq))
                    continue;
                if (!Input.TryParse(item.Cells[1].Value.ToString(), out tempAtt))
                    continue;
                filt.Points.Add(new Point(tempFreq, tempAtt));
            }

            if (filt.Points.Count < 2) return;

            Filter filt2 = new Filter();
            filt2.Points.Add(new Point(1, -100));
            filt2.Points.Add(new Point(690, -52));
            filt2.Points.Add(new Point(930, -36));
            filt2.Points.Add(new Point(1150, -18));
            filt2.Points.Add(new Point(1230, -10));
            filt2.Points.Add(new Point(1300, 0));
            filt2.Points.Add(new Point(1400, 0));
            filt2.Points.Add(new Point(1510, 0));
            filt2.Points.Add(new Point(3000, -10));
            filt2.Points.Add(new Point(4000, -24));
            filt2.Points.Add(new Point(5000, -52));
            filt2.Points.Add(new Point(5100, -54));
            filt2.Points.Add(new Point(5500, -48));
            filt2.Points.Add(new Point(70000, -45));

            Filter temp = filt + filt2;

            foreach (Point item in temp.Points)
            {
                chart1.Series[1].Points.AddXY(item.Freq, item.Att);
            }

            chart1.Series[2].Points.AddXY(3000, temp.Apply(3000, 0));
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                FilterPointGrid.Rows.Insert(e.RowIndex, 1);
            else if (e.Button == MouseButtons.Left)
                FilterPointGrid.Rows.RemoveAt(e.RowIndex);
        }

        private void FilterPointGrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void FilterPointGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            button1_Click(sender, e);
        }

        private void SaveToFileBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            FiltersBase.FiltersBase fBase = new FiltersBase.FiltersBase();
            foreach (var item in Form1.Filters)
            {
                FiltersBase.Filter tempf = new FiltersBase.Filter()
                {
                    Band = item.Band,
                    CenterFreq = item.CenterFreq,
                    IsTunable = item.IsTunable,
                    Name = item.Name
                };
                foreach (var item2 in item.Points)
                {
                    FiltersBase.Point p = new FiltersBase.Point()
                    {
                        Att = item2.Att,
                        Freq = item2.Freq
                    };
                    tempf.Points.Add(p);
                }

                fBase.Filters.Add(tempf);
            }

            using (var output = File.Create("filters.dat"))
            {
                fBase.WriteTo(output);
            }
        }

        private void FiltersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter temp=(Filter)FiltersList.SelectedItem;
            chart1.Series[0].Points.Clear();
            foreach (var item in temp.Points)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
        }
    }
}
