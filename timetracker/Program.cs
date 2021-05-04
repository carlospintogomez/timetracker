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
                { "Game", TimeSpan.FromMinutes(0.25) },
                { "Side Project", TimeSpan.FromMinutes(0.25) },
                { "Browsing", TimeSpan.FromMinutes(0.25) }
            };
            var processCategories = new Dictionary<string, string>
            {
                { "MTGA", "Game" },
                { "devenv", "Side Project" },
                {"gener8", "Browsing" }
            };
            var timeTracker = new TimeTracker(processTimeLimits, processCategories);
            timeTracker.StartTimeTracker(new List<string>(processCategories.Keys));
        }
    }
}
