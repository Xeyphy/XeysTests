using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xeys_DnD_Player
{
  public static class JsonParser
    {



        internal static void SaveCharacter(Character chr, string path)
        {
            
            string json = JsonConvert.SerializeObject(chr, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        internal static void saveNotes(List<Note> notes,string path)
        {
            string filename = "Notes.json";
            string json = JsonConvert.SerializeObject(notes, Formatting.Indented);
            File.WriteAllText(path + filename, json);
        }
        internal static List<Note> getNotes(string path)
        {
            List<Note> notes = null;
            try
            {
                notes = JsonConvert.DeserializeObject<List<Note>>(File.ReadAllText(path));
                return notes;
            }
            catch
            {

            return new List<Note>();
            }
        }

        internal static Character loadCharacter(string path)
        {
            Character ch=null;
            try
            {

                 ch= JsonConvert.DeserializeObject<Character>(File.ReadAllText(path));
            }
            catch
            {
                
            }
            return ch;
        }

        internal static void SaveSpells(string path)
        {
            string filename = "SpellsTest.json";
            List<Spells> spells = Spells.getSpellList();
            string json = JsonConvert.SerializeObject(spells, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            File.WriteAllText(path + filename, json);
            

        }
        internal static List<Spells> loadSpells(string path)
        {
            List<Spells> stuff = JsonConvert.DeserializeObject<List<Spells>>(File.ReadAllText(path));
            return stuff;
        }
        internal static bool loadable(string path)
        {
            if (File.Exists(path)) return true;
            return false;
        }
        internal static List<Enemy> loadBestiary(string path)
        {
            return JsonConvert.DeserializeObject<List<Enemy>>(File.ReadAllText(path));
        }

        internal static void LoadSpells(string path)
        {
            dynamic stuff = JsonConvert.DeserializeObject(File.ReadAllText(path));
            JObject chld = stuff;
            string castingtime = null;
            string components = null;
            string description = null;
            string duration = null;
            int level = 0;
            string range = null;
            string school = null;
            string name = null;

            foreach(var a in stuff)
            {
                name = a.Name;
                foreach(var b in a)
                {
                    castingtime = b.casting_time;
                    components = b.components;
                    description = b.description;
                    duration = b.duration;
                    level = b.level;
                    range = b.range;
                    school = b.school;
                    Spells.CreateSpell(name, castingtime, components, description, duration, level, range, school);
                }
            }
        }


        static internal List<Enemy> importBestiary(string path)        {
            List<Enemy> enemies = new List<Enemy>();

            dynamic stuff = JsonConvert.DeserializeObject(File.ReadAllText(path));
            foreach(var a in stuff.creatures)
            {
                string name = a.name;
                
                int pp = a.stats.passivePerception;
                int[] hp = new int[] { a.stats.hitPoints,a.stats.hitPoints };
                int hitdieSize = a.stats.hitDieSize;
                int numhitDie = a.stats.numHitDie;
                int ac = a.stats.armorClass;
                int cr = a.stats.challengeRating;
                int xpWorth = a.stats.experiencePoints;
                int strsave = 0;
                int dexsave = 0;
                int consave = 0;
                int intsave = 0;
                int wissave = 0;
                int chasave = 0;
                int profbonus = a.stats.proficiencyBonus;

                foreach (var b in a.stats.savingThrows)
                {
                    switch (b.ability)
                    {
                            case "strength": strsave = b.modifier;break;
                            case "dexterity": dexsave = b.modifier; break;
                            case "constitution": consave = b.modifier; break;
                            case "intelligence": intsave = b.modifier; break;
                            case "wisdom": wissave = b.modifier; break;
                            case "charisma": chasave = b.modifier; break;
                    }
                }
                if (strsave == 0) strsave = a.stats.abilityScoreModifiers.strength;
                if (dexsave == 0) dexsave = a.stats.abilityScoreModifiers.dexterity;
                if (consave == 0) consave = a.stats.abilityScoreModifiers.constitution;
                if (intsave == 0) intsave = a.stats.abilityScoreModifiers.intelligence;
                if (wissave == 0) wissave = a.stats.abilityScoreModifiers.wisdom;
                if (chasave == 0) chasave = a.stats.abilityScoreModifiers.charisma;
                int strmod = intNullCheck(a.stats.abilityScoreModifiers.strength);
                int stri    = intNullCheck(a.stats.abilityScores.strength);
                int dexmod  = intNullCheck(a.stats.abilityScoreModifiers.dexterity);
                int dexi    = intNullCheck(a.stats.abilityScores.dexterity);
                int conmod  = intNullCheck(a.stats.abilityScoreModifiers.constitution);
                int coni    = intNullCheck(a.stats.abilityScores.constitution);
                int intmod  = intNullCheck(a.stats.abilityScoreModifiers.intelligence);
                int inti    = intNullCheck(a.stats.abilityScores.intelligence);
                int wismod  = intNullCheck(a.stats.abilityScoreModifiers.wisdom);
                int wisi    = intNullCheck(a.stats.abilityScores.wisdom);
                int chamod  = intNullCheck(a.stats.abilityScoreModifiers.charisma);
                int chai    = intNullCheck(a.stats.abilityScores.charisma);
                int[] str = new int[]   { stri, strmod, strsave };
                int[] dex = new int[]   { dexi, dexmod,dexsave };
                int[] con = new int[]   { coni, conmod,consave };
                int[] intel = new int[] { inti, intmod,intsave };
                int[] wis = new int[]   { wisi, wismod, wissave };
                int[] cha = new int[]   { chai , chamod,chasave };
                int[] hitdie = new int[] { numhitDie, hitdieSize };
                string size = a.stats.size;
                string race = a.stats.race;
                string alignment = a.stats.alignment;
                string speedstr = a.stats.speed;
                int speed = getSpeed(speedstr);
                List<Action> legendaryActions = new List<Action>();
                int legysPerRound = 0;
                legendaryActions = getLegendaryActions(a.stats.legendaryActions);
                if(legendaryActions!=null && legendaryActions.Count > 0)
                {
                    legysPerRound = getLegysPerRound(a.stats.legendaryActionsPerRound);
                }
                List<string> languages = new List<string>();
                List<string> vulnerabilities= new List<string>();
                List<string> resistances = new List<string>();
                List<string> immunities = new List<string>();
                List<Action> actions = new List<Action>();
                List<Action> reactions = new List<Action>();
                List<string> senses = new List<string>();
                List<Skills> skills = new List<Skills>();
                foreach(var b in a.stats.skills)
                {
                    skills.Add(new Skills((string)b.name, (int)b.modifier, true));
                }
                foreach(var b in a.stats.languages)
                {
                    languages.Add((string)b);
                }
                foreach(var b in a.stats.actions)
                {
                    actions.Add(new Action((string)b.name, (string)b.description));
                }
                foreach(var b in a.stats.reactions)
                {
                    reactions.Add(new Action((string)b.name, (string)b.description));
                }
                foreach(var b in a.stats.damageVulnerabilities)
                {
                    vulnerabilities.Add((string)b);
                }
                foreach(var b in a.stats.damageImmunities)
                {
                    immunities.Add((string)b);
                }
                foreach(var b in a.stats.conditionImmunities)
                {
                    immunities.Add((string)b);
                }
                foreach(var b in a.stats.damageResistances)
                {
                    resistances.Add((string)b);
                }
                foreach(var b in a.stats.senses)
                {
                    senses.Add((string)b);
                }
                List<Action> additional = new List<Action>();
                foreach(var b in a.stats.additionalAbilities)
                {
                    additional.Add(new Action((string)b.name, (string)b.description));
                }
                Stats stat = new Stats(str, dex, con, intel, wis, cha, hp, ac, dex[1], speed, profbonus, pp, skills);
                enemies.Add(new Enemy(0, pp, name, (name[0] +""+ name[1]), name + 's', size, race, alignment, hitdie, resistances.ToArray(), vulnerabilities.ToArray(), immunities.ToArray(), senses.ToArray(), languages.ToArray(), cr, xpWorth, stat, reactions, null, actions,legendaryActions,legysPerRound,additional));
                
            }

            return enemies;
        }

        static internal void saveBestiary(List<Enemy> enemies,string path)
        {
            string filename = "bestiary.json";
            if (enemies.Count > 1)
            {

                string json = JsonConvert.SerializeObject(enemies, Formatting.Indented);
            
                File.WriteAllText(path + filename, json);
            }
        }

        private static int getLegysPerRound(dynamic legendaryActionsPerRound)
        {
            if (legendaryActionsPerRound != null)
            {
                return Convert.ToInt32((string)legendaryActionsPerRound);
            }
            return 0;
        }

        private static List<Action> getLegendaryActions(dynamic legendaryActions)
        {
            List<Action> list = new List<Action>();
            foreach(var a in legendaryActions)
            {
                list.Add(new Action((string)a.name, (string)a.description));
            }
            return list;
        }

        private static int intNullCheck(dynamic strength)
        {
            if (strength == null)
            {
                return 0;
            }
            else
            {
                return (int)strength;
            }
        }

        private static int getSpeed(string speedstr)
        {
            string str = "";
            foreach(char a in speedstr)
            {
                if (char.IsDigit(a)) str += a;
                if (str.Length >= 2) return Convert.ToInt32(str);
            }
            return 0;
        }

        static internal Character importCharacter(string path)
        {
            dynamic stuff = JsonConvert.DeserializeObject(File.ReadAllText(path));
            int pp = stuff.character[0].passive_perception;
            string subrace = stuff.character[0].subrace;
            string personality = stuff.character[0].characteristics[0]["personality_trait_1"] + "\n" + stuff.character[0].characteristics[0]["personality_trait_2"];
            string ideals = stuff.character[0].characteristics[0]["ideals"];
            string bonds = stuff.character[0].characteristics[0]["bonds"];
            string flaws = stuff.character[0].characteristics[0]["flaws"];
            int age = stuff.character[0].characteristics[0]["age"];
            string weight = stuff.character[0].characteristics[0]["weight"];
            string eyes = stuff.character[0].characteristics[0]["eyes"];
            string height = stuff.character[0].characteristics[0]["height"];
            string name = stuff.character[0]["character_name"];
            string skin = stuff.character[0].characteristics[0]["skin"];
            string hair = stuff.character[0].characteristics[0]["hair"];
            int ac = stuff.character[0].ac;
            int profbonus = stuff.character[0].proficiency_bonus;
            string race = stuff.character[0].race;
            string alignment = stuff.character[0].alignment;
            string imageUrl = stuff.character[0].image_url;
            int initbonus = stuff.character[0].initiative_bonus;
            int speed = stuff.character[0].characteristics[0].speed;
            int exp = 0;
            string traits = stuff.character[0].traits["features-and-traits-2"];
            if (stuff.character[0].experience != null)
            {
                exp = stuff.character[0].experience;
            }
            string background = stuff.character[0].background;
            List<Items> items = getItems(stuff.character[0].equipment);
            List<Coin> coins = getCoins(stuff.character[0].treasure);
            List<Class> classes = getClasses(stuff.character[0].classes);
            int level = getPlayerLevel(classes);
            Stats stats = getCharStats(stuff.character[0].abilities_bonuses[0],stuff.character[0].hp[0],stuff.character[0].save_bonuses,stuff.character[0].skills,initbonus, ac, profbonus,speed,pp);
            List<Attacks> attacks = getAttacks(stuff.character[0].attacks);
            Character chr = new Character(name,level,personality,ideals,bonds,flaws,age,height,weight,eyes,skin,hair,alignment,imageUrl,background,traits,race,classes,stats,null,attacks,items,coins);
            return chr;
        }

        private static int getPlayerLevel(List<Class> classes)
        {
            int level = 0;
            foreach (Class a in classes)
            {
                level += a.getLevel();
            }
            return level;
        }

        private static List<Coin> getCoins(dynamic treasure)
        {
            JObject chld = treasure;
            List<Coin> wallet = new List<Coin>();
            foreach (JProperty prop in chld.Properties())
            {
                if (!prop.Name.StartsWith("treasure"))
                {
                    wallet.Add(new Coin(prop.Name,(int) prop.Value));
                }
            }
            return wallet;
        }

        private static List<Attacks> getAttacks(dynamic attacks)
        {
            JObject chld = attacks;
            List<Attacks> attks = new List<Attacks>();
            string type = "";
            int[] atckdmg = new int[3];

            string[] names = new string[20];
            int[] bonus = new int[20];
            string[] damage = new string[20];
            foreach (JProperty prop in chld.Properties())
            {
                
                if (prop.Name.StartsWith("weapon"))
                {
                    string a =""+ prop.Name[(prop.Name.Length - 1)];
                    int itm = Convert.ToInt32(a);
                    itm--;
                    if (prop.Name.StartsWith("weapon-name")) names[itm] = (string)prop.Value;
                    if (prop.Name.StartsWith("weapon-att")) bonus[itm] = (int)prop.Value;
                    if (prop.Name.StartsWith("weapon-damage")) damage[itm] = (string)prop.Value;
                }
            }
            for(int i = 0; i < names.Length; i++)
            {
                
                string value = damage[i];
                type = value.Split(' ')[1];
                atckdmg[0] = Convert.ToInt32(value.Substring(0, 1));
                atckdmg[1] = Convert.ToInt32(value.Substring(2, 1));
                if (value.Contains('+'))
                {
                    value = value.Substring(value.IndexOf('+') + 1);
                    value = value.Split(' ')[0];
                }
                else if (value.Contains('-'))
                {
                    value = value.Substring(value.IndexOf('-') + 1);
                    value = value.Split(' ')[0];
                }
                atckdmg[2] = Convert.ToInt32(value);
                attks.Add(new Attacks(names[i], type, bonus[i], atckdmg));
                atckdmg = new int[3];
                if (names[i + 1] == null) return attks;
            }
            return attks;
        }

        private static List<Class> getClasses(dynamic classes)
        {
            List<Class> classess = new List<Class>();
            int level = 0;
            int hitdie= 0;
            int currenthitdie = 0;
            string classname = "";
            string subclassname = "";

            foreach(var a in classes)
            {
                foreach(var b in a)
                {
                    level = (int)b["class-level"];
                    hitdie = (int)b["hit-die"];
                    currenthitdie = level;
                    classname = (string)b["class-name"];
                    subclassname = (string)b["subclass-name"] ?? "";
                    classess.Add(new Class(level, hitdie, classname, subclassname,currenthitdie));
                }
            }
            return classess;
        }

        private static Stats getCharStats(dynamic dynamic, dynamic dynamic2, dynamic save, dynamic skills, int initbonus, int ac, int profbonus, int speed, int pp)
        {
            int currenthp = 0;
            bool prof = false;
            string skillname = "";
            if (dynamic2.hp_current != null) currenthp = dynamic2.hp_current;
            int[] str = { dynamic.abilities.str, dynamic.bonuses.str, save.str };
            int[] dex = { dynamic.abilities.dex, dynamic.bonuses.dex,save.dex };
            int[] con = { dynamic.abilities.con, dynamic.bonuses.con,save.con };
            int[] intel = { dynamic.abilities["int"], dynamic.bonuses["int"],save["int"] };
            int[] wis = { dynamic.abilities.wis, dynamic.bonuses.wis ,save.wis};
            int[] cha = { dynamic.abilities.cha, dynamic.bonuses.cha,save.cha };
            int[] hp = { dynamic2.hp_max, currenthp, 0 };
            List<Skills> sklz = new List<Skills>();
            List<SmallSkillzHelper> helper = new List<SmallSkillzHelper>();
            JObject chld = skills;
            foreach(JProperty property in chld.Properties())
            {

                if (property.Name.Contains("check"))
                {
                    prof = (bool)property.Value;
                    string[] split = property.Name.Split('-');
                    for(int i = 0; i < split.Length; i++)
                    {
                        if (!split[i].Contains("check"))
                        {
                            
                            if (string.IsNullOrEmpty(skillname)) skillname += split[0];
                            if(split.Length>2)skillname += "-"+split[1];
                            if (split.Length > 3) skillname += "-" + split[2];
                            break;
                            
                            
                        }
                      //  if (skillname.EndsWith("-")) skillname = skillname.Substring(0, skillname.Length - 1);
                    }
                    helper.Add(new SmallSkillzHelper(prof, skillname));
                    skillname = "";
                    prof = false;
                }
                else
                {

                    sklz.Add(new Skills(property.Name, (int)property.Value,false));
                }
                
            }
            
            foreach(SmallSkillzHelper hel in helper)
            {
                for(int i = 0; i< sklz.Count; i++)
                {
                    if (hel.name.Equals(sklz.ElementAt(i).name))
                    {
                        sklz.ElementAt(i).prof = hel.prof;
                        continue;
                    }
                }
            }
            Stats stat = new Stats(str, dex, con, intel, wis, cha, hp, ac, initbonus, speed, profbonus, pp,sklz);

            return stat;
        }

        

        private static List<Items> getItems(dynamic equipment)
        {
            List<Items> items = new List<Items>();
            string name="";
            int quant=0;
            bool equipd=false;
            foreach(var a in equipment[0].equipment)
            {
                
                name = a.ToString();
                name = name.Split('"')[1];
                
                foreach (var b in a)
                {
                    quant = b.quantity;
                    equipd = b["equipped?"];
                    break;
                }
                items.Add(new Items(name,quant,equipd));
            }
            if (equipment[0].armor != null)
            {
                foreach(var a in equipment[0].armor)
                {
                    name = a.ToString();
                    name = name.Split('"')[1];
                    foreach(var b in a)
                    {
                        quant = b.quantity;
                        equipd = b["equipped?"];
                        break;
                    }
                    items.Add(new Armor(name, quant, equipd));
                }
            }
            foreach(var a in equipment[0]["magic-weapons"])
            {
                foreach(var b in a)
                {
                    quant = b.Next.quantity;
                    equipd = b.Next["equipped?"];

                    name = a[0];
                    break;
                }
                if (!string.IsNullOrEmpty(name))
                {
                    items.Add(new MagicWeapon(name, quant, equipd));
                }
            }
            foreach (var a in equipment[0].weapons)
            {
                name = a.ToString();
                name = name.Split('"')[1];
                foreach (var b in a)
                {

                    quant = b.Next["quantity"];
                    equipd = b.Next["equipped?"];
                    break;
                }
                items.Add(new Weapons(name, quant, equipd));
            }
            return items;
        }
    }
}
