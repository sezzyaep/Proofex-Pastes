using SkyCheats.LUserControls;
using SkyCheats;
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

namespace SkyCheats.UserControls
{
    
    public partial class UserControl2 : UserControl
    {
        
        public UserControl2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = metroTrackBar1.Value.ToString();
            config.smooth = (Convert.ToDouble(metroTrackBar1.Value) / 100 )/2;
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = metroTrackBar2.Value.ToString(); 
            config.shot_speed = metroTrackBar2.Value;
        }

        private void metroTrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label5.Text = metroTrackBar3.Value.ToString();
            config.trigger_speed = metroTrackBar3.Value ;
        }

        private void metroTrackBar6_Scroll(object sender, ScrollEventArgs e)
        {
            label11.Text = (metroTrackBar6.Value-25).ToString();
            config.headx = metroTrackBar6.Value-25;
            config.uwux = config.headx;
        }

        private void metroTrackBar7_Scroll(object sender, ScrollEventArgs e)
        {
            label13.Text = (metroTrackBar7.Value - 25).ToString();
            config.heady = metroTrackBar7.Value - 25;
            config.uwuy = config.heady;
        }

        private void metroTrackBar5_Scroll(object sender, ScrollEventArgs e)
        {
            label9.Text = (metroTrackBar5.Value - 25).ToString();
            config.bodyx = metroTrackBar5.Value-25;
            config.uwux = config.bodyx;
        }

        private void metroTrackBar4_Scroll(object sender, ScrollEventArgs e)
        {
            label7.Text = (metroTrackBar4.Value - 25).ToString();
            config.bodyy = metroTrackBar4.Value - 25;
            config.uwuy = config.bodyy;
        }

        private void metroTrackBar9_Scroll(object sender, ScrollEventArgs e)
        {
            label17.Text = metroTrackBar9.Value.ToString();
            config.fov_x = metroTrackBar9.Value;
        }

        private void metroTrackBar8_Scroll(object sender, ScrollEventArgs e)
        {
            label15.Text = metroTrackBar8.Value.ToString();
            config.fov_y = metroTrackBar8.Value;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTrackBar10_Scroll(object sender, ScrollEventArgs e)
        {
            config.sens = (Convert.ToDouble(metroTrackBar10.Value) / 100.0) * 2.0;
            label20.Text = Convert.ToString(config.sens);
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            

        }
    }
}
