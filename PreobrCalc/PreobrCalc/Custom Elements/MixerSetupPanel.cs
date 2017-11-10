using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreobrCalc.Custom_Elements
{
    public partial class MixerSetupPanel : UserControl,IPanelInterface
    {
        BMixer op;
        double Fin=0;

        public MixerSetupPanel()
        {
            InitializeComponent();
        }

        public void SetCaption(int num)
        {
            MainGroupBox.Text = op.GetType().Name + "[" + num.ToString() + "]";
        }

        public MixerSetupPanel(BMixer op, string caption)
        {
            InitializeComponent();
            this.op = op;
            MainGroupBox.Text = caption;
            op.Order = decimal.ToInt32(OrderNumEdit.Value);
        }

        public void UpdateData()
        {
           FprEdit_TextChanged(FprEdit,new EventArgs());
        }

        private void FprEdit_TextChanged(object sender, EventArgs e)
        {
            if (Input.TryParse(FprEdit.Text, out double Fpr))
            {
                op.Fprch = Fpr;
                Fin = ((Form1)Parent.Parent).GetFin(sender);
                double Fget = 0;
                if (FinFgetPosChk.Checked)
                {
                    Fget = Fin - Fpr;
                }
                else
                {
                    Fget = Fin + Fpr;
                }

                FgetEdit.Text = Fget.ToString();
                op.Fget = Fget;
                op.FinBelowFget = FinFgetPosChk.Checked;
                op.Check();
                ((Form1)Parent.Parent).UpdateChildBlocks(sender);
            }
        }

        private void OrderNumEdit_ValueChanged(object sender, EventArgs e)
        {
            op.Order = decimal.ToInt32(OrderNumEdit.Value);
            op.Check();
        }

        private void FinFgetPosChk_CheckedChanged(object sender, EventArgs e)
        {
            if (Input.TryParse(FprEdit.Text, out double Fpr))
            {
                double Fget = 0;
                if (FinFgetPosChk.Checked)
                {
                    Fget = Fin - Fpr;
                }
                else
                {
                    Fget = Fin + Fpr;
                }

                FgetEdit.Text = Fget.ToString();
                op.Fget = Fget;
                op.FinBelowFget = FinFgetPosChk.Checked;
                op.Check();
                ((Form1)Parent.Parent).UpdateChildBlocks(FprEdit);
            }
        }
    }
}
