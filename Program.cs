﻿using System.Diagnostics;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RL;

var s = new Sentence();
//var qc = new QuickChat();

var proc = Process.GetProcessesByName("RocketLeague").FirstOrDefault();
if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
    SetForegroundWindow(proc.MainWindowHandle);

SendKeys.SendWait(s.formSentence());
//SendKeys.SendWait(qc.quickChat());

[DllImport("user32")]
static extern bool SetForegroundWindow(IntPtr hwnd);


