using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    internal class Sentence
    {
        public string[] nouns = {
            "face",
            "ass",
            "cock",
            "balls",
            "toes",
            "cheeks",
            "holes",
            "mouth"
        };

        public string[] animals = {
            "rhino",
            "dog",
            "gorilla",
            "whale",
            "donkey"
        };

        public string[] iOrYouStates = {
            "throw up",
            "splooge",
            "cry",
            "give up",
            "uninstall",
            "apologize"
        };

        public string[] iOrYouStates2 = {
            "unconscious",
            "in disbelief",
            "in shambles",
            "in love",
            "paralized",
            "sorry"
        };

        public string[] verbs = {
            "slap",
            "fiddle",
            "torment",
            "attack",
            "stomp",
            "shit on",
            "sit and spin on"
        };

        public string[] adverbs = {
            "gently ",
            "aggressively ",
            "viciously ",
            "completely ",
            "timidly ",
            "kind of just "
        };

        public string[] aggressor = {
            "I'm",
            "Beef is"
        };

        public string[] iOrYou = {
            "I",
            "you"
        };

        public string[] iOrYou2 = {
            "i'm",
            "you're"
        };

        public string[] endings = {
            ", bitch",
            ", weeb",
            ", bub",
            ", bud",
            ", buddy",
            ", chump"
        };

        public string vary()
        {
            Helper h = new Helper();
            var x = h.randomFromRange(0, 2);
            string s = "";
            if (x == 0)
            {
                s =" till " + h.randomlySelect(iOrYou, 0) +
                " " + h.randomlySelect(iOrYouStates, 0);
            } 
            else
            {
                s =" till " + h.randomlySelect(iOrYou2, 0) +
                " " + h.randomlySelect(iOrYouStates2, 0);
            }
            return s;
        }


        public String formSentence()
        {
            Helper h = new Helper();

            String s = "t" + h.randomlySelect(aggressor, 0) +
                " gonna " + h.randomlySelect(adverbs, 1) +
                h.randomlySelect(verbs, 0) +
                " your " + h.randomlySelect(nouns, 0) +
                //" like a " + h.randomlySelect(animals) +
                vary() + 
                h.randomlySelect(endings, 1) +
                "!{ENTER}";

            return s;
        }

    }
}
