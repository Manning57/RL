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

        public String formSentence()
        {
            Helper h = new Helper();
            String s = "t" + h.randomlySelect(aggressor) +
                " gonna " + h.randomlySelect(adverbs) +
                " " + h.randomlySelect(verbs) +
                " your " + h.randomlySelect(nouns) +
                //" like a " + h.randomlySelect(animals) +
                " till you're " + h.randomlySelect(adjectives) +
                "!{ENTER}";

            return s;
        }

    }
}
