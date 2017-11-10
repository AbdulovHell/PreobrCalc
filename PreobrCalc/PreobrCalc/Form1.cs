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
        private List<IBlock> operationBlocks;
        private List<List<Point>> calcResults;
        private bool Changed = true;

        public Form1()
        {
            InitializeComponent();
            _filters = new List<Filter>();
            operationBlocks = new List<IBlock>();
            calcResults = new List<List<Point>>();
            _filters.Clear();
            //SettingLineBox.HorizontalScroll.Enabled = true;
            SettingLineBox.MaximumSize = new Size(Width - SettingLineBox.Location.X, Height - SettingLineBox.Location.Y);
            //SettingLineBox.HorizontalScroll.Visible = true;
        }

        public static List<Filter> Filters { get => _filters; set => _filters = value; }
        public List<List<Point>> CalcResults { get => calcResults; set => calcResults = value; }
        public List<IBlock> OperationBlocks { get => operationBlocks; set => operationBlocks = value; }

        private void OpenFilterEditorBtn_Click(object sender, EventArgs e)
        {
            FilterConstruct wnd = new FilterConstruct();
            wnd.Show();
        }

        public SmartPictureBox GetControlAtIndex(int index)
        {
            return (SmartPictureBox)ElementLineBox.Controls[index];
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
                //MessageBox.Show(exception.ToString());
            }
        }

        public double GetFin(object sender)
        {
            double freq = 0;

            TextBox temp = (TextBox)sender;
            int index = 0;

            for (int i = 0; i < SettingLineBox.Controls.Count; i++)
            {
                if (temp.Parent.Parent == SettingLineBox.Controls[i])
                {
                    index = i;
                    break;
                }
            }

            for (int i = index - 1; i >= 0; i--)
            {
                if (OperationBlocks[i].GetType() == typeof(BSource))
                {
                    freq = ((BSource)OperationBlocks[i]).Freq;
                    break;
                }
                else if (OperationBlocks[i].GetType() == typeof(BMixer))
                {
                    freq = ((BMixer)OperationBlocks[i]).Fprch;
                    break;
                }
            }

            return freq;
        }

        public void UpdateChildBlocks(object sender)
        {
            TextBox temp = (TextBox)sender;
            int index = 0;

            for (int i = 0; i < SettingLineBox.Controls.Count; i++)
            {
                if (temp.Parent.Parent == SettingLineBox.Controls[i])
                {
                    index = i;
                    break;
                }
            }

            for (int i = index + 1; i < SettingLineBox.Controls.Count; i++)
            {
                //if (OperationBlocks[i].GetType() == typeof(BSource))
                //{

                //    break;
                //}
                //else 
                if (OperationBlocks[i].GetType() == typeof(BMixer))
                {
                    Custom_Elements.MixerSetupPanel panel = (Custom_Elements.MixerSetupPanel)SettingLineBox.Controls[i];
                    panel.UpdateData();
                }
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
                            OperationBlocks.Add(new BSource());
                            //NewPic.AssignOperation(new BSource());
                            SettingLineBox.Controls.Add(new Custom_Elements.SourceSetupPanel((BSource)OperationBlocks[OperationBlocks.Count - 1], OperationBlocks[OperationBlocks.Count - 1].GetType().Name + "[" + (OperationBlocks.Count - 1).ToString() + "]"));
                        }
                        if (pic == AttPanelSource)
                        {
                            OperationBlocks.Add(new BAttenuator());
                            //NewPic.AssignOperation(new BAttenuator());
                            SettingLineBox.Controls.Add(new Custom_Elements.AttSetupPanel((BAttenuator)OperationBlocks[OperationBlocks.Count - 1], OperationBlocks[OperationBlocks.Count - 1].GetType().Name + "[" + (OperationBlocks.Count - 1).ToString() + "]"));
                        }
                        if (pic == FiltPanelSource)
                        {
                            OperationBlocks.Add(new BFilter());
                            //NewPic.AssignOperation(new BFilter());
                            SettingLineBox.Controls.Add(new Custom_Elements.FilterSetupPanel((BFilter)OperationBlocks[OperationBlocks.Count - 1], OperationBlocks[OperationBlocks.Count - 1].GetType().Name + "[" + (OperationBlocks.Count - 1).ToString() + "]"));
                        }
                        if (pic == MixerPanelSource)
                        {
                            OperationBlocks.Add(new BMixer());
                            //NewPic.AssignOperation(new BMixer());
                            SettingLineBox.Controls.Add(new Custom_Elements.MixerSetupPanel((BMixer)OperationBlocks[OperationBlocks.Count - 1], OperationBlocks[OperationBlocks.Count - 1].GetType().Name + "[" + (OperationBlocks.Count - 1).ToString() + "]"));
                        }

                        NewPic.SetLeftBtnEvent(DrawResult);
                        NewPic.SetRightBtnEvent(DeleteBlock);
                        NewPic.SetMidBtnEvent(SetupBlock);
                        NewPic.SetMainClick(Select_Click);

                        ElementLineBox.Controls.Add(NewPic);
                        ElementLineBox.MinimumSize = new Size((ElementLineBox.Controls.Count + 1) * 70, ElementLineBox.MinimumSize.Height);
                        HideOtherSettings(SettingLineBox.Controls.Count - 1);
                    }
                }
            }
        }

        private void HideOtherSettings(int index)
        {
            for (int i = 0; i < SettingLineBox.Controls.Count; i++)
            {
                if (i != index)
                {
                    SettingLineBox.Controls[i].Visible = false;
                }
                else
                    SettingLineBox.Controls[i].Visible = true;
            }

            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                if (i == index)
                {
                    ((SmartPictureBox)ElementLineBox.Controls[i]).SetActiveState(true);
                }
                else
                {
                    ((SmartPictureBox)ElementLineBox.Controls[i]).SetActiveState(false);
                }
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            int index = -1;

            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                if (temp.Parent == ElementLineBox.Controls[i])
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return;

            HideOtherSettings(index);
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
            for (int i = 0; i < OperationBlocks.Count; i++)
            {
                if (!OperationBlocks[i].Ready())
                {
                    MessageBox.Show("Элемент " + OperationBlocks[i].GetType() + "[" + i.ToString() + "]" + " не настроен");
                    return;
                }
            }

            System.Diagnostics.Stopwatch ms = new System.Diagnostics.Stopwatch();
            ms.Start();
            CalcResults.Clear();
            for (int i = 0; i < OperationBlocks.Count; i++)
            {
                if (i == 0 && OperationBlocks[i].GetType() == typeof(BSource))
                {
                    CalcResults.Add(new List<Point>());
                    ((BSource)OperationBlocks[i]).Generate(CalcResults[0]);
                }
                else if (i == 0)
                {
                    MessageBox.Show("Расчет прерван: Первым блоком должен идти источник сигнала.");
                    return;
                }
                else
                {
                    CalcResults.Add(new List<Point>());
                    OperationBlocks[i].Apply(CalcResults[CalcResults.Count - 2], CalcResults[CalcResults.Count - 1]);
                }
            }
            ms.Stop();
            Changed = false;
            MessageBox.Show("Готово. " + ms.ElapsedMilliseconds.ToString() + " мс.");
        }

        private void DrawResult(object sender, EventArgs e)
        {
            if (Changed)
            {
                MessageBox.Show("Необходимо выполнить перерасчет");
                return;
            }
            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                if (((Button)sender).Parent == ElementLineBox.Controls[i])
                {
                    if (i > 0)
                    {
                        ChartProvider chart;
                        if (OperationBlocks[i].GetType() == typeof(BFilter))
                        {
                            chart = new ChartProvider(CalcResults[i - 1], CalcResults[i], ((BFilter)(OperationBlocks[i])).Filter, ((BFilter)(OperationBlocks[i])).Multiplier);
                        }
                        else
                            chart = new ChartProvider(CalcResults[i - 1], CalcResults[i]);
                        if (chart != null)
                            chart.Show();
                    }
                    else
                    {
                        if (OperationBlocks[i].GetType() == typeof(BSource))
                        {
                            ChartProvider chart;
                            chart = new ChartProvider(CalcResults[i]);
                            chart.Show();
                        }
                    }
                    return;
                }
            }
        }

        private void UpdateCaptions()
        {
            for (int i = 0; i < SettingLineBox.Controls.Count; i++)
            {
                ((Custom_Elements.IPanelInterface)SettingLineBox.Controls[i]).SetCaption(i);
            }
        }

        private void DeleteBlock(object sender, EventArgs e)
        {
            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                if (ElementLineBox.Controls[i] == ((Button)sender).Parent)
                {
                    ElementLineBox.Controls.RemoveAt(i);
                    OperationBlocks.RemoveAt(i);
                    SettingLineBox.Controls.RemoveAt(i);
                    Changed = true;
                    UpdateCaptions();
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
                    SettingLineBox.Controls[i].Focus();
                    return;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = Properties.Settings.Default.
        }
    }
}
