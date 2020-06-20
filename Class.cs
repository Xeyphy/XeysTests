using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Class
    {
        [JsonProperty]
        int level;
        [JsonProperty]
        int hitdie;
        [JsonProperty]
        int currentHitDie;
        [JsonProperty]
        string classname;
        [JsonProperty]
        string subclass;
        

        public Class(int level, int hitdie, string classname, string subclass, int currenthitdie)
        {
            this.level = level;
            this.hitdie = hitdie;
            this.classname = classname;
            this.subclass = subclass;
            this.currentHitDie = currenthitdie;
            
        }
        public int getLevel()
        {
            return level;
        }
        public string getName()
        {
            return classname;
        }

        public override string ToString()
        {
            return currentHitDie + " / " + level + " | D" + hitdie;
        }

    }
}
