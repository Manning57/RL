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

        public async Task textToSpeech(string s)
        {
            settings settings = new settings();
            string apiKey = settings.getKey();

            OpenAIAPI api = new OpenAIAPI(apiKey);

            var request = new TextToSpeechRequest()
            {
                Input = s,
                ResponseFormat = ResponseFormats.AAC,
                Model = Model.TTS_HD,
                Voice = Voices.Onyx,
                Speed = 1.1
            };
            await api.TextToSpeech.SaveSpeechToFileAsync(request, "C:\\Users\\Lando\\Downloads\\st.mp3");

            static async Task audio1()
            {
                using (var audioFile = new AudioFileReader("C:\\Users\\Lando\\Downloads\\st.mp3"))
                using (var outputDevice = new WaveOutEvent() { DeviceNumber = 1 })
                {
                    outputDevice.Init(audioFile);
                    //outputDevice2.Init(audioFile);
                    outputDevice.Play();
                    //outputDevice2.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000);
                    }
                    outputDevice.Dispose();
                }
            }

            static async Task audio2()
            {
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
            tasks.Add(Task.Run(() => { audio1(); }));
            tasks.Add(Task.Run(() => { audio2(); }));
            Task.WaitAll(tasks.ToArray());

        }
    }
}
