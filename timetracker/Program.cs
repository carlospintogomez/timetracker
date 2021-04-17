using System;
using System.Diagnostics;

namespace timetracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] processesToMonitor = new string[] { "MTGA" };
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
                    var activeTime = processManager.ComputeActiveTime();
                    var processSession = new ProcessSession(processManager);
                    processSession.SaveActiveTime(processToMonitor);
                }
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
