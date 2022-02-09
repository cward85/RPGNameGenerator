using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RPGGroupNameGenerator
{
    public partial class GeneratorSettings : Form
    {       
        public GeneratorSettings()
        {
            InitializeComponent();
            InitializeFiles();
            PopulateTextBoxes();
            PopulateGrid();
        }

        #region Functions

        private void OpenFileDialogBox(string p_strConfigSection, TextBox txtBox)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string strFullPath = string.Empty;

                openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Dictionary";
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strFullPath = openFileDialog.FileName;
                    txtBox.Text = openFileDialog.FileName.Split('\\').Last();
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = config.AppSettings.Settings;
                    settings[p_strConfigSection].Value = strFullPath;
                    config.Save();

                    ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                }
            }
        }

        private void PopulateTextBoxes()
        {
            txtAdjective.Text = ConfigurationManager.AppSettings[SentenceStructure.Adjectives.ToString()].Split('\\').Last();
            txtNoun.Text = ConfigurationManager.AppSettings[SentenceStructure.Nouns.ToString()].Split('\\').Last();
            txtPlace.Text = ConfigurationManager.AppSettings[SentenceStructure.Places.ToString()].Split('\\').Last();
            txtModifier.Text = ConfigurationManager.AppSettings[SentenceStructure.Modifiers.ToString()].Split('\\').Last();
        }

        private void PopulateGrid()
        {
            grdSentenceStructure.Columns.Add("First", "First");
            grdSentenceStructure.Columns.Add("Second", "Second");
            grdSentenceStructure.Columns.Add("Third", "Third");
            grdSentenceStructure.Columns.Add("Fourth", "Fourth");
            grdSentenceStructure.Columns.Add("Fifth", "Fifth");
            grdSentenceStructure.Columns.Add("Sixth", "Sixth");
            
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.HeaderText = "Delete";
            
            grdSentenceStructure.Columns.Add(deleteButton);

            List<string> wholeSentenceList = File.ReadAllText(Constants.SENTENCE_STRUCTURE_PATH).Split(';').Select(x => x.Trim()).Where(y => y.Length > 0).ToList<string>();
            
            for (int i = 0; i < wholeSentenceList.Count; i++)
            {
                grdSentenceStructure.Rows.Add(new DataGridViewRow());
                List<string> singleSentence = wholeSentenceList[i].Split(',').Select(x => x.Trim()).ToList<string>();
                for (int j = 0; j < singleSentence.Count; j++)
                {
                    var comboBox = new DataGridViewComboBoxCell();
                    comboBox.DataSource = new List<string> { SentenceStructure.None.ToString(), SentenceStructure.Adjectives.ToString(), SentenceStructure.Nouns.ToString(), SentenceStructure.Modifiers.ToString(), SentenceStructure.Places.ToString() };
                    comboBox.Value = singleSentence[j];
                    
                    grdSentenceStructure[j, i] = comboBox;
                }

                
            }            
        }

        private void InitializeFiles()
        {
            if (!File.Exists(Constants.SENTENCE_STRUCTURE_PATH))
            {
                using (File.Create(Constants.SENTENCE_STRUCTURE_PATH))
                { }

            }
        }

        private void SaveGrid()
        {
            if (grdSentenceStructure.Rows.Count > 0)
            {
                string strSentenceStructure = string.Empty;

                for (int i = 0; i < grdSentenceStructure.Rows.Count; i++)
                {
                    for (int j = 0; j < grdSentenceStructure.Columns.Count - 1; j++)
                    {
                        strSentenceStructure += ((DataGridViewComboBoxCell)grdSentenceStructure[j, i]).Value + ",";
                    }

                    strSentenceStructure = strSentenceStructure.Remove(strSentenceStructure.Length - 1);
                    strSentenceStructure += ";";
                }

                strSentenceStructure = strSentenceStructure.Remove(strSentenceStructure.Length - 1);

                File.WriteAllText(Constants.SENTENCE_STRUCTURE_PATH, strSentenceStructure);
            }

        }

        #endregion

        #region Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            InitializeFiles();

            SaveGrid();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAdjectiveFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(SentenceStructure.Adjectives.ToString(), txtAdjective);
        }

        private void btnNounFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(SentenceStructure.Nouns.ToString(), txtNoun);
        }

        private void btnPlaceFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(SentenceStructure.Places.ToString(), txtPlace);
        }

        private void btnModifierFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(SentenceStructure.Modifiers.ToString(), txtModifier);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            grdSentenceStructure.Rows.Add(new DataGridViewRow());
            for (int i = 0; i < grdSentenceStructure.Rows[grdSentenceStructure.Rows.Count - 1].Cells.Count - 1; i++)
            {
                var comboBox = new DataGridViewComboBoxCell();
                comboBox.DataSource = new List<string> { SentenceStructure.None.ToString(), SentenceStructure.Adjectives.ToString(), SentenceStructure.Nouns.ToString(), SentenceStructure.Modifiers.ToString(), SentenceStructure.Places.ToString() };
                comboBox.Value = SentenceStructure.None.ToString();

                grdSentenceStructure.Rows[grdSentenceStructure.Rows.Count - 1].Cells[i] = comboBox;
            }
        }

        private void grdSentenceStructure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == grdSentenceStructure.Columns["btnDelete"].Index)
            {
                grdSentenceStructure.Rows.RemoveAt(e.RowIndex);
            }
        }

        #endregion
    }
}
