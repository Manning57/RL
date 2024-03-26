using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    internal class QuickChat
    {
        public string[] st = {
            "Needless bureaucracy",
            "I'm huge",
            "Go Beef go",
            "It's game time",
            "I own a Subway franchise",
            "The Shaqaroni is back"
        };

        public String quickChat()
        {
            Helper h = new Helper();
            String s = "t" + h.randomlySelect(st, 0) + "!{ENTER}";

            return s;
        }
    }
}
