using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    internal class JL
    {
        const string justin = "Justin";
        const string lino = "Lino";

        public string getJL()
        {
            Helper h = new Helper();
            int i = h.randomFromRange(0, 2);
            if (i == 0)
            {
                return justin;
            } else
            {
                return lino;
            }
        }
    }
}
