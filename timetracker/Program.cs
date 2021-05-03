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
                { "Game", TimeSpan.FromMinutes(30) }
            };
            var processCategories = new Dictionary<string, string>
            {
                { "MTGA", "Game" },
                { "Solitaire", "Game" }
            };
            var timeTracker = new TimeTracker(processTimeLimits, processCategories);
            timeTracker.StartTimeTracker(new List<string>(processCategories.Keys));
        }
    }
}
