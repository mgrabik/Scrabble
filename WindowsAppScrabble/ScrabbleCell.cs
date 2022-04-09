namespace WindowsAppScrabble
{
    using System.Windows.Forms;
    using ClassLibrary;

    class ScrabbleCell : Button
    {
        public string ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Unknown { get; set; }
        public bool Countable { get; set; }
        public Bonus Bonus {  get; set; }
        public bool IsClicked { get; set; }

        public void Clear()
        {
            this.Text = string.Empty;
            this.Unknown = true;
        }
    }
}
