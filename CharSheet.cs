using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xeys_DnD_Player
{
    public partial class CharSheet : Form
    {
        
        public CharSheet(string json)
        {
            InitializeComponent();
            tableLayoutPanel4.Width = 0;
            Spells.loadTotalSPellList(JsonParser.loadSpells(@"C:\Xeys DnD Player\SpellsTest.json"));
            Character.charackter.regainTraits();
            Character.charackter.helperDeleteThisUpdatehpArray();
            updateForm(Character.charackter);
        }


        List<Enemy> bestiary = new List<Enemy>();

        private void updateForm(Character c)
        {
            resetAll();
            Stats stats = c.GetStats();
            
            strSaveLabel.Text = stats.str[2].ToString();
            
            dexSaveLabel.Text = stats.dex[2].ToString();
            conSaveLabel.Text = stats.con[2].ToString();
            intSaveLabel.Text = stats.intel[2].ToString();
            wisSaveLabel.Text = stats.wis[2].ToString();
            chaSaveLabel.Text = stats.cha[2].ToString();
            strTxtBx.Text = stats.str[0].ToString();
            dexTxtBx.Text = stats.dex[0].ToString();
            conTxtBx.Text = stats.con[0].ToString();
            wisTxtBx.Text = stats.wis[0].ToString();
            chaTxtBx.Text = stats.cha[0].ToString();
            intTxtBx.Text = stats.intel[0].ToString();
            strModLabel.Text = stats.str[1].ToString();
            dexModLabel.Text = stats.dex[1].ToString();
            conModLabel.Text = stats.con[1].ToString();
            intModLabel.Text = stats.intel[1].ToString();
            wisModLabel.Text = stats.wis[1].ToString();
            chaModLabel.Text = stats.cha[1].ToString();
            maxHpTextBox.Text = stats.hp[0].ToString();
            currentHpTextBox.Text = stats.hp[1].ToString();
            tempHpTextBox.Text = stats.hp[2].ToString();
            acTextBox.Text = stats.ac.ToString();
            initTextBox.Text = stats.init.ToString();
            ppTextBox.Text = stats.passiveWis.ToString();
            speedTextBox.Text = stats.speed.ToString();
            profBonusTextBox.Text = stats.profbonus.ToString();

            setupSkills(stats);
            traitsListBox.Items.Clear();
            hitdieComboBx.Items.Clear();
            foreach(Class cls in c.getClasses())
            {
                hitdieComboBx.Items.Add(cls);
            }
            foreach (CharTrait trait in c.getTraitList())
            {
                traitsListBox.Items.Add(trait);
            }
            atkListBox.Items.Clear();
            foreach (Attacks attack in c.getAttacks())
            {
                atkListBox.Items.Add(attack);

            }
            hitdieComboBx.SelectedIndex = 0;
            advComboBx.SelectedIndex = 0;


        }

        private void setupSkills(Stats stats)
        {
            acrobaticsLabel.Text = stats.getAcrobatics().value.ToString();
            animalHandlingLabel.Text = stats.getAH().value.ToString();
            arcanaLabel.Text = stats.getArcana().value.ToString();
            athleticsLabel.Text = stats.getAthletics().value.ToString();
            deceptionLabel.Text = stats.getDeception().value.ToString();
            historyLabel.Text = stats.getHistory().value.ToString();
            insightLabel.Text = stats.getInsight().value.ToString();
            investigationLabel.Text = stats.getinvestigation().value.ToString();
            medicineLabel.Text = stats.getMedicine().value.ToString();
            natureLabel.Text = stats.getNature().value.ToString();
            perceptionLabel.Text = stats.getPerception().value.ToString();
            performanceLabel.Text = stats.getPerformance().value.ToString();
            persuasionLabel.Text = stats.getPersuasion().value.ToString();
            religionLabel.Text = stats.getReligion().value.ToString();
            sohLabel.Text = stats.getSOH().value.ToString();
            stealthLabel.Text = stats.getStealth().value.ToString();
            survivalLabel.Text = stats.getSurvival().value.ToString();

            
            

            if (stats.getAcrobatics().prof) setButtonProf(acrobaticsButton);
            else setButtonUnProf(acrobaticsButton);
            if (stats.getAH().prof) setButtonProf(ahButton);
            else setButtonUnProf(ahButton);
            if (stats.getArcana().prof) setButtonProf(arcanaButton);
            else setButtonUnProf(arcanaButton);
            if (stats.getAthletics().prof) setButtonProf(athleticsButton);
            else setButtonUnProf(athleticsButton);
            if (stats.getDeception().prof) setButtonProf(deceptionButton);
            else setButtonUnProf(deceptionButton);
            if (stats.getHistory().prof) setButtonProf(historyButton);
            else setButtonUnProf(historyButton);
            if (stats.getInsight().prof) setButtonProf(insightButton);
            else setButtonUnProf(insightButton);
            if (stats.getinvestigation().prof) setButtonProf(investigationButton);
            else setButtonUnProf(investigationButton);
            if (stats.getMedicine().prof) setButtonProf(medicineButton);
            else setButtonUnProf(medicineButton);
            if (stats.getNature().prof) setButtonProf(natureButton);
            else setButtonUnProf(natureButton);
            if (stats.getPerception().prof) setButtonProf(perceptionButton);
            else setButtonUnProf(perceptionButton);
            if (stats.getPerformance().prof) setButtonProf(performanceButton);
            else setButtonUnProf(performanceButton);
            if (stats.getPersuasion().prof) setButtonProf(persuasionButton);
            else setButtonUnProf(persuasionButton);
            if (stats.getReligion().prof) setButtonProf(religionButton);
            else setButtonUnProf(religionButton);
            if (stats.getSOH().prof) setButtonProf(sohButton);
            else setButtonUnProf(sohButton);
            if (stats.getStealth().prof) setButtonProf(stealthButton);
            else setButtonUnProf(stealthButton);
            if (stats.getSurvival().prof) setButtonProf(survivalButton);
            else setButtonUnProf(survivalButton);
        }

        private void setButtonUnProf(Button acrobaticsButton)
        {
            Font font = new Font(acrobaticsButton.Font.Name, acrobaticsButton.Font.Size);
            if (acrobaticsButton.Text.StartsWith("+"))
            {
                acrobaticsButton.Text = acrobaticsButton.Text.Split('+')[1];
            }
            acrobaticsButton.Font = font;
        }

        private void setButtonProf(Button acrobaticsButton)
        {
            Font bfont = new Font(acrobaticsButton.Font.Name, acrobaticsButton.Font.Size, FontStyle.Bold);
            if (acrobaticsButton.Text.StartsWith("+")) return;
            acrobaticsButton.Font = bfont; acrobaticsButton.Text = "+" + acrobaticsButton.Text + "+";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                path = openFileDialog1.FileName;
                this.bestiary.AddRange(checkDuplicates(JsonParser.importBestiary(path)));
                this.bestiary = this.bestiary.OrderBy(x => x.getName()).ToList();
                joinInitButton.Text = bestiary.Count.ToString();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void atkNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void atkBonusListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void atkDmgListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void traitsListBox_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void resetAll()
        {
            
            traitsListBox.Items.Clear();
        }

        private void itemQuantListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void itemNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JsonParser.saveBestiary(this.bestiary, @"C:\Xeys DnD Player\");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.bestiary.AddRange(checkDuplicates(JsonParser.loadBestiary(@"C:\Xeys DnD Player\bestiary.json")));
            this.bestiary= this.bestiary.OrderBy(x => x.getName()).ToList();
            label1.Text = this.bestiary.Count .ToString();
        }

        private List<Enemy> checkDuplicates(List<Enemy> list)
        {
            List<Enemy> nonDuplicates = new List<Enemy>();
            bool duplicate;
            
            foreach(Enemy a in list)
            {
                duplicate = false;
                foreach(Enemy b in this.bestiary)
                {
                    if (a.getName().Equals(b.getName())) duplicate = true;
                }
                if (!duplicate) nonDuplicates.Add(a);
                
            }
            return nonDuplicates;

            
        }

        private void tableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CharSheet_Shown(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void traitsListBox_DoubleClick_1(object sender, EventArgs e)
        {
            string desc = ((CharTrait)traitsListBox.SelectedItem).getDesc();
            string title = ((CharTrait)traitsListBox.SelectedItem).getTitle();
            MessageBox.Show(desc, title, MessageBoxButtons.OK);
        }

        private void tableLayoutPanel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void maxHpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (maxHpTextBox.Text.StartsWith("+") || maxHpTextBox.Text.StartsWith("-"))
                {
                    int.TryParse(maxHpTextBox.Text, out int result);
                    Character.charackter.addMaxHp(result);
                    maxHpTextBox.Text = Character.charackter.GetStats().hp[0].ToString();
                }
                else
                {
                    int.TryParse(maxHpTextBox.Text, out int result);
                    Character.charackter.setMaxHp(result);

                }
            }
        }

        

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void traitsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void topTableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void atkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showAttack((Attacks)atkListBox.SelectedItem);
        }

        private void showAttack(Attacks selectedItem)
        {
            atkModValLabel.Text = selectedItem.getBonus().ToString();
            dmgValLabel.Text = selectedItem.getDamageString();
            dmgTypeValLabel.Text = selectedItem.getType();
        }

        private void longRestButton_Click(object sender, EventArgs e)
        {
            longRest();
        }

        private void longRest()
        {
            Character.charackter.doLongRest();
            updateForm(Character.charackter);

        }

        private void shortRestButton_Click(object sender, EventArgs e)
        {
            shortRest();
        }

        private void shortRest()
        {
            Character.charackter.doShortRest();
            askToSpendHitDie();
        }

        private void askToSpendHitDie()
        {
            throw new NotImplementedException();
        }

        private void rollTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void currentHpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tempHpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void splitterLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
