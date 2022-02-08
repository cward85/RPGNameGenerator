using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGGroupNameGenerator
{
    public partial class RPGGroupNameGenerator : Form
    {
        List<string> AdjectivesList;
        List<string> NounsList;
        List<string> PlacesList;
        List<string> ModifiersList;

        List<List<string>> MasterNamesList;

        enum SentenceStructure : int
        {
            Adjectives = 0, Nouns = 1, Places = 2, Modifiers = 3
        }

        List<int>[] SentenceOrder = new List<int>[]
        {
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Nouns, (int)SentenceStructure.Modifiers, (int)SentenceStructure.Places },
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Nouns },
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Nouns },
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Nouns },
            new List<int> { (int)SentenceStructure.Nouns, (int)SentenceStructure.Modifiers, (int)SentenceStructure.Adjectives, (int)SentenceStructure.Places },
            new List<int> { (int)SentenceStructure.Nouns, (int)SentenceStructure.Modifiers, (int)SentenceStructure.Places },
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Nouns, (int)SentenceStructure.Modifiers, (int)SentenceStructure.Adjectives, (int)SentenceStructure.Places },
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Places, (int)SentenceStructure.Nouns},
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Places, (int)SentenceStructure.Nouns},
            new List<int> { (int)SentenceStructure.Adjectives, (int)SentenceStructure.Places, (int)SentenceStructure.Nouns},
        };
        
        Random RandomNumberGenerator = new Random();

        public RPGGroupNameGenerator()
        {
            InitializeComponent();           
        }

        private bool PopulateLists()
        {
            AdjectivesList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings["Adjectives"].ToString());
            NounsList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings["Nouns"].ToString());
            PlacesList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings["Places"].ToString());
            ModifiersList = ReadCommaDelineatedFile(ConfigurationManager.AppSettings["Modifiers"].ToString());
            MasterNamesList = new List<List<string>> { AdjectivesList, NounsList, PlacesList, ModifiersList };

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

        private List<string> DetermineOrder()
        {
            int randomNumber = RandomNumberGenerator.Next(0, SentenceOrder.Count());

            List<int> listNumber = SentenceOrder[randomNumber];
            List<string> packName = new List<string>();
            
            foreach(int number in listNumber)
            {
                int index = RandomNumberGenerator.Next(0, MasterNamesList[number].Count());            
                packName.Add(MasterNamesList[number][index]);
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
    }
}
