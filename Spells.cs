using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Spells
    {
        [JsonProperty]
        int id;
        [JsonProperty]
        string castingTime;
        [JsonProperty]
        string components;
        [JsonProperty]
        string description;
        [JsonProperty]
        string duration;
        [JsonProperty]
        int level;
        [JsonProperty]
        string name;
        [JsonProperty]
        string range;
        [JsonProperty]
        string school;
        [JsonProperty]
        int[] dmg;
        
        public static List<Spells> totalSpellList = new List<Spells>();

        public Spells(int id, string name, string castingTime, string components, string description, string duration, int level, string range, string school)
        {
            this.id = id;
            this.name = name?? "No SpellName";
            this.castingTime = castingTime ?? "1 action";
            this.components = components ?? "V, S";
            this.description = description ?? "No Desc";
            this.duration = duration ?? "Instantaneous";
            this.level = level;
            this.range = range ?? "Self";
            this.school = school ?? "No School";
            this.dmg =new int[]{ 1,4,0};
        }
        public Spells getSpellById(int id)
        {
            return Spells.totalSpellList.ElementAt(id - 1);
        }
        public Spells getSpellByName(string name)
        {
            return null;
        }
        public static Spells CreateSpell()
        {
            Spells spell = new Spells(totalSpellList.Count + 1,null,null,null,null,null,0,null,null);
            if(!totalSpellList.Contains(spell)) totalSpellList.Add(spell);
            return spell;
        }
        public static void loadTotalSPellList(List<Spells> list)
        {
            totalSpellList = list;
        }
        public static Spells CreateSpell(string name, string castingTime, string components, string description, string duration, int level, string range,string school)
        {
            bool doesnotcontain = true;
            Spells spell = new Spells(totalSpellList.Count + 1,name, castingTime, components, description, duration, level, range,school);
            foreach(Spells sp in totalSpellList)
            {
                if (sp.name.Equals(name))
                {
                    doesnotcontain = false;
                    return sp;
                }
                
                
            }
            if (doesnotcontain)
            {
                totalSpellList.Add(spell);
            }
            return spell;
        }
       
        private int add2SpellList(Spells spell)
        {
            totalSpellList.Add(spell);
            return totalSpellList.Count;
        }
        public static List<Spells> getSpellList()
        {
            return new List<Spells>(totalSpellList);
        }

    }

    

    
}
