using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Threading;
using System.Runtime.InteropServices;
using SkyCheats.LUserControls;
using System.IO.Ports;
using System.Collections;
using System.Drawing.Imaging;
using System.Numerics;


namespace SkyCheats
{
    public partial class Main_Form : Form
    {
        static SerialPort serial;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);
        [DllImport("USER32.dll")]
        static extern short GetKeyState(int nVirtKey);

        public static api KeyAuthApp = new api(
           name: "MadValo",
           ownerid: "F0NJmuehem",
           secret: "e9b8b432f97f7a7e6debc808597f497c6a0155ff3628b730246af3b2fc9764e3",
           version: "1.1"
         );

        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int nxDest, int nyDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int nHeight);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        const int SRCCOPY = 0x00CC0020;

        const int CAPTUREBLT = 0x40000000;

        public static List<Color> myList = new List<Color>();
        static List<Color> myListdefault = new List<Color>();
        static public void DoMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public Main_Form()
        {
            InitializeComponent();
        }
        static CDD dd;
        static void LoadDllFile()
        {
            int reta = dd.Load(@"C:/x1.dll");
            if (reta != 1)
            {
                MessageBox.Show("error - L");
                Environment.Exit(0);
            }


            reta = dd.btn(0); //DD Initialize
            if (reta != 1)
            {
                MessageBox.Show("error - I");
                Environment.Exit(0);
            }


            return;
        }

        
        static bool is_colora(Color ada)
        {

            
            if (config.color == "Purple")
            {
                if (ada.G >= 170)
                {
                    return false;
                }
                if (ada.G >= 120)
                {
                    return (ada.R - ada.B) <= 8 && ada.R - ada.G >= 60 && ada.B - ada.G >= 60 && ada.R >= 90 && ada.B >= 170;
                }

                return (ada.R - ada.B) <= 11 && ada.R - ada.G >= 75 && ada.B - ada.G >= 75 && ada.R >= 90 && ada.B >= 170;
            }
            else if (config.color == "Red")
            {

                //return (ada.R - ada.B) <= 60 && ada.R - ada.G <= 60 && ada.B - ada.G <= 20 && ada.R >= 150 && ada.B <= 100 && ada.G <= 100;

                Color _from = Color.FromArgb(160, 0, 0);
                Color to = Color.FromArgb(255, 70, 70);

                return
                  (_from.R <= ada.R && ada.R <= to.R) &&
                  (_from.G <= ada.G && ada.G <= to.G) &&
                  (_from.B <= ada.B && ada.B <= to.B);
            }
            else
            {
                if (ada.R < 200)
                {
                    return false;
                }

                return ada.G > 200 && ada.G < 255 && ada.B > 0 && ada.B < 100;//79
            }


        }
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        static double sens = 0.4;
        static double sensitivity_x = 1.0 / sens / (config.screenWidth / 1920.0) * 1.08;
        static double sensitivity_y = 1.0 / sens / (config.screenHeight / 1080.0) * 1.08;

        static void pixelsearchaim()
        {

            if (config.subscription == "AimbotDriver")
            {

            }
                while (true)
                {
                    Thread.Sleep(1);

                    if (config.aimbot_state && config.bodypartcheckboxselectiontruefalse)
                    {
                        adsadaD();
                    }

                }
        }

        static void asdasdsadasda()
        {
            //while (true)
            //{
            //    Thread.Sleep(10);

            //    if (GetAsyncKeyState(config.silent_key) > 1 && config.silent_active == false)
            //    {
            //        config.silent_active = true;
                    
            //    }
            //    else if (!(GetAsyncKeyState(config.silent_key) > 1) && config.silent_active == true)
            //    {
            //        config.silent_active = false;
            //    }
            //}
        }
        static void vsavsavavsa()
        {
            //while (true)
            //{
            //    Thread.Sleep(10);

            //    if (GetAsyncKeyState(config.flick_key) > 1 && config.flick_active == false)
            //    {
            //        config.flick_active = true;

            //    }
            //    else if (!(GetAsyncKeyState(config.flick_key) > 1) && config.flick_active == true)
            //    {
            //        config.flick_active = false;
            //    }
            //}
        }
        static void asdasdsad()
        {
           
            while (true)
            {
                Thread.Sleep(1);

                

                if (config.checkautofire)
                {
                    config.checkautofire = false;
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    Thread.Sleep(config.shot_speed * 3);
                }

            }
        }
        static DateTime asda = DateTime.Now;
        //Mouse actions

       


        const double size = 60;  // DONT CHANGE
        const int maxCount = 5;
        static void adsadaD()
        {
            try
            {
                

                int w = config.fov_x;
                int h = config.fov_y;
                var objec = screen_shot(new Rectangle(config.screenWidth / 2 - (w / 2) + config.uwux, config.screenHeight / 2 - (h / 2) - config.extras + config.uwuy, w, h));

                for (int y = 1; y < h; y++)
                {
                    // for x = 1 and y = 1 to screen height...
                    for (int x = 1; x < w; x++)
                    {

                        if (is_colora(objec.GetPixel(x, y))) //blue color
                        {

                            x = adsada(x, y, objec);
                            double a;
                            if (config.smooth_state)
                            {
                                a = config.smooth;
                            }
                            else
                            {
                                a = 0.4;
                            }

                            //if (GetAsyncKeyState(config.flick_key) > 1)
                            //{
                            //    if (config.flick_active)
                            //    {
                            //        dd.movR(Convert.ToInt16((x - (w / 2)) * config.sensitivity_x), Convert.ToInt16((y - (h / 2)) * config.sensitivity_y));
                            //        DoMouseClick();
                            //        config.flick_active = false;
                            //        Thread.Sleep(25);
                            //    }
                            //}
                            //else if (GetAsyncKeyState(config.silent_key) > 1)
                            //{
                            //    if (config.silent_active)
                            //    {
                            //        dd.movR(Convert.ToInt16((x - (w / 2)) * config.sensitivity_x), Convert.ToInt16((y - (h / 2)) * config.sensitivity_y));
                            //        DoMouseClick();
                            //        //Thread.Sleep(1);
                            //        dd.movR(Convert.ToInt16((x - (w / 2)) * config.sensitivity_x)*-1, Convert.ToInt16((y - (h / 2)) * config.sensitivity_y)*-1);
                            //        config.silent_active = false;
                            //    }
                            //}
                            
                            if (GetAsyncKeyState(config.aim_key) > 1)
                            {
                                if (config.auto_fire_state)
                                {
                                    double distance = Math.Sqrt(Math.Pow(config.screenWidth / 2 - (config.screenWidth / 2 - (w / 2) + x), 2) + Math.Pow(config.screenHeight / 2 - (config.screenHeight / 2 - (h / 2) + y), 2));
                                    if (distance < 5.0)
                                    {
                                        config.checkautofire = true;

                                    }
                                }

                                if (config.aim_only_on_x_state)
                                {
                                    dd.movR(Convert.ToInt16((x - (w / 2)) * config.sensitivity_x * a), 0);
                                }
                                else
                                {
                                    dd.movR(Convert.ToInt16((x - (w / 2)) * config.sensitivity_x * a), Convert.ToInt16((y - (h / 2)) * config.sensitivity_y * a));
                                }

                            }
                            

                            return;


                        }

                    }
                }
            }
            catch (Exception)
            {

                
            }
            
        }
        static bool check_variant(Color ada, Color uwu, int variant)
        {
            return ada.R + variant > uwu.R && ada.R - variant < uwu.R && ada.G + variant > uwu.G && ada.G - variant < uwu.G && ada.B + variant > uwu.B && ada.B - variant < uwu.B;
        }
        static int adsada(int x, int y, Bitmap objec)
        {
            int total = 0;
            int count = 0;
            int max_count = 25;
            int fmx = x - 10;
            int fmy = y-3;
            //int asdas = 0;
            for (int ya = 0; ya < 5; ya++)
            {
                fmx = x - 10;
                //asdas = 0;
                for (int xa = 0; xa < 15; xa++)
                {
                    //if (asdas > 10 )
                    //{
                    //    break;
                    //}
                    try
                    {
                        if (is_colora(objec.GetPixel(fmx + xa, fmy + ya))) //blue color
                        {
                            total += fmx + xa;
                            count++;
                            //asdas = 0;
                            if (count >= max_count)
                            {
                                return total / count;
                            }


                        }
                        //else
                        //{
                        //    asdas++;
                        //}
                    }
                    catch (Exception)
                    {

                        break;
                    }


                }
            }
            if (count != 0)
            {
                return total / count;
            }
            return x;
        }
        static void trig()
        {
            while (true)
            {
                if (config.triggerbot_state && GetAsyncKeyState(config.trigger_key) > 0)
                {
                    if (config.trigger_force_hs_state)
                    {
                        aaaaa();
                    }
                    else
                    {
                        aaaa();
                    }
                }
                Thread.Sleep(3);

            }
        }
        static void aaaaa()
        {
            int w = 50;
            int h = 50;
            
            try
            {
                var objec = screen_shot(new Rectangle(config.screenWidth / 2 - (w / 2) + config.uwux, config.screenHeight / 2 - (h / 2) - config.extras + config.uwuy, w, h));


                for (int y = 1; y < h; y++)
                {
                    // for x = 1 and y = 1 to screen height...
                    for (int x = 1; x < w; x++)
                    {
                        if (is_colora(objec.GetPixel(x, y))) //blue color
                        {
                            x = adsada(x, y, objec);


                            double distance = Math.Sqrt(Math.Pow((config.screenWidth / 2) - ((config.screenWidth / 2) - (w / 2) + x), 2) + Math.Pow((config.screenHeight / 2) - ((config.screenHeight / 2) - (h / 2) + y), 2));
                            if (distance < 5.0)
                            {
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                Thread.Sleep(config.trigger_speed * 3);
                                return;

                            }


                        }

                    }
                }
            }
            catch (Exception)
            {


            }
            
        }
        static void aaaa(){
            int h = 8;
            int w = 8;

            try
            {
                var objec = screen_shot(new Rectangle(config.screenWidth / 2 - (w / 2), config.screenHeight / 2 - (h / 2), w, h));

                for (int y = 1; y < h; y++)
                {
                    // for x = 1 and y = 1 to screen height...
                    for (int x = 1; x < w; x++)
                    {
                        if (is_colora(objec.GetPixel(x, y))) //blue color
                        {
                            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            Thread.Sleep(config.trigger_speed * 3);
                            return;

                        }

                    }
                }
            }
            catch (Exception)
            {


            }
            
                
            
        }
        static void ada()
        {
            bool aimdown = false;
            bool aimpress = false;

            DateTime _lastTime = DateTime.Now;
            config.max_recoil = 45;
            config.recoilspeed = 1.5;
            while (true)
            {
                Thread.Sleep(1);
                
                if (config.bodypartcheckboxselectiontruefalse && config.recoil_system_state && GetAsyncKeyState(1) > 0 && aimdown == false && aimpress == false)
                {
                    aimdown = true;
                    _lastTime = DateTime.Now;
                }
                else if (config.bodypartcheckboxselectiontruefalse && config.recoil_system_state && GetAsyncKeyState(1) > 0 && ((aimdown == true && aimpress == false) ||(aimdown == false && aimpress == true)))
                {
                    
                    double recoilms = (DateTime.Now - _lastTime).TotalMilliseconds;
                    config.extras = Convert.ToInt16((config.max_recoil * (config.screenHeight / 1080.0) * (recoilms / 1080.0)) * config.recoilspeed);
                    if (config.extras > config.max_recoil)
                    {
                        config.extras = config.max_recoil;
                    }
                    aimdown = false;
                    aimpress = true;
                }
                else
                {
                    aimdown = false;
                    aimpress = false;
                    config.extras = 0;

                }
            }

        }
         void getscreensiz()
        {
            while (true)
            {

                

                config.screenWidth = Screen.PrimaryScreen.Bounds.Width;
                config.screenHeight = Screen.PrimaryScreen.Bounds.Height;

                config.sensitivity_x = 1.0 / config.sens / (config.screenWidth / 1920.0) * 1.05;
                config.sensitivity_y = 1.0 / config.sens / (config.screenHeight / 1080.0) * 1.05;

                Thread.Sleep(1000);
            }
        }
        static void checkactivewindow()
        {
            while (true)
            {
                if (config.aimbot_state_checkbox)
                {
                    if (GetActiveWindowTitle() == "VALORANT  ")
                    {
                        config.aimbot_state = true;
                    }
                    else
                    {
                        config.aimbot_state = false;
                    }
                }
               
                Thread.Sleep(50);
            }
        }

        static public Bitmap screen_shot(Rectangle region)
        {
            IntPtr desktophWnd;
            IntPtr desktopDc;
            IntPtr memoryDc;
            IntPtr bitmap;
            IntPtr oldBitmap;
            bool success;
            Bitmap result;

            desktophWnd = GetDesktopWindow();
            desktopDc = GetWindowDC(desktophWnd);
            memoryDc = CreateCompatibleDC(desktopDc);
            bitmap = CreateCompatibleBitmap(desktopDc, region.Width, region.Height);
            oldBitmap = SelectObject(memoryDc, bitmap);

            success = BitBlt(memoryDc, 0, 0, region.Width, region.Height, desktopDc, region.Left, region.Top, SRCCOPY | CAPTUREBLT);

            try
            {
                if (!success)
                {
                    throw new Win32Exception();
                }

                result = Image.FromHbitmap(bitmap);
            }
            finally
            {
                SelectObject(memoryDc, oldBitmap);
                DeleteObject(bitmap);
                DeleteDC(memoryDc);
                ReleaseDC(desktophWnd, desktopDc);
            }

            return result;
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {

            config.headx = -1;
            config.heady = -3;
            config.fov_x = 144;
            config.fov_y = 50;
            config.screenWidth = Screen.PrimaryScreen.Bounds.Width;
            config.screenHeight = Screen.PrimaryScreen.Bounds.Height;
            config.shot_speed = 50;
            config.trigger_speed = 50;
            config.smooth = 0.125;
            config.silent_active = true;
            config.flick_active = true;
            config.aimbot_state_checkbox = true;


            config.aim_key = 1;
            config.flick_key = 180;
            config.silent_key = 180;
            config.smooth_state = true;

            config.bone1_state = true;
            config.bodypartcheckboxselectiontruefalse = true;
            config.uwux = -1;
            config.uwuy = -5;

            config.smooth = (Convert.ToDouble(50    ) / 100) / 2;
            config.sens = (Convert.ToDouble(30) / 100.0) * 2.0;



            myList.Add(Color.FromArgb(255, 117, 56, 140));
            myList.Add(Color.FromArgb(255, 143, 77, 146));
            myList.Add(Color.FromArgb(255, 111, 46, 107));
            myList.Add(Color.FromArgb(255, 163, 82, 142));
            myList.Add(Color.FromArgb(255, 123, 62, 160));
            myList.Add(Color.FromArgb(255, 144, 78, 169));
            myList.Add(Color.FromArgb(255, 164, 92, 162));
            myList.Add(Color.FromArgb(255, 186, 106, 169));
            myList.Add(Color.FromArgb(255, 110, 36, 142));
            myList.Add(Color.FromArgb(255, 140, 72, 196));
            myList.Add(Color.FromArgb(255, 114, 0, 157));
            myList.Add(Color.FromArgb(255, 124, 39, 163));
            myList.Add(Color.FromArgb(255, 179, 107, 20));
            myList.Add(Color.FromArgb(255, 147, 76, 216));
            myList.Add(Color.FromArgb(255, 132, 57, 120));
            myList.Add(Color.FromArgb(255, 110, 7, 133));
            myList.Add(Color.FromArgb(255, 130, 35, 137));
            myList.Add(Color.FromArgb(255, 155, 50, 134));
            myList.Add(Color.FromArgb(255, 161, 88, 196));
            myList.Add(Color.FromArgb(255, 112, 50, 192));
            myList.Add(Color.FromArgb(255, 119, 54, 213));
            myList.Add(Color.FromArgb(255, 146, 51, 157));
            myList.Add(Color.FromArgb(255, 166, 61, 162));
            myList.Add(Color.FromArgb(255, 110, 26, 104));
            myList.Add(Color.FromArgb(255, 146, 26, 159));
            myList.Add(Color.FromArgb(255, 136, 37, 114));
            myList.Add(Color.FromArgb(255, 186, 65, 163));
            myList.Add(Color.FromArgb(255, 166, 38, 159));
            myList.Add(Color.FromArgb(255, 157, 0, 162));
            myList.Add(Color.FromArgb(255, 178, 56, 190));
            myList.Add(Color.FromArgb(255, 114, 29, 185));
            myList.Add(Color.FromArgb(255, 146, 51, 177));
            myList.Add(Color.FromArgb(255, 139, 45, 197));
            myList.Add(Color.FromArgb(255, 199, 74, 194));
            myList.Add(Color.FromArgb(255, 137, 22, 185));
            myList.Add(Color.FromArgb(255, 207, 94, 182));
            myList.Add(Color.FromArgb(255, 196, 56, 233));
            myList.Add(Color.FromArgb(255, 127, 2, 187));
            myList.Add(Color.FromArgb(255, 145, 7, 211));
            myList.Add(Color.FromArgb(255, 50, 45, 122));

            //default
            myListdefault.Add(Color.FromArgb(255, 254, 172, 244));
            myListdefault.Add(Color.FromArgb(255, 255, 168, 233));
            myListdefault.Add(Color.FromArgb(255, 175, 106, 23));
            myListdefault.Add(Color.FromArgb(255, 255, 185, 251));

            Label_User_Panel.Text = config.user_data.username;
            Label2_Top_Panel.Text = config.expirylefttime;

            if (config.subscription == "AimbotDriver")
            {

            }
            dd = new CDD();
            LoadDllFile();



            Thread threada = new Thread(pixelsearchaim);
            Thread asdsadas = new Thread(asdasdsad);
            Thread threadaaaa = new Thread(ada);
            Thread threadaa = new Thread(getscreensiz);
            Thread threadaaa = new Thread(checkactivewindow);
            Thread threadaaaasdas = new Thread(trig);
            Thread threaas = new Thread(asdasdsadasda);
            Thread sadadas = new Thread(vsavsavavsa);
            Thread asdsadsadsa = new Thread(sadasda);
            asdsadsadsa.Start();
            threadaa.Start();
            sadadas.Start();
            threaas.Start();
            threadaaaasdas.Start();
            threadaaa.Start();
            threadaaaa.Start();
            asdsadas.Start();

            threada.Start();
            

            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();

            userControl11.Show();
            userControl11.BringToFront();
        }
        public static void sadasda()
        {
            //KeyAuthApp.init();
            //while (true)
            //{
            //    try
            //    {
            //        KeyAuthApp.login(config.usernamee, config.passwordd);
            //        if (KeyAuthApp.response.success)
            //        {

            //        }
            //        else
            //        {
            //            Environment.Exit(0);
            //        }
                    
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    Thread.Sleep(5000);

            //}
        }
        private void Button_Button_Panel_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();

            userControl11.Show();
            userControl11.BringToFront();
        }

        private void Button2_Button_Panel_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();

            userControl21.Show();
            userControl21.BringToFront();
        }

        private void Button3_Button_Panel_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl11.Hide();
            userControl41.Hide();
            userControl51.Hide();

            userControl31.Show();
            userControl31.BringToFront();
        }

        private void Button4_Button_Panel_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Hide();
            userControl11.Hide();
            userControl51.Hide();

            userControl41.Show();
            userControl41.BringToFront();
        }

        private void Button5_Button_Panel_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl11.Hide();

            userControl51.Show();
            userControl51.BringToFront();
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

        private void Icon2_Top_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Grip == true)
            {
                this.Left = Cursor.Position.X - MouseX;
                this.Top = Cursor.Position.Y - MouseY;
            }
        }

        private void Icon2_Top_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            Grip = false;
            MouseX = 0;
            MouseY = 0;
        }

        private void Icon2_Top_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Grip = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void Icon_Top_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Grip == true)
            {
                this.Left = Cursor.Position.X - MouseX;
                this.Top = Cursor.Position.Y - MouseY;
            }
        }

        private void Icon_Top_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            Grip = false;
            MouseX = 0;
            MouseY = 0;
        }

        private void Icon_Top_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Grip = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void Label_Top_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Grip == true)
            {
                this.Left = Cursor.Position.X - MouseX;
                this.Top = Cursor.Position.Y - MouseY;
            }
        }

        private void Label_Top_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            Grip = false;
            MouseX = 0;
            MouseY = 0;
        }

        private void Label_Top_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Grip = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void Button_Top_Panel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button2_Top_Panel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Top_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void userControl51_Load(object sender, EventArgs e)
        {

        }

        private void Button_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Icon_Top_Panel_Click(object sender, EventArgs e)
        {

        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void Picture_Button_Panel_Click(object sender, EventArgs e)
        {

        }

        private void Label_Top_Panel_Click(object sender, EventArgs e)
        {

        }

        private void userControl41_Load(object sender, EventArgs e)
        {

        }

        private void Icon2_Top_Panel_Click(object sender, EventArgs e)
        {

        }

        private void User_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Icon_User_Panel_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Top_Panel_Click(object sender, EventArgs e)
        {
            
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void Picture_Top_Panel_Click(object sender, EventArgs e)
        {

        }

        private void Label_User_Panel_Click(object sender, EventArgs e)
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
