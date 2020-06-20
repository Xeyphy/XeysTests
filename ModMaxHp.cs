using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class ModMaxHp : Effect
    {
        public ModMaxHp(Character chr, int mod) : base(chr, mod)
        {

        }
        public override void activate()
        {
            base.activate();
            chr.GetStats().hp[0] += mod;
        }
        public override void deactivate()
        {
            base.deactivate();
            chr.GetStats().hp[0] -= mod;
        }
    }
}
