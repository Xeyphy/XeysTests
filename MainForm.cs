using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Xeys_DnD_Player
{
    public partial class MainForm : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        

        //Constructor
        public MainForm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel1.Controls.Add(leftBorderBtn);
            string path = @"C:\Xeys DnD Player\Charackter.json";
            Character.charackter = JsonParser.loadCharacter(path);
            if (Character.charackter == null)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                    Character.charackter = JsonParser.importCharacter(path);
                    ActivateButton(charSheetButton, RGBColors.color1);
                    if (Character.charackter != null)
                    {
                        string json = JsonConvert.SerializeObject(Character.charackter, Formatting.Indented);
                        OpenChildForm(new CharSheet(json));
                        JsonParser.SaveCharacter(Character.charackter, path);
                        this.Activate();
                        //updatePicture();

                    }

                }
            }
            updateFormHeader();
            pictureBox1.Image=GetImageFromURL(Character.charackter.getImageUrl());
            
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
            }
        }
        private static Image GetImageFromURL(string url)
        {
            if (url == null)
            {
                return null;
            }
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebReponse.GetResponseStream();
            return Image.FromStream(stream);
        }
        private void updateFormHeader()
        {
            charNameLabel.Text = Character.charackter.getName();
            classLevelLabel.Text = Character.charackter.getClassLevel();
            backgroundLabel.Text = Character.charackter.getBackground();
            alignmentLabel.Text = Character.charackter.getAlignment();
            

        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
        }

        //Events
        //Reset
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }
        //Menu Button_Clicks


       

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Close-Maximize-Minimize
        private void btnExit_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void charSheetButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            if (Character.charackter != null)
            {
                string json=JsonConvert.SerializeObject(Character.charackter, Formatting.Indented);
                OpenChildForm(new CharSheet(json));
            }
            else
            {
                Character.charackter = JsonParser.loadCharacter(@"C:\Xeys DnD Player\Charackter.json");
                string json = JsonConvert.SerializeObject(Character.charackter, Formatting.Indented);
                OpenChildForm(new CharSheet(json));
            }
            
        }

        private void spellBookButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new SpellBook());
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Inventory());
        }

        private void Notebook_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new NoteBook());
        }

        private void globalSpellbook_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new SpellBook(true));
        }

        private void dmScreenButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new DMScreen());
        }

        private void beastearyButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new BeastearyForm());
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Settings());
        }

        private void iconClose_Click(object sender, EventArgs e)
        {

            JsonParser.SaveCharacter(Character.charackter, @"C:\Xeys DnD Player\Charackter.json");
            Application.Exit();

        }

        private void iconMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string path = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                path = openFileDialog1.FileName;
                Character.charackter = JsonParser.importCharacter(path);
                ActivateButton(charSheetButton, RGBColors.color1);
                if (Character.charackter != null)
                {
                    string json = JsonConvert.SerializeObject(Character.charackter, Formatting.Indented);
                    OpenChildForm(new CharSheet(json));
                    updatePicture();

                }
                updateFormHeader();
               
            }
        }

        private void updatePicture()
        {
            pictureBox1.Image = GetImageFromURL(Character.charackter.getImageUrl());
        }

        private void panelShadow_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
