using System;
using System.Collections.Generic;

namespace timetracker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var processTimeLimits = new Dictionary<string, TimeSpan>
            {
                { "MTGA", TimeSpan.FromSeconds(10) }
            };
            var timeTracker = new TimeTracker(processTimeLimits);
            timeTracker.StartTimeTracker(new List<string>(processTimeLimits.Keys));
        }
    }
}
