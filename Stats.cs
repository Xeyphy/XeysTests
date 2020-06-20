using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Stats
    {
        
        public int[] str = new int[3]; //0 = value 1 = mod 2 = save
        public int[] dex = new int[3];
        public int[] con = new int[3];
        public int[] intel = new int[3];
        public int[] wis = new int[3];
        public int[] cha = new int[3];
        public int[] hp = new int[3];//0 = max 1 = current 2 = temp
        public int ac;
        public int init;
        public int speed;
        public int profbonus;
        public int passiveWis;
        public List<Skills> skills;

        public Stats()
        {
        }

        public Stats(int[] str, int[] dex, int[] con, int[] intel, int[] wis, int[] cha, int[] hp, int ac, int init, int speed, int profbonus, int passiveWis, List<Skills> skills)
        {
            this.str = str ?? throw new ArgumentNullException(nameof(str));
            this.dex = dex ?? throw new ArgumentNullException(nameof(dex));
            this.con = con ?? throw new ArgumentNullException(nameof(con));
            this.intel = intel ?? throw new ArgumentNullException(nameof(intel));
            this.wis = wis ?? throw new ArgumentNullException(nameof(wis));
            this.cha = cha ?? throw new ArgumentNullException(nameof(cha));
            this.hp = hp ?? throw new ArgumentNullException(nameof(hp));
            this.ac = ac;
            this.init = init;
            this.speed = speed;
            this.profbonus = profbonus;
            this.passiveWis = passiveWis;
            this.skills = skills ?? throw new ArgumentNullException(nameof(skills));
            skills = skills.OrderBy(x => x.name).ToList();
        }

        internal Skills getAcrobatics()
        {
            return getSkillbyName("acrobatics");
        }

        internal Skills getSkillbyName(string v)
        {
            foreach(Skills skill in skills)
            {
                if (skill.name.Equals(v))
                {
                    return skill;
                }

            }
            return null;
        }

        internal Skills getAH()
        {
            return getSkillbyName("animal-handling");
        }

        internal Skills getArcana()
        {
            return getSkillbyName("arcana");
        }

        internal Skills getAthletics()
        {
            return getSkillbyName("athletics");
        }

        internal Skills getDeception()
        {
            return getSkillbyName("deception");
        }

        internal Skills getInsight()
        {
            return getSkillbyName("insight");
        }

        internal Skills getMedicine()
        {
            return getSkillbyName("medicine");
        }

        internal Skills getPerception()
        {
            return getSkillbyName("perception");
        }

        internal Skills getPersuasion()
        {
            return getSkillbyName("persuasion");
        }

        internal Skills getSOH()
        {
            return getSkillbyName("sleight-of-hand");
        }

        internal Skills getSurvival()
        {
            return getSkillbyName("survival");
        }

        internal Skills getStealth()
        {
            return getSkillbyName("stealth");
        }

        internal Skills getReligion()
        {
            return getSkillbyName("religion");
        }

        internal Skills getPerformance()
        {
            return getSkillbyName("performance");
        }

        internal Skills getNature()
        {
            return getSkillbyName("nature");
        }

        internal Skills getHistory()
        {
            return getSkillbyName("history");
        }

        internal Skills getinvestigation()
        {
            return getSkillbyName("investigation");
        }
    }
}
