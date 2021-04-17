using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace timetracker
{
    public class ProcessWrapper : IProcess
    {
        public Process Process { get; }

        public ProcessWrapper(Process process)
        {
            Process = process;
        }

        public ProcessWrapper(Process[] processes)
        {
            Process = RetrieveSingleProcessByName(processes);
        }

        public bool IsActive()
        {
            return Process.MainWindowHandle.Equals(GetForegroundWindow());
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        public bool HasExited()
        {
            return Process.HasExited;
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
    }
}
