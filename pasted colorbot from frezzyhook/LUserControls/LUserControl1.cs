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
    public partial class LUserControl1 : UserControl
    {
        public static api KeyAuthApp = new api(
           name: "MadValo",
           ownerid: "F0NJmuehem",
           secret: "e9b8b432f97f7a7e6debc808597f497c6a0155ff3628b730246af3b2fc9764e3",
           version: "1.1"
       );
        public LUserControl1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyAuthApp.register(metroTextBox2.Text, metroTextBox1.Text, metroTextBox3.Text);
            if (KeyAuthApp.response.success)
            {
                this.Hide();
            }
            else
                label4.Show();
                label7.Show();
                label8.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            lUserControl31.Show();
            lUserControl31.BringToFront();
        }

        private void LUserControl1_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();

            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show(KeyAuthApp.response.message+" .");
                Environment.Exit(0);
            }
            label4.Hide();
            label7.Hide();
            label8.Hide();
            lUserControl31.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }

    }
}
