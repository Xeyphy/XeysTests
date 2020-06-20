using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Enemy
    {
        int id;
        [JsonProperty]
        int maxAttackCount;
        [JsonProperty]
        int pp;
        [JsonProperty]
        string name;
        [JsonProperty]
        string shortName;
        [JsonProperty]
        string groupName;
        [JsonProperty]
        string size;
        [JsonProperty]
        string race;
        [JsonProperty]
        string alignment;
        [JsonProperty]
        int[] hitdie;
        [JsonProperty]
        string[] resistance;
        [JsonProperty]
        string[] vulnerabilities;
        [JsonProperty]
        string[] immunities;
        [JsonProperty]
        string[] senses;
        [JsonProperty]
        string[] languages;
        [JsonProperty]
        int cr;
        [JsonProperty]
        int xpWorth;
        [JsonProperty]
        int legendaryActionsPerRound;
        [JsonProperty]
        Stats stats;
        [JsonProperty]
        List<Action> reactions;
        [JsonProperty]
        List<Attacks> attacks;
        [JsonProperty]
        List<Action> actions;
        [JsonProperty]
        List<Action> legendary;
        [JsonProperty]
        List<Action> additional;


       

        

        public Enemy( int maxAttackCount, int pp, string name, string shortName, string groupName, string size, string race, string alignment, int[] hitdie, string[] resistance, string[] vulnerabilities, string[] immunities, string[] senses, string[] languages, int cr, int xpWorth, Stats stats, List<Action> reactions, List<Attacks> attacks, List<Action> actions, List<Action> legendary,int legyPerRound,List<Action> additional)
        {
            id = 0;
            this.maxAttackCount = maxAttackCount;
            this.pp = pp;
            this.name = name ?? "NO Name";
            this.shortName = shortName ?? "NO";
            this.groupName = groupName ?? "No Names";
            this.size = size ?? "medium";
            this.race = race ?? "idiot";
            this.alignment = alignment ?? "neutral";
            this.hitdie = hitdie ?? new int[] { 1, 1 };
            this.resistance = resistance ?? new string[0];
            this.vulnerabilities = vulnerabilities ?? new string[0];
            this.immunities = immunities ?? new string[0];
            this.senses = senses ?? new string[0];
            this.languages = languages ?? new string[0];
            this.cr = cr;
            this.xpWorth = xpWorth;
            this.stats = stats ?? new Stats();
            this.reactions = reactions ?? new List<Action>();
            this.attacks = attacks ?? new List<Attacks>();
            this.actions = actions ?? new List<Action>();
            this.legendary = legendary ?? new List<Action>();
            this.legendaryActionsPerRound = legyPerRound;
            this.additional = additional ?? new List<Action>();
        }

        
        public Enemy getEnemyWithID(Enemy e,int count)
        {
            this.id=count+1;
            this.maxAttackCount = e.maxAttackCount;
            this.pp = e.pp;
            this.name = e.name ?? "NO Name";
            this.shortName = e.shortName ?? "NO";
            this.groupName = e.groupName ?? "No Names";
            this.size = e.size ?? "medium";
            this.race = e.race ?? "idiot";
            this.alignment = e.alignment ?? "neutral";
            this.hitdie = e.hitdie ?? new int[] { 1, 1 };
            this.resistance = e.resistance ?? new string[0];
            this.vulnerabilities = e.vulnerabilities ?? new string[0];
            this.immunities = e.immunities ?? new string[0];
            this.senses = e.senses ?? new string[0];
            this.languages = e.languages ?? new string[0];
            this.cr = e.cr;
            this.xpWorth = e.xpWorth;
            this.stats = e.stats ?? new Stats();
            this.reactions = e.reactions ?? new List<Action>();
            this.attacks = e.attacks ?? new List<Attacks>();
            this.actions = e.actions ?? new List<Action>();
            this.legendary = e.legendary ?? new List<Action>();
            this.legendaryActionsPerRound = e.legendaryActionsPerRound;
            this.additional = e.additional ?? new List<Action>();
            
            return this;
        }
        public override string ToString()
        {
            return this.name;
        }

        internal object getName()
        {
            return name;
        }
    }
}
