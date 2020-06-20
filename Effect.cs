using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Effect
    {
        public bool active;
        public int mod;
        public Character chr;

        

        public Effect(Character chr, int mod)
        {
            this.active = false;
            this.chr = chr;
            this.mod = mod;
        }

        public virtual void activate()
        {
            if (active) return;
            active = true;

        }

       
        public virtual void deactivate()
        {
            if (!active) return;
            active = false;
        }
        
    }
}
