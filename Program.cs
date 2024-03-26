using System.Diagnostics;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RL;

var s = new sentence();

var proc = Process.GetProcessesByName("RocketLeague").FirstOrDefault();
if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
    SetForegroundWindow(proc.MainWindowHandle);

SendKeys.SendWait(s.formSentence());

[DllImport("user32")]
static extern bool SetForegroundWindow(IntPtr hwnd);


