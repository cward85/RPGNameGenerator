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
        List<KeyValuePair<SentenceStructure, List<string>>> MasterNamesList;                
       
        Random RandomNumberGenerator = new Random();

        public RPGGroupNameGenerator()
        {
            InitializeComponent();
            this.ActiveControl = txtNumberOfNames;
        }

        #region Functions

        private bool PopulateLists()
        {
            List<string> AdjectivesList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Adjectives.ToString()]);
            List<string> NounsList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Nouns.ToString()]);
            List<string> PlacesList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Places.ToString()]);
            List<string> ModifiersList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings[SentenceStructure.Modifiers.ToString()]);

            MasterNamesList = new List<KeyValuePair<SentenceStructure, List<string>>> 
            {   
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Adjectives, AdjectivesList),
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Nouns, NounsList),
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Places, PlacesList),
                new KeyValuePair<SentenceStructure, List<string>> (SentenceStructure.Modifiers, ModifiersList)
            };
                   
            return ValidateLists(MasterNamesList);            
        }

        private bool ValidateLists(List<KeyValuePair<SentenceStructure, List<string>>> p_lstSentenceParts)
        {
            string strErrorMessage = string.Empty;

            foreach(KeyValuePair<SentenceStructure, List<string>> sentencePart in p_lstSentenceParts)
            {
                if (sentencePart.Value.Count == 0)
                {
                    strErrorMessage += "Go into your settings to select " + DetermineIfVowel(sentencePart.Key.ToString()) + sentencePart.Key.ToString() + " list that is not empty.\n";
                }
            }

            if (strErrorMessage.Length > 0)
            {
                MessageBox.Show(strErrorMessage, "Error Generating Names");

                return false;
            }

            return true;
        }

        private string DetermineIfVowel(string p_strWord)
        {
            if (p_strWord.StartsWith("A") || p_strWord.StartsWith("E") || p_strWord.StartsWith("O") || p_strWord.StartsWith("I") || p_strWord.StartsWith("U") || p_strWord.StartsWith("Y"))
            {
                return "an ";
            }

            return "a";
        }

        private List<List<SentenceStructure>> GetSentenceStructure()
        {
            string strSentences = File.ReadAllText(Constants.SENTENCE_STRUCTURE_PATH);
            
            List<List<SentenceStructure>> allSentenceStructuresLists = new List<List<SentenceStructure>>();
            strSentences.Split(';').ToList<string>().ForEach(x =>
            {
                List<SentenceStructure> sentenceStructureList = new List<SentenceStructure>();
                x.Split(',').ToList().ForEach(y => sentenceStructureList.Add((SentenceStructure)Enum.Parse(typeof(SentenceStructure), y)));
                allSentenceStructuresLists.Add(sentenceStructureList);
            });

            return allSentenceStructuresLists;           
        }       

        private List<string> DetermineOrder()
        {
            List<List<SentenceStructure>> sentenceOrder = GetSentenceStructure();
            int randomNumber = RandomNumberGenerator.Next(0, sentenceOrder.Count());

            List<SentenceStructure> structureList = sentenceOrder[randomNumber];
            List<string> packName = new List<string>();
            
            foreach(SentenceStructure structure in structureList.Where(x => x != SentenceStructure.None))
            {               
                randomNumber = RandomNumberGenerator.Next(0, MasterNamesList.Where(x => x.Key == structure).Single().Value.Count());
                packName.Add(MasterNamesList.Where(x => x.Key == structure).Single().Value[randomNumber]);                
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

                if (objFileContents.Length != 0)
                {
                    return objFileContents.Split(',').Select(x => x.Trim()).ToList<string>();
                }               
            }
            
            return new List<string>();                        
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
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnGenerate.PerformClick();
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
