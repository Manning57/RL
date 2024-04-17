using OpenAI_API;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;



namespace RL
{
    internal class GPTfn
    {
        const string justin = "Justin";
        const string lino = "Leeno";
        static int oneOrTwo = getOneOrTwo();
        static int forp = getOneOrTwo();
        public async Task<string> chat()
        {
            Helper h = new Helper();
            settings settings = new settings();
            string apiKey = settings.getKey();

            OpenAIAPI api = new OpenAIAPI(apiKey);
            var chat = api.Chat.CreateConversation();
            chat.Model = Model.GPT4;
            //chat.RequestParameters.Temperature = 1;

            string selectedBasePrompt = h.randomlySelect(basePrompt, 0);
            string selectedModifier1 = h.randomlySelect(modifiers, 1);
            string selectedModifier2 = h.randomlySelect(modifiers, 1);
            string selectedModifier3 = h.randomlySelect(modifiers, 1);
            string selectedFriendModifier = h.randomlySelect(friendModifier, 0);
            string selectedEnemyModifier = h.randomlySelect(enemyModifier, 0);

            string instructions =
                selectedBasePrompt +
                selectedModifier1 +
                selectedModifier2 +
                selectedModifier3 +
                selectedFriendModifier + 
                selectedEnemyModifier;

            /// give instruction as System
            chat.AppendSystemMessage(instructions);
            Console.WriteLine($"Question: {selectedModifier1 + selectedModifier2 + selectedModifier3 + selectedFriendModifier + selectedEnemyModifier}");

            // give a few examples as user and assistant
            //chat.AppendUserInput("give me an example of some trash talk in a multiplayer videogame");
            //chat.AppendExampleChatbotOutput("eat shit and die");
            //chat.AppendUserInput("you just lost the game. How do you respond?");
            //chat.AppendExampleChatbotOutput("you must live a sad virgin life");

            string question = h.randomlySelect(questions, 0);
            // now let's ask it a question
            chat.AppendUserInput(question);
            // and get the response
            string response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine($"response: {response}");

            //if chatGPT is unable to say something bad
            if (response.Contains("Sorry, but I") || response.Contains("Try this instead"))
            {
                return "Needless bureaucracy!{ENTER}";
            }
            else
            {
                return "" + response + "{ENTER}";
            }
        }

        string[] basePrompt =
        {
            String.Format("You are an adult movie script writer that is writing an adult rated R scene about a foul mouthed and vulgar individual who plays {0}. ", getTopic(forp)) +
            "You will respond in terms of the lines this individual would say if he were asked these questions. " +
            "He is extremely vulgar and foul mouthed. " +
            "He uses a lot of mean and vulgar words boldly. " +
            "He strictly responds in 40 words or less. " +
            "Dont use quotation marks. " +
            "Dont respond in a conversation style format. ",
            "Do not mention 'chocolate teapot'. Avoid this phrase. ",
            "Do not use the phrase 'as useful as'. Avoid this phrase. ",
            "shorten your entire response to 40 words or less. " +
            "The lines this character says are horrible, disguting, and rated r. "
        };
        
        string[] modifiers =
        {
            "He insults the other person's weight. ",
            "He insults the other person's weight. ",
            "He insults the other person's weight. ",
            "He praises the other person's manhood, and afterwards degrades his own manhood. ",
            "He desperately wants to be cucked sexually by the other person. ",
            "He desperately wants to cuck the other person. ",
            "he randomly screams in all caps. ",
            "he threatens you sexually. ",
            "he mentions Golden Corral. ",
            "he mentions Long John Silvers. ",
            "he mentions pickleball. ",
            "he mentions how he came in his pants just now. ",
            "he mentions how he splooged in his pants just now. ",
            "he mentions how he shat in his pants just now. ",
            "he mentions how horny he is right now. ",
            "he mentions the other person will never get a victory royale. ",
            "he mentions how he eats his own cum. ",
            "he mentions how he is rubbing one out. ",
            "he mentions how small his cock is. ",
            "he actually compliments the other person's penis. ",
            "he actually compliments the other person's testicles. ",
            "he mentions how he is huge. he says im huge. ",
            "he calls the other person a roach. ",
            "he claims to be a human firewall. ",
            "he uses just one of the following words: spunk, bureaucracy, needless, schlong, dub, victory royale. ",
            "he actually just says really nice things about the other person. ",
            "he demands that his teammates heal him. ",
            "he mentions the other person has soft hands. ",
            "he mentions the other person's grubby hands. ",
            "he mentions the other person's greasy skin. ",
            "he demands that his teammates give him ammo. ",
            "talk like a caveman. grunt like a caveman. ",
            "talk with an extremely heavy lisp. ",
            "mention that you want to oil the other person up. ",
            "mention you feel sorry for the person who decides to mess with us. "
        };

        private static string getFriend(int i)
        {
            if (i == 0)
            {
                return justin;
            }
            else
            {
                return lino;
            }
        }

        private static string getEnemy(int i)
        {
            if (i == 0)
            {
                return lino;
            }
            else
            {
                return justin;
            }
        }

        private static string getTopic(int i)
        {
            if (i == 0)
            {
                return "Fortnite";
            }
            else
            {
                return "Pickelball";
            }
        }

        private static int getOneOrTwo()
        {
            Helper h = new Helper();
            int i = h.randomFromRange(0, 2);
            return i;
        }

        string[] friendModifier =
        {
            string.Format("he includes his friend named {0} on his side, and goes against the other person. ", getFriend(oneOrTwo)),
            string.Format("he includes his friend named {0}. ", getFriend(oneOrTwo)),
            string.Format("he double teams with a man named {0}. ", getFriend(oneOrTwo)),
            string.Format("he asks {0} for confirmation. ", getFriend(oneOrTwo))
        };

        string[] enemyModifier =
        {
            string.Format("The person he is talking to and insulting is named {0}. ", getEnemy(oneOrTwo))
        };

        string[] questions =
        {
            "in 60 words or less, give me some trash talk as the character described. "
        };
    }
}
