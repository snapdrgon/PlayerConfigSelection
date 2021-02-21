using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerConfigSelection
{
    public partial class ConfigDialog : Form
    {
        public ConfigDialog()
        {
            InitializeComponent();
        }

        public Dictionary<string, CharacterStatus> charList { get; set; }

        private void ConfigDialog_Load(object sender, EventArgs e)
        {
            CharacterSelect cs = new CharacterSelect();
            if (cs.NotFoundSaveDir) //couldn't find the Save Directory so make them find it
            {
                cs.SavePath = SetSavePath();
            }
            charList = cs.CharacterList();
            this.checkedListBox1.Items.Clear();
            foreach (var character in charList)
            {
                this.checkedListBox1.Items.Add(character.Key, !character.Value.Hide);
            } 
            
        }

        public string SetSavePath()
        {
            //setup the folder browser
            string path = null;
            this.folderBrowserDialog1.Description = "Select the directory your Skyrim Saves are located at.";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
            }
            return path;
        }

        private void CharacterSelectButton_Click(object sender, EventArgs e)
        {
            //      SendCharacterStatus();
            EnableDisableControls(false);
            this.Cursor = Cursors.WaitCursor;
            backgroundWorker1.RunWorkerAsync();
        }

        private void selectCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //      SendCharacterStatus();
            EnableDisableControls(false);
            this.Cursor = Cursors.WaitCursor;
            backgroundWorker1.RunWorkerAsync();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetResetCheckBoxes(true);
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetResetCheckBoxes(false);
        }

        private void SetResetCheckBoxes(bool flag)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, flag);
            }
        }

        private void SendCharacterStatus()
        {
            try
            {
                CharacterSelect cs = new CharacterSelect();
                cs.CharacterDictionary = new Dictionary<string, CharacterStatus>();
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    cs.CharacterDictionary.Add((string)this.checkedListBox1.Items[i],
                        new CharacterStatus
                        {
                            Hide = checkedListBox1.GetItemCheckState(i) == CheckState.Checked ? false : true,
                            Name = (string)this.checkedListBox1.Items[i]
                        });
                }
                foreach (var character in cs.CharacterDictionary)
                {
                    Utilities.Utilities.log.Info($"{character.Key} {character.Value.Name} {character.Value.Hide}");
                }

                cs.UpdateFileExtension();
            }
            catch (Exception e)
            {
                Utilities.Utilities.log.Error(Utilities.Utilities.GetExceptionMessage(e));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SendCharacterStatus();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableDisableControls(true);
            this.Cursor = Cursors.Default;

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void EnableDisableControls(bool flag)
        {
            this.contextMenuStrip1.Items[2].Enabled = this.CharacterSelectButton.Enabled = this.buttonClose.Enabled = flag;
        }
    }
} 
