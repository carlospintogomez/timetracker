using System.Collections.Generic;

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
