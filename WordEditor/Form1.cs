using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WordEditor
{
    public partial class Form1 : Form
    {
        string filePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        //  TEXT CHANGED (WORD COUNT) 
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int words = richTextBox1.Text.Split(
                new char[] { ' ', '\n', '\t' },
                StringSplitOptions.RemoveEmptyEntries
            ).Length;

            toolStrip1.Text = "Words: " + words;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) { }

        //  FILE OPERATIONS 

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            filePath = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File|*.txt|Rich Text|*.rtf";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;

                if (Path.GetExtension(filePath) == ".rtf")
                    richTextBox1.LoadFile(filePath);
                else
                    richTextBox1.Text = File.ReadAllText(filePath);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text|*.rtf|Text File|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filePath = sfd.FileName;
                SaveFile();
            }
        }

        private void SaveFile()
        {
            if (filePath == "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Rich Text|*.rtf|Text File|*.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    filePath = sfd.FileName;
                }
            }

            if (Path.GetExtension(filePath) == ".rtf")
                richTextBox1.SaveFile(filePath);
            else
                File.WriteAllText(filePath, richTextBox1.Text);
        }

        //  EDIT MENU

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        //  FORMAT 

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFont(FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFont(FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFont(FontStyle.Underline);
        }

        private void ToggleFont(FontStyle style)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font f = richTextBox1.SelectionFont;
                richTextBox1.SelectionFont = new Font(f, f.Style ^ style);
            }
        }

        //  TOOLBAR BUTTONS 

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print feature demo only (you can extend it)");
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Word Editor Project\nBuilt in C# WinForms");
        }

        private void helpToolStripButton_Click_1(object sender, EventArgs e)
        {
            helpToolStripButton_Click(sender, e);
        }

        //  OTHER MENUS 

        private void editToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void formatToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void viewToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}