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
            List<string> processesToWatch = new List<string> { "MTGA" };
            var timeTracker = new TimeTracker();
            timeTracker.StartTimeTracker(processesToWatch);
        }
    }
}
