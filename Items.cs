using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Items
    {
        [JsonProperty]
        private string name;
        [JsonProperty]
        private int quant;
        [JsonProperty]
        private bool equipd;

        public Items(string name, int quant, bool equipd)
        {
            this.name = name;
            this.quant = quant;
            this.equipd = equipd;
        }

        internal object getName()
        {
            return name;
        }

        internal object getQuant()
        {
            return quant;
        }

        public override string ToString()
        {
            return quant + "   \r" + name;
        }
    }
}
