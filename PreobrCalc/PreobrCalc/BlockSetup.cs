using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreobrCalc
{
    public partial class BlockSetup : Form
    {
        IBlock op;

        public BlockSetup()
        {
            InitializeComponent();
        }

        public BlockSetup(IBlock operation)
        {
            InitializeComponent();

            op = operation;
            if (operation.GetType() == typeof(BSource))
            {
                BSource SrcOp = (BSource)operation;

                textBox2.Text = SrcOp.Att.ToString();
                textBox1.Text = SrcOp.Freq.ToString();
                textBox3.Text = SrcOp.Band.ToString();
                textBox4.Text = SrcOp.Step.ToString();

                Size = new Size(253, 141);
            }
            else if (operation.GetType() == typeof(BAttenuator))
            {
                BAttenuator SrcOp = (BAttenuator)operation;

                textBox2.Text = SrcOp.Att.ToString();
                label2.Text = "Затухание, dB";
                textBox1.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;

                Size = new Size(253, 141);
            }
            else if (operation.GetType() == typeof(BFilter))
            {
                BFilter SrcOp = (BFilter)operation;

                textBox2.Visible = false;
                textBox1.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;

                foreach (var item in Form1.Filters)
                {
                    comboBox1.Items.Add(item);
                }
            }
            else if (operation.GetType() == typeof(BMixer))
            {
                BMixer SrcOp = (BMixer)operation;

                label3.Visible = false;
                textBox3.Visible = false;
                label4.Visible = false;
                textBox4.Visible = false;

                FinFgetChk.Visible = true;
                FinFgetChk.Checked = SrcOp.FinBelowFget;
                textBox1.Text=
            }
        }

        private void BlockSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (op.GetType() == typeof(BSource))
            {
                BSource SrcOp = (BSource)op;

                if (Input.TryParse(textBox2.Text, out double temp2))
                    SrcOp.Att = temp2;
                if (Input.TryParse(textBox1.Text, out double temp1))
                    SrcOp.Freq = temp1;
                if (Input.TryParse(textBox3.Text, out double temp3))
                    SrcOp.Band = temp3;
                if (Input.TryParse(textBox4.Text, out double temp4))
                    SrcOp.Step = temp4;
            }
            else if (op.GetType() == typeof(BAttenuator))
            {
                BAttenuator SrcOp = (BAttenuator)op;

                if (Input.TryParse(textBox2.Text, out double temp2))
                    SrcOp.Att = temp2;
            }
            else if (op.GetType() == typeof(BFilter))
            {
                BFilter SrcOp = (BFilter)op;

                SrcOp.Filter = (Filter)comboBox1.SelectedItem;
            }
        }
    }
}
