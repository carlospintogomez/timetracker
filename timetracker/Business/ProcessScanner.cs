using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace timetracker
{
    public class ProcessScanner
    {
        public event EventHandler<ProcessFoundEventArgs> ProcessFound;
        private List<string> _processesToScan;

        public ProcessScanner(List<string> processesToScan)
        {
            _processesToScan = processesToScan;
        }

        public void ScanProcesses()
        {
            while (true)
            {
                foreach (var processToWatch in _processesToScan)
                {
                    var processes = Process.GetProcessesByName(processToWatch);
                    if (processes.Length < 1)
                    {
                        continue;
                    }
                    foreach (var process in processes)
                    {
                        var ProcessFoundEventArgs = new ProcessFoundEventArgs
                        {
                            ProcessWrapper = new ProcessWrapper(process)
                        };
                        OnProcessFound(ProcessFoundEventArgs);
                    }
                    System.Threading.Thread.Sleep(5000);
                }
                System.Threading.Thread.Sleep(5000);
            }
        }
        
        private void OnProcessFound(ProcessFoundEventArgs e)
        {
            ProcessFound?.Invoke(this, e);
        }
    }
}
