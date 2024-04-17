using NAudio.Wave;
using OpenAI_API;
using OpenAI_API.Audio;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OpenAI_API.Audio.TextToSpeechRequest;
using static System.Windows.Forms.LinkLabel;



namespace RL
{
    internal class TTS
    {
        String[] voices =
        {
            "alloy",
            "echo",
            "fable",
            "onyx",
            "nova",
            "shimmer"
        };

        public async Task textToSpeech(string s)
        {
            settings settings = new settings();
            string apiKey = settings.getKey();

            OpenAIAPI api = new OpenAIAPI(apiKey);

            Random random = new Random();
            int v = random.Next(0, voices.Length);

            var request = new TextToSpeechRequest()
            {
                Input = s,
                ResponseFormat = ResponseFormats.MP3,
                Model = Model.TTS_HD,
                Voice = voices[v],
                Speed = 1.03
            };
            await api.TextToSpeech.SaveSpeechToFileAsync(request, "C:\\Users\\Lando\\Downloads\\st.mp3");

            static async Task playThroughMic()
            {
                using (var audioFile = new AudioFileReader("C:\\Users\\Lando\\Downloads\\st.mp3"))
                using (var outputDevice = new WaveOutEvent() { DeviceNumber = 1 })
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                    outputDevice.Dispose();
                }
            }

            static async Task playThroughSpeaker()
            {
                //headset 0
                //mic 1
                //speaker 2
                using (var audioFile = new AudioFileReader("C:\\Users\\Lando\\Downloads\\st.mp3"))
                using (var outputDevice2 = new WaveOutEvent() { DeviceNumber = 0 })

                {
                    outputDevice2.Init(audioFile);
                    outputDevice2.Play();
                    while (outputDevice2.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                    outputDevice2.Dispose();
                }
            }

            //audioFile.Dispose();

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => { playThroughSpeaker(); }));
            tasks.Add(Task.Run(() => { playThroughMic(); }));
            Task.WaitAll(tasks.ToArray());

        }
    }
}
