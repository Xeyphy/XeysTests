using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class ModCheck :Effect
    {
        List<string> checks;
        public ModCheck(Character chr, int mod,List<string>checks) : base(chr, mod)
        {
            this.checks = checks;
        }

        public override void activate()
        {
            base.activate();
            foreach (string a in checks)
            {
                chr.GetStats().getSkillbyName(a).extra = mod;
            }
            
        }
        public override void deactivate()
        {
            base.deactivate();
            foreach (string a in checks)
            {
                chr.GetStats().getSkillbyName(a).extra = 0;
            }
        }
    }
}
