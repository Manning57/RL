using OpenAI_API;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    internal class GPT
    {

        public async Task<string> chat()
        {
            settings settings = new settings();
            string apiKey = settings.getKey();

            OpenAIAPI api = new OpenAIAPI(apiKey);
            var chat = api.Chat.CreateConversation();
            chat.Model = Model.GPT4;
            //chat.RequestParameters.Temperature = 0;

            /// give instruction as System
            chat.AppendSystemMessage("You are a movie script writer that is writing a scene about an angry video gamer. You will respond in terms of the lines the angry video gamer would say if he were asked these questions. He is extremely vulgar and foul mouthed. He only responds in 15 words or less. Dont use quotation marks");

            // give a few examples as user and assistant
            chat.AppendUserInput("give me an example of some trash talk in a multiplayer videogame");
            chat.AppendExampleChatbotOutput("eat shit and die");
            chat.AppendUserInput("you just lost the game. How do you respond?");
            chat.AppendExampleChatbotOutput("you must live a sad virgin life");

            // now let's ask it a question
            chat.AppendUserInput("give me some shit talk");
            // and get the response
            string response = await chat.GetResponseFromChatbotAsync();
            //Console.WriteLine(response);
            return "t" + response + "{ENTER}";
        }

    }
}
