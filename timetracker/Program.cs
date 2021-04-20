using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace timetracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] processesToMonitor = new string[] { "MTGA" };
            var sessionLog = new SessionLog();
            //if (File.Exists("session_log.json"))
            //{
            //    sessionLog = (SessionLog)JsonConvert.DeserializeObject(File.ReadAllText("session_log.json"));
            //}
            var timelimits = new Dictionary<string, TimeSpan>();
            timelimits.Add("MTGA", TimeSpan.FromMinutes(0.25));
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
                    var processActiveTime = processManager.PollActiveTime();
                    var processSession = new ProcessSession
                    {
                        SessionName = processManager.GetProcess().GetProcessName(),
                        ActiveTime = processActiveTime,
                        EndTime = DateTime.Now
                    };
                    Console.WriteLine("Process Total Active Time: " + processSession.ActiveTime);
                    sessionLog.SquashSession(DateTime.Today.ToShortDateString(), processSession);
                    
                    // TODO: this needs be inside ProcessWatcher
                    if (sessionLog.Entries[DateTime.Today.ToShortDateString()].GetActiveTime() > timelimits[processToMonitor])
                    {
                        Console.WriteLine("BOY STOP PLAYING...");
                    }

                    // Persisting
                    var json = JsonConvert.SerializeObject(sessionLog);
                    Console.WriteLine(json);
                    File.WriteAllText("session_log.json", json);
                }
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
