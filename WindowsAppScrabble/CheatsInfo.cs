namespace WindowsAppScrabble
{
    using ClassLibrary;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Linq;
    public partial class CheatsInfo : Form
    {
        public CheatsInfo()
        {
            InitializeComponent();
        }

        Dictionary<string, int> PossibleWords = new Dictionary<string, int>();
        public char[] chars = new char[7];

        public void Listing(string chars)
        {
            this.labelword2.Text = "";
            this.labelword3.Text = "";
            Finding(chars);
            if (!PossibleWords.Any())
            {
                this.labelword2.Text += "No matching words.\n";
            }

            var sortedPossibleWords = from entry in PossibleWords orderby entry.Value descending select entry;
            foreach (var word in sortedPossibleWords)
            {
                this.labelword2.Text += word.Key + "\n";
                this.labelword3.Text += "Points: " + word.Value + "\n";
            }
        }

        public void Finding(string chars)
        {
            AllCombinations.GetCombinations(chars);
            PossibleWords.Clear();

            foreach (string combination in AllCombinations.combinations)
            {
                var index = TextConverter.TextToNumber(combination[0].ToString());

                string finded = WordsFinder.Find(combination, WordsReader.AllWords[index - 1]);
                if (!finded.Equals(WordsFinder.noWords))
                {
                    PossibleWords[finded] = Counter.Points(finded);
                }

            }
        }

        private void refresh(object sender, EventArgs e)
        {
            //Clear labels
            this.labelword3.Text = "";
            this.labelword2.Text = "";

            foreach (var word in PossibleWords)
            {
                this.labelword2.Text += word.Key + "\n";
                this.labelword3.Text += "Points: " + word.Value + "\n";
            }
        }
    }
}
