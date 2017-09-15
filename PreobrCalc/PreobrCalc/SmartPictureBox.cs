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

        public SmartPictureBox()
        {
            InitializeComponent();
            LeftBtn.Visible = false;
            MidBtn.Visible = false;
            RightBtn.Visible = false;
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

        private void ImageBox_MouseLeave(object sender, EventArgs e)
        {
            X = Parent.Location.X + Location.X + 10;
            Y = Parent.Location.Y + Location.Y + 31;
            Rectangle rect = new Rectangle(X, Y, 64, 64);
            if (rect.Contains(MousePosition))
            {
                VisibleButtons(true);
            }
            else
                VisibleButtons(false);
        }

        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            X = Parent.Location.X + Location.X + 10;
            Y = Parent.Location.Y + Location.Y + 31;
            Rectangle rect = new Rectangle(X, Y, 64, 64);
            if (rect.Contains(MousePosition))
            {
                VisibleButtons(true);
            }
            else
                VisibleButtons(false);
        }
    }
}
