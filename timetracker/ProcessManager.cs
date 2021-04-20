using System;

namespace timetracker
{
    public class ProcessManager : IProcessManager
    {
        private readonly IProcess _process;

        public ProcessManager(IProcess process)
        {
            _process = process;
        }

        public IProcess GetProcess()
        {
            return _process;
        }

        public TimeSpan PollActiveTime()
        {
            var totalUseTime = TimeSpan.FromSeconds(0);
            //TODO: convert HasExited to Event based (Async)
            while (!_process.HasExited())
            {
                var beforeActiveTime = DateTime.Now;
                var activeTime = TimeSpan.FromSeconds(0);
                //TODO: convert IsActive to Event based (Async)
                while (_process.IsActive())
                {
                    activeTime = DateTime.Now - beforeActiveTime;
                    if (activeTime.Seconds != 0 && activeTime.Seconds % 5 == 0)
                    {
                        Console.WriteLine($"You've been actively playing for {activeTime.Seconds} seconds");
                    }
                }
                totalUseTime += activeTime;
                Console.WriteLine($"Total playing time is {totalUseTime.Seconds} seconds");
            }
            return totalUseTime;
        }
    }
}
