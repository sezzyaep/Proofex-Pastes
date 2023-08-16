using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyCheats.LUserControls
{
    public partial class LUserControl2 : UserControl
    {
        public LUserControl2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LUserControl2_Load(object sender, EventArgs e)
        {
            lUserControl31.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            lUserControl31.Show();
            lUserControl31.BringToFront();
        }
    }
}
