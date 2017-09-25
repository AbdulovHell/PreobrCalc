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
    public partial class FilterSetupPanel : UserControl
    {
        BFilter op;

        public FilterSetupPanel()
        {
            InitializeComponent();
        }

        public FilterSetupPanel(BFilter op, string caption)
        {
            InitializeComponent();
            this.op = op;
            MainGroupBox.Text = caption;
            foreach (var item in Form1.Filters)
            {
                FIltersList.Items.Add(item.Name);
            }
        }

        private void FIltersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = FIltersList.SelectedIndex;
            if (index < 0 || index > Form1.Filters.Count - 1) return;

            int mult = decimal.ToInt32(FiltersMultNum.Value);
            op.Setup(Form1.Filters[index]);
            op.Multiplier = mult;
            chart1.Series[0].Points.Clear();
            foreach (var item in Form1.Filters[index].Points)
            {
                chart1.Series[0].Points.AddXY(item.Freq,item.Att*mult);
            }
        }
    }
}
