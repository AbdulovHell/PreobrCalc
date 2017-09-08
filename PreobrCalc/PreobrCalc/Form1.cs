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

        public Form1()
        {
            InitializeComponent();
            _filters = new List<Filter>();
        }

        public static List<Filter> Filters { get => _filters; set => _filters = value; }

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
                }
            }catch(IOException exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
