using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class ModBaseAc : Effect
    {
        int prevAc = 0;
        int baseAc;
        public ModBaseAc(Character chr, int baseAC,int mod) : base(chr, mod)
        {
            this.baseAc = baseAC;
        }

        public override void activate()
        {
            base.activate();
            prevAc = chr.GetStats().ac;
            chr.GetStats().ac = baseAc + mod;
        }
        public override void deactivate()
        {
            base.deactivate();
            chr.GetStats().ac = prevAc;

        }
    }
}
