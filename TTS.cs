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

            using (var audioFile = new AudioFileReader("C:\\Users\\Lando\\Downloads\\st.mp3"))
            using (var outputDevice = new WaveOutEvent() { DeviceNumber = 0 })
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
                outputDevice.Dispose();
                audioFile.Dispose();
            }

        }
    }
}
