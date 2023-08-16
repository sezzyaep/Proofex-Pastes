using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Management;

//if (metroCheckBox2.Checked)
//{
//    // Set the Frequency
//    int frequency = 1200;

//    // Set the Duration
//    int duration = 100;

//    // Play beep sound once
//    Console.Beep(frequency, duration);
//}
//else
//{
//    int frequency = 1600;

//    // Set the Duration
//    int duration = 100;

//    // Play beep sound once
//    Console.Beep(frequency, duration);
//}
namespace SkyCheats
{
    public partial class UserControl1 : UserControl
    {


        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int ArrowKeys);
        public UserControl1()
        {
            InitializeComponent();
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
            
            
            config.bodyx = -1;
            config.bodyy = -10;

            config.bone1_target = "BODY";
            config.bone2_target = "NECK";

            config.color = "Purple";

            metroComboBox2.Text = metroComboBox2.Items[1].ToString();
            buttonHead2.Hide();
            pictureBoxHead2.Hide();
            buttonBody2.Hide();
            pictureBoxBody2.Hide();
            buttonBody.Hide();
            pictureBoxBody.Hide();
            buttonNeck.Hide();
            pictureBoxNeck.Hide();

            timer1.Start();            
        }
        public void timer1_Tick(object sender, EventArgs e)
        {

            if ( GetAsyncKeyState(config.triggerbot_on_of_key) < 0)
            {
                metroCheckBox2.Checked = !metroCheckBox2.Checked;
                
                while (GetAsyncKeyState(config.triggerbot_on_of_key) < 0)
                {
                    Thread.Sleep(30);
                }
            }
            if (GetAsyncKeyState(config.aimbot_on_of_key) < 0)
            {
                metroCheckBox1.Checked = !metroCheckBox1.Checked;

                while (GetAsyncKeyState(config.aimbot_on_of_key) < 0)
                {
                    Thread.Sleep(30);
                }
            }
            if (GetAsyncKeyState(config.bone1_key) < 0)
            {
                metroCheckBox7.Checked = true;
                metroCheckBox8.Checked = false;

                while (GetAsyncKeyState(config.bone1_key) < 0)
                {
                    Thread.Sleep(30);
                }
            }
            if (GetAsyncKeyState(config.bone2_key) < 0)
            {
                metroCheckBox8.Checked = true;
                metroCheckBox7.Checked = false;

                while (GetAsyncKeyState(config.bone2_key) < 0)
                {
                    Thread.Sleep(30);
                }
            }

        }
        private void buttonNeck2_Click(object sender, EventArgs e)
        {
            config.bone1_target = "HEAD";
            config.uwux = config.headx;
            config.uwuy = config.heady;
            buttonNeck2.Hide();
            pictureBoxNeck2.Hide();
            buttonHead2.Show();
            pictureBoxHead2.Show();

            
        }

        private void buttonHead2_Click(object sender, EventArgs e)
        {
            config.bone1_target = "BODY";
            config.uwux = config.bodyx;
            config.uwuy = config.bodyy;
            buttonHead2.Hide();
            pictureBoxHead2.Hide();
            buttonBody2.Show();
            pictureBoxBody2.Show();
        }

        private void buttonBody2_Click(object sender, EventArgs e)
        {
            config.bone1_target = "NECK";
            config.uwux = -1;
            config.uwuy = -5;
            buttonBody2.Hide();
            pictureBoxBody2.Hide();
            buttonNeck2.Show();
            pictureBoxNeck2.Show();
        }

        private void buttonHead_Click(object sender, EventArgs e)
        {
            config.bone2_target = "BODY";
            config.uwux = config.bodyx;
            config.uwuy = config.bodyy;
            buttonHead.Hide();
            pictureBoxHead.Hide();
            buttonBody.Show();
            pictureBoxBody.Show();
        }

        private void buttonBody_Click(object sender, EventArgs e)
        {
            config.bone2_target = "NECK";
            config.uwux = -1;
            config.uwuy = -5;
            buttonBody.Hide();
            pictureBoxBody.Hide();
            buttonNeck.Show();
            pictureBoxNeck.Show();
        }

        private void buttonNeck_Click(object sender, EventArgs e)
        {
            config.bone2_target = "HEAD";
            config.uwux = config.headx;
            config.uwuy = config.heady;
            buttonNeck.Hide();
            pictureBoxNeck.Hide();
            buttonHead.Show();
            pictureBoxHead.Show();
        }
        int[] list_characters = new int[] { 1, 2, 5, 6, 9, 16, 17, 18, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };
        private void label3_Click(object sender, EventArgs e)
        {
            
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }

            int key = get_key();

            label3.Text = get_name_of_key(key);

            if (key !=0)
                config.aimbot_on_of_key = key;

        }
        
        int get_key()
         {
            for (int i = 0; i < 150; i++)
            {
                foreach (int item in list_characters)
                {
                    if (GetAsyncKeyState(item) < 0)
                    {
                        return item;
                    }
                }
                Thread.Sleep(10);

            }
            return 180;
        }
        string get_name_of_key(int key)
        {
            switch (key)
            {
                case 1:
                    return "[ Left ]";
                case 2:
                    return "[ Right]";
                case 5:
                    return "[ X1 ]";
                case 6:
                    return "[ X2 ]";
                case 9:
                    return "[ TAB ]";
                case 16:
                    return "[ SHIFT ]";
                case 17:
                    return "[ CTRL ]";
                case 18:
                    return "[ ALT ]";
                case 65:
                    return "[ A ]";
                case 66:
                    return "[ B ]";
                case 67:
                    return "[ C ]";
                case 68:
                    return "[ D ]";
                case 69:
                    return "[ E ]";
                case 70:
                    return "[ F ]";
                case 71:
                    return "[ G ]";
                case 72:
                    return "[ H ]";
                case 73:
                    return "[ I ]";
                case 74:
                    return "[ J ]";
                case 75:
                    return "[ K ]";
                case 76:
                    return "[ L ]";
                case 77:
                    return "[ M ]";
                case 78:
                    return "[ N ]";
                case 79:
                    return "[ O ]";
                case 80:
                    return "[ P ]";
                case 81:
                    return "[ Q ]";
                case 82:
                    return "[ R ]";
                case 83:
                    return "[ S ]";
                case 84:
                    return "[ T ]";
                case 85:
                    return "[ U ]";
                case 86:
                    return "[ V ]";
                case 87:
                    return "[ W ]";
                case 88:
                    return "[ X ]";
                case 89:
                    return "[ Y ]";
                case 90:
                    return "[ Z ]";


                default:
                    return "[ - ]";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Picture_UserControl1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                config.triggerbot_state = true;
            }
            else
            {
                config.triggerbot_state = false;
            }
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked)
            {
                config.auto_fire_state = true;
            }
            else
            {
                config.auto_fire_state = false;
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)
            {
                config.aim_only_on_x_state = true;
            }
            else
            {
                config.aim_only_on_x_state = false;
            }
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox6.Checked)
            {
                config.smooth_state = true;
            }
            else
            {
                config.smooth_state = false;
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked)
            {
                config.ignore_sky_skills = true;
            }
            else
            {
                config.ignore_sky_skills = false;
            }
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox7.Checked)
            {
                config.bone1_state = true;
                if (config.bone1_target == "HEAD")
                {
                    config.uwux = config.headx;
                    config.uwuy = config.heady;
                }
                else if (config.bone1_target == "NECK")
                {
                    config.uwux = -1;
                    config.uwuy = -5;
                }
                else if (config.bone1_target == "BODY")
                {
                    config.uwux = config.bodyx;
                    config.uwuy = config.bodyy;
                }
            }
            else
            {
                config.bone1_state = false;
            }
            if (config.bone1_state || config.bone2_state)
            {
                config.bodypartcheckboxselectiontruefalse = true;
            }
            else
            {
                config.bodypartcheckboxselectiontruefalse = false;
            }
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox8.Checked)
            {
                config.bone2_state = true;
                if (config.bone2_target == "HEAD")
                {
                    config.uwux = config.headx;
                    config.uwuy = config.heady;
                }
                else if (config.bone2_target == "NECK")
                {
                    config.uwux = -1;
                    config.uwuy = -5;
                }
                else if (config.bone2_target == "BODY")
                {
                    config.uwux = config.bodyx;
                    config.uwuy = config.bodyy;
                }
            }
            else
            {
                config.bone2_state = false;
            }
            if (config.bone1_state || config.bone2_state)
            {
                config.bodypartcheckboxselectiontruefalse = true;
            }
            else
            {
                config.bodypartcheckboxselectiontruefalse = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }


            int key = get_key();

            label4.Text = get_name_of_key(key);

            
                config.triggerbot_on_of_key = key;

        }

        private void label11_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }


            int key = get_key();

            label11.Text = get_name_of_key(key);

            
                config.aim_key = key;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Green;
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }   


            int key = get_key();

            label10.Text = get_name_of_key(key);


            config.trigger_key = key;
            label10.ForeColor = Color.FromArgb(255,102, 102, 102);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }


            int key = get_key();

            label19.Text = get_name_of_key(key);

            
                config.bone1_key = key;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }


            int key = get_key();

            label20.Text = get_name_of_key(key);

            
                config.bone2_key = key;

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.color = metroComboBox2.Text;//color_int
            //if (metroComboBox2.Text == "Purple")
            //{
            //    config.color_int=
            //}
        }

        private void metroCheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                config.aimbot_state_checkbox = true;
            }
            else
            {
                config.aimbot_state_checkbox = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }


            int key = get_key();


            label7.Text = get_name_of_key(key);
            config.silent_key = key;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {
            label21.ForeColor = Color.Green;
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }


            int key = get_key();

            label21.Text = get_name_of_key(key);


            config.flick_key = key;
            label21.ForeColor = Color.FromArgb(255, 102, 102, 102);
        }

        private void pictureBoxBody_Click(object sender, EventArgs e)
        {

        }
    }
}
