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
    public partial class SourceSetupPanel : UserControl,IPanelInterface
    {
        BSource op;

        public SourceSetupPanel()
        {
            InitializeComponent();
        }

        public SourceSetupPanel(BSource op,string caption)
        {
            InitializeComponent();
            this.op = op;
            MainGroupBox.Text = caption;
        }

        public void SetCaption(int num)
        {
            MainGroupBox.Text = op.GetType().Name + "[" + num.ToString() + "]";
        }

        private void FreqEdit_TextChanged(object sender, EventArgs e)
        {
            if (Input.TryParse(FreqEdit.Text, out double freq))
            {
                if (freq <= 0) return;
                op.Freq = freq;
                op.Check();
                ((Form1)Parent.Parent).UpdateChildBlocks(sender);
            }
        }

        private void AttEdit_TextChanged(object sender, EventArgs e)
        {
            if (Input.TryParse(AttEdit.Text, out double att))
            {
                op.Att = att;
                op.Check();
            }
        }

        private void BandEdit_TextChanged(object sender, EventArgs e)
        {
            if (Input.TryParse(BandEdit.Text, out double band))
            {
                if (band < 0 || ((op.Freq - band / 2) <= 0)) return;
                op.Band = band;
                op.Check();
            }
        }

        private void StepEdit_TextChanged(object sender, EventArgs e)
        {
            if (Input.TryParse(StepEdit.Text, out double step))
            {
                if (op.Band <= 0 && (step <= 0 || step > op.Band)) return;
                op.Step = step;
                op.Check();
            }
        }
    }
}
