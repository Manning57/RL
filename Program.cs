using System.Diagnostics;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RL;

//var s = new Sentence();
//var qc = new QuickChat();
var gpt = new GPT();

var proc = Process.GetProcessesByName("RocketLeague").FirstOrDefault();
if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
{
    ShowWindow(proc.MainWindowHandle, 1);
    SetForegroundWindow(proc.MainWindowHandle);
}

//SendKeys.SendWait(s.formSentence());
//SendKeys.SendWait(qc.quickChat());
string s = await gpt.chat();
SendKeys.SendWait(s);

[DllImport("user32")]
static extern bool SetForegroundWindow(IntPtr hwnd);
[DllImport("user32")]
static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);



