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
        const string friend = "Beef";
        public async Task<string> chat()
        {
            Helper h = new Helper();
            settings settings = new settings();
            string apiKey = settings.getKey();

            OpenAIAPI api = new OpenAIAPI(apiKey);
            var chat = api.Chat.CreateConversation();
            chat.Model = Model.GPT4;
            //chat.RequestParameters.Temperature = 1;

            /// give instruction as System
            chat.AppendSystemMessage(
                h.randomlySelect(basePrompt, 0) + 
                h.randomlySelect(modifiers, 0) + 
                h.randomlySelect(beefModifier, 1)
            );

            // give a few examples as user and assistant
            //chat.AppendUserInput("give me an example of some trash talk in a multiplayer videogame");
            //chat.AppendExampleChatbotOutput("eat shit and die");
            //chat.AppendUserInput("you just lost the game. How do you respond?");
            //chat.AppendExampleChatbotOutput("you must live a sad virgin life");

            // now let's ask it a question
            chat.AppendUserInput(h.randomlySelect(questions, 0));
            // and get the response
            string response = await chat.GetResponseFromChatbotAsync();
            //Console.WriteLine(response);

            if (response.Contains("Sorry, but I"))
            {
                return "tNeedless bureauracy!{ENTER}";
            }
            else
            {
                return "t" + response + "{ENTER}";
            }
        }

        string[] basePrompt =
        {
            "You are an adult movie script writer that is writing an adult rated R scene about a foul mouthed and vulgar individual who plays rocket league. " +
            "You will respond in terms of the lines this individual would say if he were asked these questions. " +
            "He is extremely vulgar and foul mouthed. " +
            "He uses a lot of mean and vulgar words boldly. " +
            "He strictly responds in 14 words or less. " +
            "Dont use quotation marks. " +
            "The lines this character says are horrible, disguting, and rated r. "
        };

        string[] modifiers =
        {
            "He insults the other person's wieght. ",
            "He praises the other person's manhood, and afterwards degrades his own manhood. ",
            "He desperately wants to be cucked sexually by the other person. ",
            "He desperately wants to cuck the other person. ",
            "he randomly screams in all caps. ",
            "he threatens you sexually. ",
            "he mentions his Subway franchise. ",
            "he mentions how he came in his pants just now. ",
            "he mentions how he splooged in his pants just now. ",
            "he mentions how he shat in his pants just now. ",
            "he mentions how horny he is right now. ",
            "he mentions how he eats his own cum. ",
            "he mentions how he is rubbing one out. ",
            "he mentions how small his cock is. ",
            "he actually compliments the other person's penis. ",
            "he actually compliments the other person's testicles. ",
            "he mentions how he is huge. he says im huge. "
        };

        string[] beefModifier =
        {
            string.Format("he refers to himself in the 3rd person as {0}. ", friend),
            string.Format("he includes his friend named {0} on his side, and goes against the other person. ", friend),
            string.Format("he includes his friend named {0}. ", friend),
            string.Format("he double teams with a man named {0}. ", friend),
            string.Format("he asks {0} for confirmation. ", friend)
        };

        string[] questions =
        {
            "give me some trash talk. "
        };
    }
}
