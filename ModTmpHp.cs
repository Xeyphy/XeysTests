using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class ModTmpHp : Effect
    {
        public ModTmpHp(Character chr, int mod) : base(chr, mod)
        {

        }
        public override void activate()
        {
            base.activate();
            chr.GetStats().hp[2] += mod;
        }
        public override void deactivate()
        {
            base.deactivate();
            chr.GetStats().hp[2] -= mod;
        }
    }
}
