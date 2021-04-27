using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace timetracker
{
    /// <summary>
    /// Means by which a transaction is made.
    /// </summary>
    public class ProcessWrapper : IProcess
    {
        private Process _process;
        
        public ProcessWrapper(Process[] processes)
        {
            _process = RetrieveSingleProcessByName(processes);
        }

        public bool IsActive()
        {
            return _process.MainWindowHandle.Equals(GetForegroundWindow());
        }

        public bool HasExited()
        {
            return _process.HasExited;
        }

        public string GetProcessName()
        {
            return _process.ProcessName;
        }

        private Process RetrieveSingleProcessByName(Process[] processes)
        {
            if (processes.Length < 1)
            {
                return null;
            }
            else if (processes.Length > 1)
            {
                throw new InvalidOperationException($"Multiple processes detected.");
            }
            else
            {
                return processes[0];
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
    }
}
