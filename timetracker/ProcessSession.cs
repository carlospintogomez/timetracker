using System;
using System.Collections.Generic;

namespace timetracker
{
    public class ProcessSession : IProcessSession
    {
        private IProcessManager _processManager;

        public Dictionary<string, TimeSpan> TimeLogDictionary { get; }

        public ProcessSession(IProcessManager processManager)
        {
            _processManager = processManager;
            TimeLogDictionary = new Dictionary<string, TimeSpan>();
        }

        public void SaveActiveTime(string processName)
        {
            var processActiveTime = _processManager.ComputeActiveTime();
            if (TimeLogDictionary.ContainsKey(processName))
            {
                TimeLogDictionary[processName] += processActiveTime;
            }
            else
            {
                TimeLogDictionary.Add(processName, processActiveTime);
            }
            Console.WriteLine("Process Total Active Time: " + TimeLogDictionary[processName]);
        }
    }
}
