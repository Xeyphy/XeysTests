using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Skills
    {
        
        public string name;
        public int value;
        public bool prof;
        public int extra;


        public Skills(string name, int value,bool prof)
        {
            this.name = name ?? "Perception";
            this.value = value;
            this.prof = prof;
            this.extra = 0;
        }

        public override string ToString()
        {
            return name + " " + value + " | " + prof.ToString();
        }


    }
}
