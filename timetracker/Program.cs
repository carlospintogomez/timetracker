using System;
using System.Diagnostics;

namespace timetracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] processesToMonitor = new string[] { "MTGA" };
            var sessionLog = new SessionLog();
            while (true)
            {
                Console.WriteLine("Scanning for processes...");
                foreach (var processToMonitor in processesToMonitor)
                {
                    var processes = Process.GetProcessesByName(processToMonitor);
                    var processWrapper = new ProcessWrapper(processes);
                    if (processWrapper.Process == null)
                    {
                        continue;
                    }
                    Console.WriteLine($"Process {processToMonitor} is now active. Recording...");
                    var processManager = new ProcessManager(processWrapper);
                    var processSession = new ProcessSession(processManager.GetProcess().GetProcessName());
                    var processActiveTime = processManager.ComputeActiveTime();
                    processSession.SaveActiveTime(processActiveTime);
                    var sessionManager = new SessionManager(processSession);
                    sessionLog.PersistSession(sessionManager);
                }
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
