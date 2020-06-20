using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    [Serializable]
    class Character
    {
        [JsonProperty]
        string name;
        [JsonProperty]
        int level;
        [JsonProperty]
        string personalityTrait;
        [JsonProperty]
        string ideals;
        [JsonProperty]
        string bonds;
        [JsonProperty]
        string Flaws;
        [JsonProperty]
        int age;
        [JsonProperty]
        string heightcm;
        [JsonProperty]
        string  weightkg;

        internal void helperDeleteThisUpdatehpArray()
        {
            if (this.stats.hp.Length < 3)
            {
                int one = this.stats.hp[0];
                int two = this.stats.hp[1];
                this.stats.hp = new int[] { one, two, 0 };
            }
        }

        [JsonProperty]
        string eyes;
        [JsonProperty]
        string skin;
        [JsonProperty]
        string hair;
        [JsonProperty]
        string alignment;
        [JsonProperty]
        string imageUrl;
        [JsonProperty]
        string background;
        [JsonProperty]
        string trait;
        [JsonProperty]
        string race;
        [JsonProperty]
        List<CharTrait> traits;
        [JsonProperty]
        List<Class> classes;
        [JsonProperty]
        Stats stats;
        [JsonProperty]
        List<Spells> spells;
        [JsonProperty]
        List<Attacks> attacks;
        [JsonProperty]
        List<Items> inventory;
        [JsonProperty]
        List<Coin> wallet;
        [JsonProperty]
        Spellslots spellSlots;
        private Character character;

        public static Character charackter;

        internal string getCopper()
        {
            return searchCoinByName("cp");
        }

        internal void regainTraits()
        {
            if (this.trait != "") this.traits = getTraits();
        }

        internal string getImageUrl()
        {
            return imageUrl;
        }

        private string searchCoinByName(string v)
        {
            foreach(Coin c in wallet)
            {
                if (c.getName().Equals(v)) return c.getValue().ToString();
            }
            return "0";
        }

        internal string getSilver()
        {
            return searchCoinByName("sp");
        }

        internal string getPlatin()
        {
            return searchCoinByName("pp");
        }

        internal string getGold()
        {
            return searchCoinByName("gp");
        }

        internal string getElectrum()
        {
            return searchCoinByName("ep");
        }

        

        internal string getClassLevel()
        {
            string classlevel = "";
            foreach(Class a in classes)
            {
                classlevel += a.getName() + " " + a.getLevel() + " ";
            }
            return classlevel;
        }

        internal string getFlaws()
        {
            return Flaws;
        }

        internal IEnumerable<Class> getClasses()
        {
            return this.classes;
        }

        internal string getBonds()
        {
            return bonds;
        }

        internal string getIdeals()
        {
            return ideals;
        }

        internal string getPersonality()
        {
            return personalityTrait;
        }


        internal string getBackground()
        {
            return this.background;
        }

        internal string getAlignment()
        {
            return alignment;
        }

        

        internal string getName()
        {
            return this.name;
        }

        public Character(string name, int level, string personalityTrait, string ideals, string bonds, string flaws, int age, string heightcm, string weightkg, string eyes, string skin, string hair, string alignment, string imageUrl, string background, string trait, string race, List<CharTrait> traits, List<Class> classes, Stats stats, List<Spells> spells, List<Attacks> attacks, List<Items> inventory, List<Coin> wallet, Spellslots spellSlots, Character character)
        {
            this.imageUrl = imageUrl ?? "https://i.pinimg.com/originals/42/a9/34/42a93455d3d83136728395b762583cbf.jpg";
            this.name = name ?? "You forgot your Name";
            this.level = level;
            this.personalityTrait = personalityTrait ?? "Dont even ask";
            this.ideals = ideals ?? "No Ideals";
            this.bonds = bonds ?? "No Bonds";
            Flaws = flaws ?? "Char is heavily flawed";
            this.age = age;
            this.heightcm = heightcm;
            this.weightkg = weightkg;
            this.eyes = eyes ?? "green";
            this.skin = skin ?? "white";
            this.hair = hair ?? "blonde";
            this.alignment = alignment ?? "No Alignment";
            this.background = background ?? "No Background";
            this.race = race ?? "No Race";
            this.trait = trait ?? "No traits";
            this.classes = classes ?? new List<Class>();
            this.stats = stats ?? new Stats();
            this.spells = spells ?? new List<Spells>();
            this.attacks = attacks ?? new List<Attacks>();
            this.inventory = inventory ?? new List<Items>();
            this.wallet = wallet ?? new List<Coin>();
            this.traits = getTraits() ?? new List<CharTrait>();
            this.spellSlots = spellSlots ?? new Spellslots();
           
        }

        public Character(string name, int level, string personalityTrait, string ideals, string bonds, string flaws, int age, string heightcm, string weightkg, string eyes, string skin, string hair, string alignment, string imageUrl, string background, string trait, string race,  List<Class> classes, Stats stats, List<Spells> spells, List<Attacks> attacks, List<Items> inventory, List<Coin> wallet)
        {
            this.imageUrl = imageUrl ?? "https://i.pinimg.com/originals/42/a9/34/42a93455d3d83136728395b762583cbf.jpg";
            this.name = name ?? "You forgot your Name";
            this.level = level;
            this.personalityTrait = personalityTrait ?? "Dont even ask";
            this.ideals = ideals ?? "No Ideals";
            this.bonds = bonds ?? "No Bonds";
            Flaws = flaws ?? "Char is heavily flawed";
            this.age = age;
            this.heightcm = heightcm;
            this.weightkg = weightkg;
            this.eyes = eyes ?? "green";
            this.skin = skin ?? "white";
            this.hair = hair ?? "blonde";
            this.alignment = alignment ?? "No Alignment";
            this.background = background ?? "No Background";
            this.race = race ?? "No Race";
            this.trait = trait ?? "No traits";
            this.classes = classes ?? new List<Class>();
            this.stats = stats ?? new Stats();
            this.spells = spells ?? new List<Spells>();
            this.attacks = attacks ?? new List<Attacks>();
            this.inventory = inventory ?? new List<Items>();
            this.wallet = wallet ?? new List<Coin>();
            this.traits = getTraits() ?? new List<CharTrait>();
            this.spellSlots = new Spellslots();
        }


        internal IEnumerable<Items> getItems()
        {
            return inventory;
        }

        internal IEnumerable<CharTrait> getTraitList()
        {
            return this.traits;
        }

        internal IEnumerable<Attacks> getAttacks()
        {
            return this.attacks;
        }

        public Stats GetStats()
        {
            return this.stats;
        }
        public string getRace()
        {
            return race;
        }
        public Character(string name, int level, string personalityTrait, string ideals, string bonds, string flaws, int age, string heightcm, string weightkg, string eyes, string skin, string hair, string alignment, string background, string race,string Trait, List<Class> classes, Stats stats, List<Spells> spells, List<Attacks> attacks, List<Items> inventory, List<Coin> wallet)
        {
            this.name = name ?? "You forgot your Name";
            this.level = level;
            this.personalityTrait = personalityTrait ?? "Dont even ask";
            this.ideals = ideals ?? "No Ideals";
            this.bonds = bonds ?? "No Bonds";
            Flaws = flaws ?? "Char is heavily flawed";
            this.age = age;
            this.heightcm = heightcm;
            this.weightkg = weightkg;
            this.eyes = eyes ?? "green";
            this.skin = skin ?? "white";
            this.hair = hair ?? "blonde";
            this.alignment = alignment ?? "No Alignment";
            this.background = background ?? "No Background";
            this.race = race ?? "No Race";
            this.trait = Trait ?? "No traits";
            this.classes = classes ?? new List<Class>();
            this.stats = stats ?? new Stats();
            this.spells = spells ?? new List<Spells>();
            this.attacks = attacks ?? new List<Attacks>(); 
            this.inventory = inventory ?? new List<Items>();
            this.wallet = wallet ?? new List<Coin>();
            this.traits = getTraits() ?? new List<CharTrait>();
        }

        private List<CharTrait> getTraits()
        {
            List<CharTrait> charTraits = new List<CharTrait>();
            string[] cleanup = trait.Split('\n') ?? new string[0];
            string name="";
            string desc="";
            bool actualtraits = false;
            foreach(string str in cleanup)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    if (str.StartsWith("-"))
                    {
                        actualtraits = true;
                        continue;
                    }
                    if (!actualtraits)
                    {
                        name = str.Split(':')[0];
                        desc = str.Split(':')[1];
                    }
                    else
                    {
                        if (name == "")
                        {
                            name = str.Split('.')[0];
                            desc = str.Remove(0, name.Length).Substring(2);
                            if (name.Length > 0)
                            {
                                if (name[0] == ' ') name = name.Substring(1);
                            }
                            if (desc.Length > 0)
                            {
                                if (desc[0] == ' ' && desc.Length > 0) desc = desc.Substring(1);
                            }
                            
                        }
                        else
                        {
                            desc += "\n" + str;
                        }
                       
                    }


                }
                else
                {
                    if (name != "" && desc != "")
                    {
                        charTraits.Add(new CharTrait(name, desc));
                        name = "";
                        desc = "";
                    }
                }
            }
            return charTraits;
        }

        public Character()
        {
            this.name = "No Name";
            this.level = 1;
            this.personalityTrait = "No Trait";
            this.ideals = "No Ideal";
            this.bonds = "No Bond";
            Flaws = "Alot of Flaws";
            this.age = 90;
            this.heightcm = "20";
            this.weightkg = "100";
            this.eyes = "blind";
            this.skin = "burned";
            this.hair = "burned";
            this.alignment = "Chaotic Neutral";
            this.imageUrl = "https://www.freeiconspng.com/img/23484";
            this.background = "No Background";
            this.trait = "no Traits";
            this.race = "Black";
            try
            {
            this.traits = getTraits() ?? new List<CharTrait>();

            }
            catch
            {
                this.traits = new List<CharTrait>();
            }
            this.classes = new List<Class>();
            this.stats = new Stats();
            this.spells = new List<Spells>();
            this.attacks = new List<Attacks>();
            this.inventory = new List<Items>();
            this.wallet = new List<Coin>();
            
        }

        public Character(Character character)
        {
            this.character = character;
        }

        public void addSpells(Spells spell)
        {
            this.spells.Add(spell);
        }
        public void addAttack(Attacks attack)
        {
            this.attacks.Add(attack);
        }
        public void addItemtoInventory(Items item)
        {
            this.inventory.Add(item);
        }
        public void removeItemfromInventory(Items item)
        {
            this.inventory.Remove(item);
        }

        internal void addMaxHp(int result)
        {
            stats.hp[0] += result;
        }

        internal void addCurrentHp(int result)
        {
            if(result+stats.hp[1] <= stats.hp[0]) stats.hp[1] += result;
            else stats.hp[1] = stats.hp[0];
        }

        internal void addTempHp(int result)
        {
            stats.hp[2] += result;
        }

        internal void setCurrentHp(int result)
        {
            if (result <= stats.hp[0]) stats.hp[1] = result;
            else stats.hp[1] = stats.hp[0];
        }

        internal void setMaxHp(int result)
        {
            stats.hp[0] = result;
        }

        internal void setTempHp(int result)
        {
            stats.hp[2] = result;
        }

        internal void resetHP()
        {
            stats.hp[1] = stats.hp[0];
        }

        internal void doLongRest()
        {
            resetHP();
            spellSlots.refreshSpellSlots();
            Command.SendLongRestCommand();
        }

        internal void doShortRest()
        {
            foreach(Class cls in classes)
            {
                if (cls.getName().Equals("Warlock")) spellSlots.refreshSpellSlots();
            }
            Command.SendShortRestCommand();
        }
    }
}
