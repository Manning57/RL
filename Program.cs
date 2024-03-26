using System.Diagnostics;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

string[] st = {
    "You fucking suck!",
    "Eat my ass!",
    "I'm Huge!",
    "Go Beef Go!"
};

var proc = Process.GetProcessesByName("RocketLeague").FirstOrDefault();
if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
    SetForegroundWindow(proc.MainWindowHandle);

var random = new Random();
var r = random.Next(0, st.Length);

SendKeys.SendWait("t" + st[r] + "{ENTER}");

[DllImport("user32")]
static extern bool SetForegroundWindow(IntPtr hwnd);


