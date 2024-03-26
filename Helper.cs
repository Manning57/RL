using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    internal class Helper
    {
        Random random = new Random();
        public String randomlySelect(string[] stringArray, int optional)
        {
            if (optional == 1)
            {
                var o = random.Next(0, 2);
                if (o == 0)
                {
                    return "";
                }
            }
            var choice = random.Next(0, stringArray.Length);
            return stringArray[choice];
        }
        public int randomFromRange(int start, int end)
        {
            var choice = random.Next(start, end);
            return choice;
        }
    }
}
