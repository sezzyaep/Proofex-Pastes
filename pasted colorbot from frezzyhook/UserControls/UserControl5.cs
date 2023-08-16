using System;
using System.Windows.Forms;

namespace SkyCheats.UserControls
{
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            userControl61.Show();
            userControl81.Show();
            userControl61.BringToFront();
            userControl81.BringToFront();
            button9.Show();
            button10.Show();
            button9.BringToFront();
            button10.BringToFront();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            userControl61.Hide();
            button9.Hide();
            button10.Hide();
            userControl81.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userControl61.Hide();
            userControl81.Hide();
            button9.Hide();
            button10.Hide();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void userControl81_Load(object sender, EventArgs e)
        {
            button8.Text = config.user_data.username;
            button1.Text = config.user_data.username;
            button3.Text = "Unknown";
            button4.Text = config.expirylefttime;

        }
    }
}
