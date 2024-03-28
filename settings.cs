using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    internal class settings
    {
        private const string apiKey = "<your api key here>";
        const bool DBStore = false;
        public string getKey()
        {
            return apiKey;
        }
        public bool getDBStore()
        {
            return DBStore;
        }
    }
}
