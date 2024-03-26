using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    internal class sentence
    {
        Random random = new Random();

        public string[] st = {
            "You fucking suck!",
            "Eat my ass!",
            "I'm Huge!",
            "Go Beef Go!"
        };

        public string[] nouns = {
            "face",
            "ass",
            "cock",
            "belly",
            "toes"
        };

        public string[] animals = {
            "rhino",
            "dog",
            "gorilla",
            "whale",
            "donkey"
        };

        public string[] adjectives = {
            "unconscious",
            "in disbelief",
            "in shambles",
            "in love",
            "paralized"
        };

        public string[] verbs = {
            "slap",
            "fiddle",
            "torment",
            "attack",
            "stomp"
        };

        public string[] adverbs = {
            "gently",
            "aggressively",
            "viciously",
            "completely",
            "timidly"
        };

        public string[] aggressor = {
            "I'm",
            "Beef is"
        };

        public String randomlySelect(string[] stringArray)
        {
            var choice = random.Next(0, stringArray.Length);
            return stringArray[choice];
        }

        public String formSentence()
        {
            String s = "t" + randomlySelect(aggressor) +
                " gonna " + randomlySelect(adverbs) +
                " " + randomlySelect(verbs) +
                " your " + randomlySelect(nouns) +
                " like a " + randomlySelect(animals) +
                " till you're " + randomlySelect(adjectives) +
                "!{ENTER}";

            return s;
        }

    }
}
