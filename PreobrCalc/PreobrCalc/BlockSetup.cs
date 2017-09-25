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
        double Fin = 0;

        public BlockSetup()
        {
            InitializeComponent();
        }

        public BlockSetup(IBlock operation, double Fin)
        {
            InitializeComponent();

            op = operation;
            this.Fin = Fin;
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
                    comboBox1.Items.Add(item.Name);
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
                label1.Text = "Fpr, MHz";
                if (FinFgetChk.Checked)
                {
                    textBox1.Text = (Fin - SrcOp.Fget).ToString();
                }
                else
                {
                    textBox1.Text = (Fin + SrcOp.Fget).ToString();
                }

                label2.Text = "Порядок, 3-5";
                textBox2.Text = SrcOp.Order.ToString();
            }
        }

        private void BlockSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (op.GetType() == typeof(BSource))
            {
                BSource SrcOp = (BSource)op;

                if (Input.TryParse(textBox2.Text, out double tempAtt) && Input.TryParse(textBox1.Text, out double tempFreq) && Input.TryParse(textBox3.Text, out double tempBand) && Input.TryParse(textBox4.Text, out double tempStep))
                {
                    if (!SrcOp.Setup(tempFreq, tempStep, tempBand, tempAtt))
                    {
                        MessageBox.Show("Недопустимые значения");
                    }
                }
                else
                    MessageBox.Show("Ошибка ввода");
            }
            else if (op.GetType() == typeof(BAttenuator))
            {
                BAttenuator SrcOp = (BAttenuator)op;

                if (Input.TryParse(textBox2.Text, out double tempAtt))
                {
                    if (!SrcOp.Setup(tempAtt))
                    {
                        MessageBox.Show("Недопустимые значения");
                    }
                }
                else
                    MessageBox.Show("Ошибка ввода");

            }
            else if (op.GetType() == typeof(BFilter))
            {
                BFilter SrcOp = (BFilter)op;

                int index = comboBox1.SelectedIndex;
                if (index < 0 || index > Form1.Filters.Count - 1) return;
                if (!SrcOp.Setup(Form1.Filters[index]))
                {
                    MessageBox.Show("Фильтр не выбран");
                }
            }
            else if (op.GetType() == typeof(BMixer))
            {
                BMixer SrcOp = (BMixer)op;

                if (Input.TryParse(textBox2.Text, out double tempOrder) && Input.TryParse(textBox1.Text, out double Fpr))
                {
                    double Fget = 0;
                    if (FinFgetChk.Checked)
                    {
                        Fget = Fin - Fpr;
                    }
                    else
                    {
                        Fget = Fin + Fpr;
                    }

                    SrcOp.Setup(Fget, (int)tempOrder, FinFgetChk.Checked);
                }
            }
        }
    }
}
