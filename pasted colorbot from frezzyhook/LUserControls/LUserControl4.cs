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
    public partial class LUserControl4 : UserControl
    {
        public static api KeyAuthApp = new api(
           name: "MadValo",
           ownerid: "F0NJmuehem",
           secret: "e9b8b432f97f7a7e6debc808597f497c6a0155ff3628b730246af3b2fc9764e3",
           version: "1.1"
        );
        public LUserControl4()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            lUserControl11.Show();

            lUserControl11.BringToFront();
        }

        private void Button_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LUserControl4_Load(object sender, EventArgs e)
        {
            label9.Hide();
            label8.Hide();
            KeyAuthApp.init();

            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show(KeyAuthApp.response.message + " ,");
                Environment.Exit(0);
            }
            lUserControl11.Hide();
            lUserControl21.Hide();
            lUserControl31.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            lUserControl21.Show();

            lUserControl21.BringToFront();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            lUserControl31.Show();
        }

        private void lUserControl31_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(metroTextBox2.Text, metroTextBox1.Text);
            if (KeyAuthApp.response.success)
            {
                config.usernamee = metroTextBox2.Text;
                config.passwordd = metroTextBox1.Text;
                Main_Form main = new Main_Form();
                ((Form)this.TopLevelControl).Hide();
                main.Show();
                
            }
            else
                label9.Show();
                label8.Show();
                
        }

        private void lUserControl11_Load(object sender, EventArgs e)
        {
            
        }
    }
}
