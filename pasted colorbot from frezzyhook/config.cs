using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using static SkyCheats.Main_Form;
using System.Windows.Forms;

namespace SkyCheats
{
    public class config
    {
        public static string subscription { get; set; }
        public static string expiry { get; set; }
        public static string timeleft { get; set; }
        public static user_data_class user_data = new user_data_class();

        public  class user_data_class
        {
            public  string username { get; set; }
            public string ip { get; set; }
            public  string hwid { get; set; }
            public  string createdate { get; set; }
            public  string lastlogin { get; set; }
            }

        public static string port { get; set; }
        public static bool aimbot_state { get; set; }
        public static bool aimbot_state_checkbox { get; set; }
        public static double smooth { get; set; }
        public static double rcs_smooth { get; set; }

        public static bool aim_color_state { get; set; }
        public static bool triggerbot_state { get; set; }
        public static bool auto_fire_state { get; set; }
        public static bool aim_only_on_x_state { get; set; }
        public static bool smooth_state { get; set; }
        public static bool trigger_force_hs_state { get; set; }
        public static bool ignore_sky_skills { get; set; }
        public static bool bone1_state { get; set; }
        public static bool bone2_state { get; set; }
        
        public static bool recoil_system_state { get; set; }
        public static bool hip_fire_state { get; set; }

        public static int aimbot_on_of_key { get; set; }
        public static int triggerbot_on_of_key { get; set; }
        public static int aim_key { get; set; }
        public static int trigger_key { get; set; }
        public static int bone1_key { get; set; }
        public static int bone2_key { get; set; }
        public static string bone1_target { get; set; }
        public static string bone2_target { get; set; }

        public static string color { get; set; }
        public static int mov_x { get; set; }
        public static int mov_y { get; set; }
        public static int fov_x { get; set; }
        public static int fov_y { get; set; }

        public static int shot_speed { get; set; }
        public static int trigger_speed { get; set; }

        public static int screenWidth { get; set; }
        public static int screenHeight { get; set; }
        public static int extras { get; set; }
        public static int max_recoil { get; set; }
        public static double recoilspeed { get; set; }
        public static int headx { get; set; }
        public static int heady { get; set; }

        public static int bodyx { get; set; }
        public static int bodyy { get; set; }

        public static int uwux { get; set; }
        public static int uwuy { get; set; }

        public static bool bodypartcheckboxselectiontruefalse { get; set; }

        public static string typeoflog { get; set; }
        public static bool checkautofire { get; set; }
        public static string expirylefttime { get; set; }

        public static int weapon1_key { get; set; }
        public static int weapon2_key { get; set; }
        public static int weapon3_key { get; set; }

        public static bool weapon1_state { get; set; }
        public static bool weapon2_state { get; set; }
        public static bool weapon3_state { get; set; }
        public static int weapon1_value { get; set; }
        public static int weapon2_value { get; set; }
        public static int weapon3_value { get; set; }
        public static double weapon1_speed { get; set; }
        public static double weapon2_speed { get; set; }
        public static double weapon3_speed { get; set; }

        public static double sens { get; set; }
        public static double sensitivity_x { get; set; }
        public static double sensitivity_y { get; set; }
        public static int color_int { get; set; }
        public static int silent_key { get; set; }
        public static int flick_key { get; set; }
        public static bool flick_active { get; set; }
        public static bool silent_active { get; set; }
        public static string usernamee { get; set; }
        public static string passwordd { get; set; }

    }
}
