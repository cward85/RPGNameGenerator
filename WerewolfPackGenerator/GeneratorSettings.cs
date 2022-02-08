using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGGroupNameGenerator
{
    public partial class GeneratorSettings : Form
    {
        const string ADJECTIVES = "Adjectives";
        const string NOUNS = "Nouns";
        const string PLACES = "Places";
        const string MODIFIERS = "Modifiers";

        public GeneratorSettings()
        {
            InitializeComponent();
            PopulateTextBoxes();
        }

        private void btnAdjectiveFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(ADJECTIVES, txtAdjective);            
        }

        private void btnNounFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(NOUNS, txtNoun);
        }

        private void btnPlaceFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(PLACES, txtPlace);
        }

        private void btnModifierFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialogBox(MODIFIERS, txtModifier);
        }

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
            txtAdjective.Text = ConfigurationManager.AppSettings[ADJECTIVES].Split('\\').Last();
            txtNoun.Text = ConfigurationManager.AppSettings[NOUNS].Split('\\').Last();
            txtPlace.Text = ConfigurationManager.AppSettings[PLACES].Split('\\').Last();
            txtModifier.Text = ConfigurationManager.AppSettings[MODIFIERS].Split('\\').Last();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
