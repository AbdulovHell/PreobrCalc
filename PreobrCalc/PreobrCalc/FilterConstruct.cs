using System;
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
        enum LoadAction
        {
            NOPE,
            MULT,
            OVER
        };

        LoadAction LdAct = LoadAction.NOPE;

        public FilterConstruct()
        {
            InitializeComponent();

            foreach (var item in Form1.Filters)
            {
                FiltersList.Items.Add(item.Name);
            }
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

            //chart1.Series[2].Points.AddXY(3000, temp.Apply(3000, 0));
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                FilterPointGrid.Rows.Insert(e.RowIndex, 1);
            else if (e.Button == MouseButtons.Left)
                FilterPointGrid.Rows.RemoveAt(e.RowIndex);
        }

        private void FilterPointGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].LegendText = FiltNameEdit.Text;
            chart1.Series[1].IsVisibleInLegend = false;
            chart1.Series[2].IsVisibleInLegend = false;
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
            foreach (Point item in filt.Points)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
        }

        private void SaveToFileBtn_Click(object sender, EventArgs e)
        {
            SaveBaseDialog.ShowDialog();
        }

        private void FiltersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter temp = Form1.Filters[FiltersList.SelectedIndex];
            chart1.Series[0].Points.Clear();
            chart1.Series[0].LegendText = temp.Name;
            chart1.Series[1].IsVisibleInLegend = false;
            chart1.Series[2].IsVisibleInLegend = false;
            foreach (var item in temp.Points)
            {
                chart1.Series[0].Points.AddXY(item.Freq, item.Att);
            }
        }

        private void SaveBaseDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (e.Cancel) return;
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

            using (var output = File.Create(SaveBaseDialog.FileNames[0]))
            {
                fBase.WriteTo(output);
            }
        }

        private void LoadBaseAndOverride_Click(object sender, EventArgs e)
        {
            LdAct = LoadAction.OVER;
            LoadBaseDialog.ShowDialog();
        }

        private void LoadBaseAndSum_Click(object sender, EventArgs e)
        {
            LdAct = LoadAction.MULT;
            LoadBaseDialog.ShowDialog();
        }

        private void LoadBaseDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (e.Cancel) return;
            switch (LdAct)
            {
                case LoadAction.MULT:
                    {
                        FiltersBase.FiltersBase fBase;
                        try
                        {
                            using (var input = File.OpenRead(LoadBaseDialog.FileNames[0]))
                            {
                                fBase = FiltersBase.FiltersBase.Parser.ParseFrom(input);
                                if (fBase.Filters.Count < 1) return;
                                foreach (var item in fBase.Filters)
                                {
                                    Filter temp = new Filter()
                                    {
                                        Band = item.Band,
                                        CenterFreq = item.CenterFreq,
                                        IsTunable = item.IsTunable,
                                        Name = item.Name
                                    };
                                    foreach (var point in item.Points)
                                    {
                                        temp.Points.Add(new Point(point.Freq, point.Att));
                                    }
                                    Form1.Filters.Add(temp);
                                }
                            }
                        }
                        catch (IOException exception)
                        {
                            MessageBox.Show(exception.ToString());
                        }
                        LdAct = LoadAction.NOPE;
                    }
                    break;
                case LoadAction.OVER:
                    {
                        Form1.Filters.Clear();
                        FiltersBase.FiltersBase fBase;
                        try
                        {
                            using (var input = File.OpenRead(LoadBaseDialog.FileNames[0]))
                            {
                                fBase = FiltersBase.FiltersBase.Parser.ParseFrom(input);
                                if (fBase.Filters.Count < 1) return;
                                foreach (var item in fBase.Filters)
                                {
                                    Filter temp = new Filter()
                                    {
                                        Band = item.Band,
                                        CenterFreq = item.CenterFreq,
                                        IsTunable = item.IsTunable,
                                        Name = item.Name
                                    };
                                    foreach (var point in item.Points)
                                    {
                                        temp.Points.Add(new Point(point.Freq, point.Att));
                                    }
                                    Form1.Filters.Add(temp);
                                }
                            }
                        }
                        catch (IOException exception)
                        {
                            MessageBox.Show(exception.ToString());
                        }

                        LdAct = LoadAction.NOPE;
                    }
                    break;
                case LoadAction.NOPE:
                default:
                    break;
            }
        }

        private void SaveFiltBtn_Click(object sender, EventArgs e)
        {
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
            filt.Name = FiltNameEdit.Text;

            Form1.Filters.Add(filt);

            FiltersList.Items.Clear();
            foreach (var item in Form1.Filters)
            {
                FiltersList.Items.Add(item.Name);
            }
        }

        private void DeleteFilterBtn_Click(object sender, EventArgs e)
        {
            int index = FiltersList.SelectedIndex;
            if (index < 0 || index > Form1.Filters.Count - 1) return;
            Form1.Filters.RemoveAt(index);

            FiltersList.Items.Clear();
            foreach (var item in Form1.Filters)
            {
                FiltersList.Items.Add(item.Name);
            }
        }

        private void ClearPointsTableBtn_Click(object sender, EventArgs e)
        {
            FiltNameEdit.Text = "";
            FilterPointGrid.Rows.Clear();
        }
    }
}
