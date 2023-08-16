using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyCheats.UserControls
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            metroComboBox1.Text = metroComboBox1.Items[0].ToString();
            metroComboBox2.Text = metroComboBox2.Items[1].ToString();
            metroComboBox3.Text = metroComboBox3.Items[2].ToString();
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                config.hip_fire_state = true;
                
            }
            else
            {
                config.hip_fire_state = false;
            }
            
        }
        

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                config.recoil_system_state = true;
            }
            else
            {
                config.recoil_system_state = false;
            }
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            config.rcs_smooth = metroTrackBar2.Value/100*2;
            label3.Text = metroTrackBar2.Value.ToString();
        }

        //private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        //{
        //    config.max_recoil = metroTrackBar1.Value;
        //    label13.Text = metroTrackBar1.Value.ToString();
        //}
        //private void metroTrackBar3_Scroll(object sender, ScrollEventArgs e)
        //{
        //    config.recoilspeed = (Convert.ToDouble(metroTrackBar3.Value)/100)*3;
        //    label14.Text = metroTrackBar3.Value.ToString();
        //}
        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox7.Checked)
            {
                config.weapon2_state = true;
                switch (metroComboBox2.SelectedIndex)
                {
                    case 0:
                        config.max_recoil = 80;
                        config.recoilspeed = 0.75;
                        break;
                    case 1:
                        config.max_recoil = 35;
                        config.recoilspeed = 1.2;
                        break;
                    case 2:
                        config.max_recoil = 30;
                        config.recoilspeed = 1.5;
                        break;
                    case 3:
                        config.max_recoil = 90;
                        config.recoilspeed = 0.75;
                        break;
                    case 4:
                        config.max_recoil = 38;
                        config.recoilspeed = 1.5;
                        break;
                    case 5:
                        config.max_recoil = 35;
                        config.recoilspeed = 1.5;
                        break;
                    case 6:
                        config.max_recoil = 46;
                        config.recoilspeed = 1.5;
                        break;
                    case 7:
                        config.max_recoil = 43;
                        config.recoilspeed = 1.5;
                        break;

                }
            }
            else
            {
                config.weapon2_state = false;
            }
        }
        

        private void metroCheckBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)
            {
                config.weapon1_state = true;
                switch (metroComboBox1.SelectedIndex)
                {
                    case 0:
                        config.max_recoil = 80;
                        config.recoilspeed = 0.75;
                        break;
                    case 1:
                        config.max_recoil = 35;
                        config.recoilspeed = 1.2;
                        break;
                    case 2:
                        config.max_recoil = 30;
                        config.recoilspeed = 1.5;
                        break;
                    case 3:
                        config.max_recoil = 90;
                        config.recoilspeed = 0.75;
                        break;
                    case 4:
                        config.max_recoil = 38;
                        config.recoilspeed = 1.5;
                        break;
                    case 5:
                        config.max_recoil = 35;
                        config.recoilspeed = 1.5;
                        break;
                    case 6:
                        config.max_recoil = 46;
                        config.recoilspeed = 1.5;
                        break;
                    case 7:
                        config.max_recoil = 43;
                        config.recoilspeed = 1.5;
                        break;

                }

            }
            else
            {
                config.weapon1_state = false;
            }
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked)
            {
                config.weapon3_state = true;
                switch (metroComboBox3.SelectedIndex)
                {
                    case 0:
                        config.max_recoil = 80;
                        config.recoilspeed = 0.75;
                        break;
                    case 1:
                        config.max_recoil = 35;
                        config.recoilspeed = 1.2;
                        break;
                    case 2:
                        config.max_recoil = 30;
                        config.recoilspeed = 1.5;
                        break;
                    case 3:
                        config.max_recoil = 90;
                        config.recoilspeed = 0.75;
                        break;
                    case 4:
                        config.max_recoil = 38;
                        config.recoilspeed = 1.5;
                        break;
                    case 5:
                        config.max_recoil = 35;
                        config.recoilspeed = 1.5;
                        break;
                    case 6:
                        config.max_recoil = 46;
                        config.recoilspeed = 1.5;
                        break;
                    case 7:
                        config.max_recoil = 43;
                        config.recoilspeed = 1.5;
                        break;

                }
            }
            else
            {
                config.weapon3_state = false;
            }
        }
         void allhide1() {
            pictureBoxARES1.Hide();
            pictureBoxBULLDOG1.Hide();
            pictureBoxFRENZY1.Hide();
            pictureBoxODIN1.Hide();
            pictureBoxPHANTOM1.Hide();
            pictureBoxSPECTRE1.Hide();
            pictureBoxSTINGER1.Hide();
            pictureBoxVANDAL1.Hide();
        }
        void allhide2()
        {
            pictureBoxARES2.Hide();
            pictureBoxBULLDOG2.Hide();
            pictureBoxFRENZY2.Hide();
            pictureBoxODIN2.Hide();
            pictureBoxPHANTOM2.Hide();
            pictureBoxSPECTRE2.Hide();
            pictureBoxSTINGER2.Hide();
            pictureBoxVANDAL2.Hide();
        }
        void allhide3()
        {
            pictureBoxARES3.Hide();
            pictureBoxBULLDOG3.Hide();
            pictureBoxFRENZY3.Hide();
            pictureBoxODIN3.Hide();
            pictureBoxPHANTOM3.Hide();
            pictureBoxSPECTRE3.Hide();
            pictureBoxSTINGER3.Hide();
            pictureBoxVANDAL3.Hide();
        }
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //[COMBOBOX2]
            // ARES
            allhide1();
            switch (metroComboBox1.SelectedIndex)
            {
                case 0:
                    pictureBoxARES1.Show();
                    config.max_recoil = 80;
                    config.recoilspeed = 0.75;
                    break;
                case 1:
                    pictureBoxBULLDOG1.Show();
                    config.max_recoil = 35;
                    config.recoilspeed = 1.2;
                    break;
                case 2:
                    pictureBoxFRENZY1.Show();
                    config.max_recoil = 30;
                    config.recoilspeed = 1.5;
                    break;
                case 3:
                    pictureBoxODIN1.Show();
                    config.max_recoil = 90;
                    config.recoilspeed = 0.75;
                    break;
                case 4:
                    pictureBoxPHANTOM1.Show();
                    config.max_recoil = 38;
                    config.recoilspeed = 1.5;
                    break;
                case 5:
                    pictureBoxSPECTRE1.Show();
                    config.max_recoil = 35;
                    config.recoilspeed = 1.5;
                    break;
                case 6:
                    pictureBoxSTINGER1.Show();
                    config.max_recoil = 46;
                    config.recoilspeed = 1.5;
                    break;
                case 7:
                    pictureBoxVANDAL1.Show();
                    config.max_recoil = 45;
                    config.recoilspeed = 1.5;
                    break;

            }
            
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //[COMBOBOX2]
            // ARES
            allhide2();
            switch (metroComboBox2.SelectedIndex)
            {
                case 0:
                    pictureBoxARES2.Show();
                    config.max_recoil = 80;
                    config.recoilspeed = 0.75;
                    break;
                case 1:
                    pictureBoxBULLDOG2.Show();
                    config.max_recoil = 35;
                    config.recoilspeed = 1.2;
                    break;
                case 2:
                    pictureBoxFRENZY2.Show();
                    config.max_recoil = 30;
                    config.recoilspeed = 1.5;
                    break;
                case 3:
                    pictureBoxODIN2.Show();
                    config.max_recoil = 90;
                    config.recoilspeed = 0.75;
                    break;
                case 4:
                    pictureBoxPHANTOM2.Show();
                    config.max_recoil = 38;
                    config.recoilspeed = 1.5;
                    break;
                case 5:
                    pictureBoxSPECTRE2.Show();
                    config.max_recoil = 35;
                    config.recoilspeed = 1.5;
                    break;
                case 6:
                    pictureBoxSTINGER2.Show();
                    config.max_recoil = 46;
                    config.recoilspeed = 1.5;
                    break;
                case 7:
                    pictureBoxVANDAL2.Show();
                    config.max_recoil = 45;
                    config.recoilspeed = 1.5;
                    break;

            }
        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //[COMBOBOX3]
            // ARES
            allhide3();
            switch (metroComboBox3.SelectedIndex)
            {
                case 0:
                    pictureBoxARES3.Show();
                    config.max_recoil = 80;
                    config.recoilspeed = 0.75;
                    break;
                case 1:
                    pictureBoxBULLDOG3.Show();
                    config.max_recoil = 35;
                    config.recoilspeed = 1.2;
                    break;
                case 2:
                    pictureBoxFRENZY3.Show();
                    config.max_recoil = 30;
                    config.recoilspeed = 1.5;
                    break;
                case 3:
                    pictureBoxODIN3.Show();
                    config.max_recoil = 90;
                    config.recoilspeed = 0.75;
                    break;
                case 4:
                    pictureBoxPHANTOM3.Show();
                    config.max_recoil = 38;
                    config.recoilspeed = 1.5;
                    break;
                case 5:
                    pictureBoxSPECTRE3.Show();
                    config.max_recoil = 35;
                    config.recoilspeed = 1.5;
                    break;
                case 6:
                    pictureBoxSTINGER3.Show();
                    config.max_recoil = 46;
                    config.recoilspeed = 1.5;
                    break;
                case 7:
                    pictureBoxVANDAL3.Show();
                    config.max_recoil = 45;
                    config.recoilspeed = 1.5;
                    break;

            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }

            int key = get_key();

            label10.Text = get_name_of_key(key);

            if (key != 0)
                config.weapon1_key = key;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }

            int key = get_key();

            label7.Text = get_name_of_key(key);

            if (key != 0)
                config.weapon2_key = key;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            while (GetAsyncKeyState(1) < 0)
            {
                Thread.Sleep(30);
            }

            int key = get_key();

            label12.Text = get_name_of_key(key);

            if (key != 0)
                config.weapon3_key = key;
        }
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int ArrowKeys);
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        int[] list_characters = new int[] { 1, 2, 5, 6, 9, 16, 17, 18, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };

        int get_key()
        {
            for (int i = 0; i < 500; i++)
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
            return 0;
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(config.weapon1_key) < 0)
            {
                metroCheckBox3.Checked = true;
                metroCheckBox7.Checked = false;
                metroCheckBox4.Checked = false;

                while (GetAsyncKeyState(config.weapon1_key) < 0)
                {
                    Thread.Sleep(30);
                }
            }
            if (GetAsyncKeyState(config.weapon2_key) < 0)
            {
                metroCheckBox3.Checked = false;
                metroCheckBox7.Checked = true;
                metroCheckBox4.Checked = false;

                while (GetAsyncKeyState(config.weapon2_key) < 0)
                {
                    Thread.Sleep(30);
                }
            }
            if (GetAsyncKeyState(config.weapon3_key) < 0)
            {
                metroCheckBox3.Checked = false;
                metroCheckBox7.Checked = false;
                metroCheckBox4.Checked = true;

                while (GetAsyncKeyState(config.weapon3_key) < 0)
                {
                    Thread.Sleep(30);
                }
            }
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }
    }
}
