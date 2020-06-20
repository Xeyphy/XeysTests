using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class ModAc : Effect
    {
        public ModAc(Character chr, int mod) : base(chr,mod)
        {

        }
        
        public override void activate()
        {
            base.activate();
            this.chr.GetStats().ac += mod;
            
        }
        

        public override void deactivate()
        {
            base.deactivate();
            this.chr.GetStats().ac -= mod;
            
        }

        
    }
}
