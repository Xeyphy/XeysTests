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
    public partial class NoteBook : Form
    {
        List<Note> notes = new List<Note>();
        public NoteBook()
        {
            InitializeComponent();
            notes = JsonParser.getNotes(@"C:\Xeys DnD Player\Notes.json");
            updateNoteBook();
        }

        private void updateNoteBook()
        {
            listBox1.Items.Clear();
            if(notes!=null && notes.Count>0) listBox1.Items.AddRange(notes.ToArray());
            richTextBox1.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Note n = (Note)listBox1.SelectedItem;
            if (n != null)
            {
                richTextBox1.Text = n.getText() ?? "noTExt";
                if (listBox1.SelectedItem != null)
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            notes.Add(new Note(textBox1.Text, ""));
            JsonParser.saveNotes(notes, @"C:\Xeys DnD Player\");
            updateNoteBook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Note n = (Note)listBox1.SelectedItem;
            n.saveText(richTextBox1.Text);
            JsonParser.saveNotes(notes, @"C:\Xeys DnD Player\");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Note n = (Note)listBox1.SelectedItem;
            notes.Remove(n);
            JsonParser.saveNotes(notes, @"C:\Xeys DnD Player\");
            updateNoteBook();
        }
    }
}
