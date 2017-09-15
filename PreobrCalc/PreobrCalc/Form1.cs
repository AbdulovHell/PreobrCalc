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
        private List<IBlock> Blocks;
        private List<List<Point>> calcResults;

        public Form1()
        {
            InitializeComponent();
            _filters = new List<Filter>();
            Blocks = new List<IBlock>();
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
                        PictureBox NewPic = new PictureBox()
                        {
                            Image = pic.Image,
                            SizeMode = pic.SizeMode,
                            BorderStyle = pic.BorderStyle
                        };
                        NewPic.Click += new System.EventHandler(SelectBlock);
                        //NewPic.Name = "Default";
                        //TODO: добавление в панель и лист очередности
                        if (pic == FinPanelSource)
                            Blocks.Add(new BSource());
                        if (pic == AttPanelSource)
                            Blocks.Add(new BAttenuator());
                        if (pic == FiltPanelSource)
                            Blocks.Add(new BFilter());
                        //Type a=Blocks[0].GetType();

                        ElementLineBox.Controls.Add(NewPic);
                        ElementLineBox.MinimumSize = new Size(ElementLineBox.MinimumSize.Width + 70, ElementLineBox.MinimumSize.Height);
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

        private void SelectBlock(object sender, EventArgs e)
        {
            for (int i = 0; i < ElementLineBox.Controls.Count; i++)
            {
                if (ElementLineBox.Controls[i] == sender)
                {
                    Type t = Blocks[i].GetType();
                    SelectedBlockParam.Text = t.Name + "[" + i.ToString() + "]";

                    ((PictureBox)ElementLineBox.Controls[i]).BorderStyle = BorderStyle.Fixed3D;
                    for (int j = 0; j < ElementLineBox.Controls.Count; j++)
                    {
                        if (j == i) continue;
                        ((PictureBox)ElementLineBox.Controls[j]).BorderStyle = BorderStyle.FixedSingle;
                    }
                }
            }
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                if (i == 0 && Blocks[i].GetType() == typeof(BSource))
                {
                    CalcResults.Add(new List<Point>());
                    ((BSource)Blocks[i]).Generate(CalcResults[0]);
                }
                else
                {
                    CalcResults.Add(new List<Point>());
                    Blocks[i].Apply(CalcResults[CalcResults.Count - 2], CalcResults[CalcResults.Count - 1]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            smartPictureBox1.SetImage(FinPanelSource.Image);
            smartPictureBox1.SetLeftBtnEvent(button2_Click);
            smartPictureBox1.SetMidBtnEvent(button2_Click);
            smartPictureBox1.SetRightBtnEvent(button2_Click);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectedBlockParam.Text = "[" + "]";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X:" + MousePosition.X.ToString() + " Y:" + MousePosition.Y.ToString();
            label2.Text = "X:" + (smartPictureBox1.Location.X + Location.X).ToString() + " Y:" + (smartPictureBox1.Location.Y + Location.Y).ToString();
            label3.Text = "X:" + SystemInformation.WorkingArea.Location.X.ToString() + " Y:" + SystemInformation.WorkingArea.Location.Y.ToString();
            label4.Text = "X:" + this.ClientRectangle.X.ToString() + " Y:" + this.ClientRectangle.Y.ToString();
        }
    }
}
