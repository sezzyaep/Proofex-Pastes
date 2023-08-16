using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Loader.Security.AntiProcess
{

        internal class AntiProcessHandler
        {

            private static HashSet<string> BadProcessnameList = new HashSet<string>();
            private static HashSet<string> BadWindowTextList = new HashSet<string>();

            public static void ScanAndKill()
            {
                if (Scan(true) != 0)
                {
                }
            }

            private static int Scan(bool KillProcess)
            {
                int isBadProcess = 0;

                if (BadProcessnameList.Count == 0 && BadWindowTextList.Count == 0)
                {
                    Init();
                }

                Process[] processList = Process.GetProcesses();

                foreach (Process process in processList)
                {
                    if (BadProcessnameList.Contains(process.ProcessName) || BadWindowTextList.Contains(process.MainWindowTitle))
                    {

                        isBadProcess = 1;

                        if (KillProcess)
                        {
                            try
                            {
                                process.Kill();
                            }

                            catch
                            {

                                break;
                            }
                        }

                        break;
                    }
                }

                return isBadProcess;
            }

            private static int Init()
            {
                if (BadProcessnameList.Count > 0 && BadWindowTextList.Count > 0)
                {
                    return 1;
                }

                BadProcessnameList.Add("ollydbg");
                BadProcessnameList.Add("cmd");
                BadProcessnameList.Add("ida64");
                BadProcessnameList.Add("idag");
                BadProcessnameList.Add("idag64");
                BadProcessnameList.Add("idaw");
                BadProcessnameList.Add("idaw64");
                BadProcessnameList.Add("idaq");
                BadProcessnameList.Add("idaq64");
                BadProcessnameList.Add("idau");
                BadProcessnameList.Add("idau64");
                BadProcessnameList.Add("scylla");
                BadProcessnameList.Add("scylla_x64");
                BadProcessnameList.Add("scylla_x86");
                BadProcessnameList.Add("protection_id");
                BadProcessnameList.Add("x64dbg");
                BadProcessnameList.Add("x32dbg");
                BadProcessnameList.Add("windbg");
                BadProcessnameList.Add("reshacker");
                BadProcessnameList.Add("ImportREC");
                BadProcessnameList.Add("IMMUNITYDEBUGGER");
                BadProcessnameList.Add("MegaDumper");
                BadWindowTextList.Add("HTTPDebuggerUI");
                BadWindowTextList.Add("HTTPDebuggerSvc");
                BadWindowTextList.Add("HTTP Debugger");
                BadWindowTextList.Add("HTTP Debugger (32 bit)");
                BadWindowTextList.Add("HTTP Debugger (64 bit)");
                BadWindowTextList.Add("OLLYDBG");
                BadWindowTextList.Add("ida");
                BadWindowTextList.Add("disassembly");
                BadWindowTextList.Add("scylla");
                BadWindowTextList.Add("Debug");
                BadWindowTextList.Add("[CPU");
                BadWindowTextList.Add("Immunity");
                BadWindowTextList.Add("WinDbg");
                BadWindowTextList.Add("x32dbg");
                BadWindowTextList.Add("x64dbg");
                BadWindowTextList.Add("Import reconstructor");
                BadWindowTextList.Add("MegaDumper");
                BadWindowTextList.Add("MegaDumper 1.0 by CodeCracker / SnD");
                BadWindowTextList.Add("cmd");

            return 0;
            }
            public static void KillProcess()
            {
                var strArray = new string[41] { "dnspy", "codecracker", "x32dbg", "x64dbg", "ollydbg", "ida", "charles", "simpleassembly", "peek", "httpanalyzer", "httpdebug", "fiddler", "wireshark", "dbx", "mdbg", "gdb", "windbg", "dbgclr", "kdb", "kgdb", "mdb", "processhacker", "scylla_x86", "scylla_x64", "scylla", "idau64", "idau", "idaq", "idaq64", "idaw", "idaw64", "idag", "idag64", "ida64", "ida", "ImportREC", "IMMUNITYDEBUGGER", "MegaDumper", "CodeBrowser", "reshacker", "cheat engine" };
                foreach (var process in Process.GetProcesses())
                    if (process != Process.GetCurrentProcess())
                        for (var index = 0; index < strArray.Length; ++index)
                        {
                            if (process.ProcessName.ToLower().Contains(strArray[index]))
                            {
                                Environment.Exit(123);
                            }
                            if (process.MainWindowTitle.ToLower().Contains(strArray[index]))
                            {
                                Environment.Exit(0);
                            }
                        }
            }
            public static void Checker()
            {
               KillProcess();
                Scan(true);
            }
            private static unsafe void InitializeProcess()
            {
                var heartbeattask = Task.Factory.StartNew(Checker, new CancellationToken(), TaskCreationOptions.RunContinuationsAsynchronously, TaskScheduler.Current);
            }
        }
    }
