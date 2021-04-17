using System;

namespace timetracker
{
    public class ProcessManager : IProcessManager
    {
        public IProcess Process { get; }

        public ProcessManager(IProcess process)
        {
            Process = process;
        }

        public TimeSpan ComputeActiveTime()
        {
            var totalUseTime = TimeSpan.FromSeconds(0);
            while (!Process.HasExited())
            {
                var beforeActiveTime = DateTime.Now;
                var activeTime = TimeSpan.FromSeconds(0);
                //TODO: convert IsActive to Event based (Async)
                while (Process.IsActive())
                {
                    activeTime = DateTime.Now - beforeActiveTime;
                    if (activeTime.Seconds != 0 && activeTime.Seconds % 5 == 0)
                    {
                        Console.WriteLine($"You've been actively playing for {activeTime.Seconds} seconds");
                    }
                }
                totalUseTime += activeTime;
                Console.WriteLine($"Total playing time is {totalUseTime.Seconds} seconds");
                //TODO: convert HasExited to Event based (Async)
            }
            return totalUseTime;
        }
    }
}
