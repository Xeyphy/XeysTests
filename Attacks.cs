using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{

    class Attacks
    {
        [JsonProperty]
        string name;
        [JsonProperty]
        string type;
        [JsonProperty]
        int atckbonus;
        [JsonProperty]
        int[] atackdmg; //0= [1]d4+3 1 = 1d[4]+3 2= 1d4[+3]

        public Attacks(string name, string type, int atckbonus, int[] atackdmg)
        {
            this.name = name;
            this.atckbonus = atckbonus;
            this.atackdmg = atackdmg;
            this.type = type;
        }

        public void editDamage(int dicecount, int dice, int mod)
        {
            this.atackdmg[0] = dicecount;
            this.atackdmg[1] = dice;
            this.atackdmg[2] = mod;
        }
        public string getName()
        {
            return name;
        }
        public string getType()
        {
            return type;
        }
        public int getBonus()
        {
            return atckbonus;
        }
        public int getDiceCount()
        {
            return atackdmg[0];
        }
        public int getDice()
        {
            return atackdmg[1];
        }
        public int getMod()
        {
            return atackdmg[2];
        }


        public override string ToString()
        {
            return name;
        }

        internal string getDamageString()
        {
            return atackdmg[0] + "D" + atackdmg[1] + " + " + atackdmg[2];
        }
    }
}
