using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarSolver
{
    public partial class GridSizeSettings : Form
    {
        public static int GridHeight = 30;
        public static int GridWidth = 30;

        public GridSizeSettings()
        {
            InitializeComponent();

            this.numericUpDown1.Value = GridWidth;
            this.numericUpDown2.Value = GridHeight;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GridWidth = (int)this.numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            GridHeight = (int)this.numericUpDown2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
