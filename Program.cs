using System.Diagnostics;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RL;
using NAudio.Wave;
using OpenAI_API.Audio;
using OpenAI_API;
using OpenAI_API.Models;
using static OpenAI_API.Audio.TextToSpeechRequest;
using System.IO;


//var s = new Sentence();
//var qc = new QuickChat();
//var gpt = new GPT();
var gpt = new GPTfn();

var proc = Process.GetProcessesByName("Fortnite").FirstOrDefault();
if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
{
    ShowWindow(proc.MainWindowHandle, 1);
    SetForegroundWindow(proc.MainWindowHandle);
}

//SendKeys.SendWait(s.formSentence());
//SendKeys.SendWait(qc.quickChat());
string s = await gpt.chat();
//SendKeys.SendWait(s);

TTS tts = new TTS();
await tts.textToSpeech(s);

[DllImport("user32")]
static extern bool SetForegroundWindow(IntPtr hwnd);
[DllImport("user32")]
static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);



