using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyCheats
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        bool Grip;
        int MouseX, MouseY;
        private void Top_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Grip == true)
            {
                this.Left = Cursor.Position.X - MouseX;
                this.Top = Cursor.Position.Y - MouseY;
            }
        }

        private void Top_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            Grip = false;
            MouseX = 0;
            MouseY = 0;
        }

        private void Button_Top_Panel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button2_Top_Panel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void Login_Form_Load(object sender, EventArgs e)
        {
    
        }



        private void lUserControl41_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Top_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Grip = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
    }
}
