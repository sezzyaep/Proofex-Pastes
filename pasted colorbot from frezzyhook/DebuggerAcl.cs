using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace SkyCheats
{
    internal static class DebuggerAcl
    {
        internal static void SelfDeletea()
        {
            Process.Start(new ProcessStartInfo("cmd.exe",
                    "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del \"" +
                    Assembly.GetExecutingAssembly().Location + "\"")
            {
                WindowStyle = ProcessWindowStyle.Hidden
            })
                ?.Dispose();

            Process.GetCurrentProcess().Kill();
        }
        internal static bool Run()
        {
            while (true)
            {
                Thread.Sleep(3000);
                var returnvalue = false;

                if (Debugger.IsAttached || Debugger.IsLogging())
                {
                    SelfDeletea();
                    System.Environment.Exit(0);
                }
                else
                {
                    var strArray = new string[41]
                    {
                    "codecracker",
                    "x32dbg",
                    "x64dbg",
                    "ollydbg",
                    "ida",
                    "charles",
                    "dnspy",
                    "simpleassembly",
                    "peek",
                    "httpanalyzer",
                    "httpdebug",
                    "fiddler",
                    "wireshark",
                    "dbx",
                    "mdbg",
                    "gdb",
                    "windbg",
                    "dbgclr",
                    "kdb",
                    "kgdb",
                    "mdb",
                    "processhacker",
                    "scylla_x86",
                    "scylla_x64",
                    "scylla",
                    "idau64",
                    "idau",
                    "idaq",
                    "idaq64",
                    "idaw",
                    "idaw64",
                    "idag",
                    "idag64",
                    "ida64",
                    "ida",
                    "ImportREC",
                    "IMMUNITYDEBUGGER",
                    "MegaDumper",
                    "CodeBrowser",
                    "reshacker",
                    "cheat engine"
                    };
                    foreach (var process in Process.GetProcesses())
                        if (process != Process.GetCurrentProcess())
                            for (var index = 0; index < strArray.Length; ++index)
                            {
                                if (process.ProcessName.ToLower().Contains(strArray[index])) returnvalue = true;

                                if (process.MainWindowTitle.ToLower().Contains(strArray[index])) returnvalue = true;
                            }
                }

                if (returnvalue)
                {

                    System.Environment.Exit(0);
                }
            }
            
        }


        private static string ReturnProcessLists()
        {
            var processlist = Process.GetProcesses();

            var myCollection = new List<string>();

            foreach (var theprocess in processlist) myCollection.Add(theprocess.ProcessName);
            return string.Join("|", myCollection.ToArray());
        }
    }
}
