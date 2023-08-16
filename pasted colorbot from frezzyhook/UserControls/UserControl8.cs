using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyCheats.UserControls
{
    public partial class UserControl8 : UserControl
    {
        public UserControl8()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControl8_Load(object sender, EventArgs e)
        {
            userControl91.Hide();
            userControl101.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl91.Show();
            userControl91.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl101.Show();
            userControl101.BringToFront();
        }

        private void userControl101_Load(object sender, EventArgs e)
        {

        }
    }
}
