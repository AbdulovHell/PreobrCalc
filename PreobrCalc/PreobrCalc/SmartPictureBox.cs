using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreobrCalc
{
    public partial class SmartPictureBox : UserControl
    {
        int X = 0;
        int Y = 0;
        const int dopSize = 2;

        IBlock opBlock;

        public IBlock OperationBlock { get => opBlock; }

        public SmartPictureBox()
        {
            InitializeComponent();
            LeftBtn.Visible = false;
            MidBtn.Visible = false;
            RightBtn.Visible = false;
        }

        public SmartPictureBox(Image img, EventHandler L, EventHandler M, EventHandler R)
        {
            InitializeComponent();
            LeftBtn.Visible = false;
            MidBtn.Visible = false;
            RightBtn.Visible = false;
            ImageBox.Image = img;
            LeftBtn.Click += L;
            MidBtn.Click += M;
            RightBtn.Click += R;
        }

        public SmartPictureBox(Image img)
        {
            InitializeComponent();
            LeftBtn.Visible = false;
            MidBtn.Visible = false;
            RightBtn.Visible = false;
            ImageBox.Image = img;
        }

        public SmartPictureBox(EventHandler L, EventHandler M, EventHandler R)
        {
            InitializeComponent();
            LeftBtn.Visible = false;
            MidBtn.Visible = false;
            RightBtn.Visible = false;
            LeftBtn.Click += L;
            MidBtn.Click += M;
            RightBtn.Click += R;
        }

        ~SmartPictureBox()
        {
            timer1.Enabled = false;
        }

        public void SetImage(Image img)
        {
            ImageBox.Image = img;
        }

        public void SetLeftBtnEvent(EventHandler EventClick)
        {
            LeftBtn.Click += EventClick;
        }

        public void SetMidBtnEvent(EventHandler EventClick)
        {
            MidBtn.Click += EventClick;
        }

        public void SetRightBtnEvent(EventHandler EventClick)
        {
            RightBtn.Click += EventClick;
        }

        public void VisibleButtons(bool b)
        {
            LeftBtn.Visible = b;
            MidBtn.Visible = b;
            RightBtn.Visible = b;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                X = Parent.Parent.Location.X + Parent.Location.X + Location.X + 10 - dopSize;
                Y = Parent.Parent.Location.Y + Parent.Location.Y + Location.Y + 31 - dopSize;
                Rectangle rect = new Rectangle(X, Y, 64 + dopSize, 64 + dopSize);
                if (rect.Contains(MousePosition))
                {
                    VisibleButtons(true);
                }
                else
                    VisibleButtons(false);
            }catch(Exception exception)
            {

            }
        }

        public void AssignOperation(IBlock op)
        {
            opBlock = op;
        }

        public Type GetOperationType()
        {
            return opBlock.GetType();
        }
    }
}
