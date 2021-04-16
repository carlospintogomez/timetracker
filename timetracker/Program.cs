using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
                    ReturnTotalUserProcessorTime(processToMonitor);
                }
                System.Threading.Thread.Sleep(5000);
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        public static IntPtr GetForegroundWindowWrapper()
        {
            return GetForegroundWindow();
        }

        public static void ReturnTotalUserProcessorTime(string processName)
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(processName);
            if (processes.Length > 1)
            {
                throw new InvalidOperationException($"Multiple processes with name {processName} detected.");
            }
            else
            {
                var process = processes[0];
                var totalUseTime = TimeSpan.FromSeconds(0);
                do
                {
                    var beforeActiveTime = DateTime.Now;
                    var activeTime = TimeSpan.FromSeconds(0);
                    while (process.MainWindowHandle.Equals(GetForegroundWindowWrapper()))
                    {
                        activeTime = DateTime.Now - beforeActiveTime;
                        Console.WriteLine("a: " + activeTime);
                    }
                    totalUseTime += activeTime;
                    Console.WriteLine("t: "+ totalUseTime);
                } while (!process.HasExited);
            }
        }
    }
}
