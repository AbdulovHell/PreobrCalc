﻿using System;
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
    public partial class AttSetupPanel : UserControl,IPanelInterface
    {
        BAttenuator op;

        public AttSetupPanel()
        {
            InitializeComponent();
        }

        public AttSetupPanel(BAttenuator op, string caption)
        {
            InitializeComponent();
            this.op = op;
            MainGroupBox.Text = caption;
        }

        public void SetCaption(int num)
        {
            MainGroupBox.Text = op.GetType().Name + "[" + num.ToString() + "]";
        }

        private void AttEdit_TextChanged(object sender, EventArgs e)
        {
            if (Input.TryParse(AttEdit.Text, out double att))
            {
                op.Att = att;
                op.Check();
            }
        }
    }
}
