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
        
        public ProcessWrapper(Process process)
        {
            _process = process;
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

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
    }
}
