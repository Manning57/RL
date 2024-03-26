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
        public String randomlySelect(string[] stringArray)
        {
            var choice = random.Next(0, stringArray.Length);
            return stringArray[choice];
        }
    }
}
