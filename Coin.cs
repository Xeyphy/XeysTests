using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Coin
    {
        [JsonProperty]
        string type;
        [JsonProperty]
        int amount;

        public Coin(string type, int amount)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.amount = amount;
        }

        internal string getName()
        {
            return type;
        }

        internal int getValue()
        {
            return amount;
        }
    }
}
