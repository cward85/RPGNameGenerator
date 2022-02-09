using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RPGGroupNameGenerator
{
    public partial class RPGGroupNameGenerator : Form
    {
        List<string> AdjectivesList;
        List<string> NounsList;
        List<string> PlacesList;
        List<string> ModifiersList;
        List<KeyValuePair<SentenceStructure, List<string>>> MasterNamesList;                
        List<List<SentenceStructure>> SentenceOrder;        
        Random RandomNumberGenerator = new Random();

        public RPGGroupNameGenerator()
        {
            InitializeComponent();            
        }

        #region Functions

        private bool PopulateLists()
        {
            AdjectivesList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Adjectives.ToString()]);
            NounsList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Nouns.ToString()]);
            PlacesList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Places.ToString()]);
            ModifiersList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Modifiers.ToString()]);
            MasterNamesList = new List<KeyValuePair<SentenceStructure, List<string>>> 
            {   
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Adjectives, AdjectivesList),
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Nouns, NounsList),
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Places, PlacesList),
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Modifiers, ModifiersList)
            };
            SentenceOrder = GetSentenceStructure();

            return ValidateLists();            
        }

        private bool ValidateLists()
        {
            string strErrorMessage = string.Empty;

            if (AdjectivesList.Count == 0)
            {
                strErrorMessage += "Please go into your settings to select an Adjective list that is not empty.\n";
            }

            if (NounsList.Count == 0)
            {
                strErrorMessage += "Please go into your settings to select a Noun list that is not empty.\n";
            }

            if (PlacesList.Count == 0)
            {
                strErrorMessage += "Please go into your settings to select a Place list that is not empty.\n";
            }

            if (ModifiersList.Count == 0)
            {
                strErrorMessage += "Please go into your settings to select a Modifier list that is not empty.\n";
            }

            if (strErrorMessage.Length > 0)
            {
                MessageBox.Show(strErrorMessage, "Error Generating Names");

                return false;
            }

            return true;
        }

        private List<List<SentenceStructure>> GetSentenceStructure()
        {
            string strSentences = File.ReadAllText(Constants.SENTENCE_STRUCTURE_PATH);
            List<string> sentences = strSentences.Split(';').ToList<string>();
            
            List<List<SentenceStructure>> structureList = new List<List<SentenceStructure>>();

            for (int i = 0; i < sentences.Count; i++)
            {
                List<SentenceStructure> structure = new List<SentenceStructure>();
                for (int j = 0; j < sentences[i].Split(',').Length; j++)
                {                    
                    structure.Add((SentenceStructure)Enum.Parse(typeof(SentenceStructure), sentences[i].Split(',')[j]));
                }

                structureList.Add(structure);
            }

            return structureList;
        }       

        private List<string> DetermineOrder()
        {
            int randomNumber = RandomNumberGenerator.Next(0, SentenceOrder.Count());

            List<SentenceStructure> structureList = SentenceOrder[randomNumber];
            List<string> packName = new List<string>();
            
            foreach(SentenceStructure structure in structureList)
            {
                if (structure != SentenceStructure.None)
                {
                    int index = RandomNumberGenerator.Next(0, MasterNamesList.Where(x => x.Key == structure).Single().Value.Count());
                    packName.Add(MasterNamesList.Where(x => x.Key == structure).Single().Value[index]);
                }
            }

            return packName;
        }

        private void PrintName(List<string> packName)
        {
            foreach(string name in packName)
            {
                txtNames.AppendText(name + " ");
            }

            txtNames.AppendText(Environment.NewLine);
        }
        
        private List<string> ReadCommaDelineatedFile(string p_strPath)
        {
            if (File.Exists(p_strPath))
            {
                string objFileContents = File.ReadAllText(p_strPath);

                return objFileContents.Split(',').Select(x => x.Trim()).ToList<string>();
            }
            else
            {               
                return new List<string>();
            }            
        }

        #endregion

        #region Events

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (PopulateLists())
            {
                txtNames.Clear();

                for (int i = 0; i < int.Parse(txtNumberOfNames.Text); i++)
                {
                    List<string> packNameList = DetermineOrder();
                    PrintName(packNameList);
                }
            }
        }

        private void txtNumberOfNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            GeneratorSettings form = new GeneratorSettings();

            form.ShowDialog();
        }
        
        #endregion
    }
}
