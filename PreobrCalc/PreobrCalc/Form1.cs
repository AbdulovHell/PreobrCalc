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

namespace PreobrCalc
{
    public partial class Form1 : Form
    {
        private static List<Filter> _filters;
        private Rectangle DragBoxFromMouseDown;
        private object TempObject;
        private System.Drawing.Point ScreenOffset;
        //private List<IBlock> Blocks;
        private List<List<Point>> calcResults;

        public Form1()
        {
            InitializeComponent();
            _filters = new List<Filter>();
            //Blocks = new List<IBlock>();
            calcResults = new List<List<Point>>();
            _filters.Clear();
        }

        public static List<Filter> Filters { get => _filters; set => _filters = value; }
        public List<List<Point>> CalcResults { get => calcResults; set => calcResults = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterConstruct wnd = new FilterConstruct();
            wnd.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FiltersBase.FiltersBase fBase;
            try
            {
                using (var input = File.OpenRead("filters.dat"))
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
                        _filters.Add(temp);
                    }
                }
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void MouseDownAction(object sender, MouseEventArgs e)
        {
            TempObject = sender;
            if (TempObject != null)
            {
                Size dragSize = SystemInformation.DragSize;
                DragBoxFromMouseDown = new Rectangle(new System.Drawing.Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                DragBoxFromMouseDown = Rectangle.Empty;
        }

        private void MouseMoveAction(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (DragBoxFromMouseDown != Rectangle.Empty && !DragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    ScreenOffset = SystemInformation.WorkingArea.Location;
                    DragDropEffects DropEffect = DoDragDrop(TempObject, DragDropEffects.Copy);
                }
            }
        }

        private void MouseUpAction(object sender, MouseEventArgs e)
        {
            DragBoxFromMouseDown = Rectangle.Empty;
        }

        private void ElementsSourceBox_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            FlowLayoutPanel lb = (FlowLayoutPanel)sender;
            if (lb != null)
            {
                Form f = lb.FindForm();
                if (((MousePosition.X - ScreenOffset.X) < f.DesktopBounds.Left) || ((MousePosition.X - ScreenOffset.X) > f.DesktopBounds.Right) || ((MousePosition.Y - ScreenOffset.Y) < f.DesktopBounds.Top) || ((MousePosition.Y - ScreenOffset.Y) > f.DesktopBounds.Bottom))
                {
                    e.Action = DragAction.Cancel;
                }
            }
        }

        private void ElementLineBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                PictureBox pic = (PictureBox)(e.Data.GetData(typeof(PictureBox)));

                if (e.Effect == DragDropEffects.Copy)
                {
                    if (pic != null)
                    {
                        SmartPictureBox NewPic = new SmartPictureBox(pic.Image);
                        if (pic == FinPanelSource)
                        {
                            NewPic.AssignOperation(new BSource());
                        }
                        if (pic == AttPanelSource)
                            NewPic.AssignOperation(new BAttenuator());
                        if (pic == FiltPanelSource)
                            NewPic.AssignOperation(new BFilter());

                        NewPic.SetLeftBtnEvent(DrawResult);
                        NewPic.SetRightBtnEvent(DeleteBlock);
                        NewPic.SetMidBtnEvent(SetupBlock);

                        ElementLineBox.Controls.Add(NewPic);
                        ElementLineBox.MinimumSize = new Size((ElementLineBox.Controls.Count + 1) * 70, ElementLineBox.MinimumSize.Height);
                    }
                }
            }
        }

        private void ElementLineBox_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        //private void SelectBlock(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < ElementLineBox.Controls.Count; i++)
        //    {
        //        if (ElementLineBox.Controls[i] == sender)
        //        {
        //            Type t = Blocks[i].GetType();
        //            //SelectedBlockParam.Text = t.Name + "[" + i.ToString() + "]";

        //            ((PictureBox)ElementLineBox.Controls[i]).BorderStyle = BorderStyle.Fixed3D;
        //            for (int j = 0; j < ElementLineBox.Controls.Count; j++)
        //            {
        //                if (j == i) continue;
        //                ((PictureBox)ElementLineBox.Controls[j]).BorderStyle = BorderStyle.FixedSingle;
        //            }
        //        }
        //    }
        //}

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch ms = new System.Diagnostics.Stopwatch();
            ms.Start();
            CalcResults.Clear();
            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                SmartPictureBox box = (SmartPictureBox)ElementLineBox.Controls[i];
                if (i == 0 && box.GetOperationType() == typeof(BSource))
                {
                    CalcResults.Add(new List<Point>());
                    ((BSource)box.OperationBlock).Generate(CalcResults[0]);
                }
                else if (i == 0)
                {
                    MessageBox.Show("Расчет прерван: Первым блоком должен идти источник сигнала.");
                    return;
                }
                else
                {
                    CalcResults.Add(new List<Point>());
                    box.OperationBlock.Apply(CalcResults[CalcResults.Count - 2], CalcResults[CalcResults.Count - 1]);
                }
            }
            ms.Stop();
            MessageBox.Show("Готово. " + ms.ElapsedMilliseconds.ToString() + " мс.");
        }

        private void DrawResult(object sender, EventArgs e)
        {
            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                if (((Button)sender).Parent == ElementLineBox.Controls[i])
                {
                    if (i > 0)
                    {
                        ChartProvider chart;
                        if (((SmartPictureBox)ElementLineBox.Controls[i]).GetOperationType()==typeof(BFilter))
                        {
                            SmartPictureBox box = (SmartPictureBox)ElementLineBox.Controls[i];
                            chart = new ChartProvider(CalcResults[i - 1], CalcResults[i], ((BFilter)(box.OperationBlock)).Filter);
                        }
                        else
                            chart = new ChartProvider(CalcResults[i - 1], CalcResults[i]);
                        chart.Show();
                    }
                    //TODO: для источника сигнала
                    return;
                }
            }
        }

        private void DeleteBlock(object sender, EventArgs e)
        {
            foreach (SmartPictureBox item in ElementLineBox.Controls)
            {
                if (item == ((Button)sender).Parent)
                {
                    ElementLineBox.Controls.Remove(item);
                    return;
                }
            }
        }

        private void SetupBlock(object sender, EventArgs e)
        {
            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                if (((Button)sender).Parent == ElementLineBox.Controls[i])
                {
                    BlockSetup stp = new BlockSetup(((SmartPictureBox)ElementLineBox.Controls[i]).OperationBlock);
                    stp.Show();
                    return;
                }
            }
        }
    }
}
