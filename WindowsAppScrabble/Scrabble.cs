namespace WindowsAppScrabble
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ClassLibrary;
    public partial class Scrabble : Form
    {
        public Scrabble()
        {
            InitializeComponent();
            createCells();
            createYourPanel();
            saveAllWords();
        }

        ScrabbleCell[,] cells = new ScrabbleCell[15, 15];
        ScrabbleCell[,] yourCells = new ScrabbleCell[8, 1];
        ListofPoints listOfPoints = new ListofPoints();
        List<ScrabbleCell> chosenLetters = new List<ScrabbleCell>();
        List<int> ids = new List<int>();
        List<Tuple<int, int>> pairs = new List<Tuple<int, int>>(); // Column-Row
        char[,] playersLetters = new char[4, 7];

        List<(int, int)> tempCoord = new List<(int, int)>();
        List<List<(int, int)>> WordsCoordinates = new List<List<(int, int)>>();

        private int letterChosenCounter = 0;
        private bool firstMove = true;
        public static bool cheatIsOpen = false;

        // Color definitions
        private Color RedColor =  Color.FromArgb(255, 77, 77);
        private Color OrangeColor = Color.FromArgb(255, 173, 51);
        private Color BackgroundColor = SystemColors.ControlLightLight;


        private void createCells()
        {
            for (int col = 0; col < 15; col++)
            {
                for (int row = 0; row < 15; row++)
                {
                    cells[col, row] = new ScrabbleCell();
                    cells[col, row].Size = new Size(50, 50);
                    cells[col, row].Font = new Font(SystemFonts.DefaultFont.FontFamily, 14);
                    cells[col, row].ForeColor = Color.Black;
                    cells[col, row].Location = new Point(col * 50, row * 50);
                    cells[col, row].BackColor = BackgroundColor;
                    cells[col, row].FlatStyle = FlatStyle.Flat;
                    cells[col, row].FlatAppearance.BorderColor = Color.Black;
                    cells[col, row].X = col;
                    cells[col, row].Y = row;
                    cells[col, row].Bonus = Bonus.Null;
                    cells[col, row].Countable = false;
                    cells[col, row].Unknown = true;
                    cells[col, row].IsClicked = false;
                    cells[col, row].Text = "";

                    //cells[col, row].KeyPress += cell_KeyPressed;
                    cells[col, row].Click += new System.EventHandler(this.writeLetter);

                    //Coloring
                    RepositoryBonuses dic = new RepositoryBonuses();

                    //Word triple Bonus
                    if (dic.WordTriple.ContainsKey(col) && dic.WordTriple[col].Contains(row))
                    {
                        cells[col, row].BackColor = Color.Red;
                        cells[col, row].Text = "3W";
                        cells[col, row].Countable = false;
                        cells[col, row].Bonus = Bonus.TripleWord;
                    }

                    //Word double Bonus
                    if (dic.WordDouble.ContainsKey(col) && dic.WordDouble[col].Contains(row))
                    {
                        cells[col, row].BackColor = Color.Pink;
                        cells[col, row].Text = "2W";
                        cells[col, row].Countable = false;
                        cells[col, row].Bonus = Bonus.DoubleWord;
                    }

                    //Letter triple Bonus
                    if (dic.LetterTriple.ContainsKey(col) && dic.LetterTriple[col].Contains(row))
                    {
                        cells[col, row].BackColor = Color.FromArgb(0, 102, 255);
                        cells[col, row].Text = "3L";
                        cells[col, row].Countable = false;
                        cells[col, row].Bonus = Bonus.TripleLetter;
                    }

                    //Letter double Bonus
                    if (dic.LetterDouble.ContainsKey(col) && dic.LetterDouble[col].Contains(row))
                    {
                        cells[col, row].BackColor = Color.FromArgb(128, 229, 255);
                        cells[col, row].Text = "2L";
                        cells[col, row].Countable = false;
                        cells[col, row].Bonus = Bonus.DoubleLetter;
                    }

                    mainBoard_panel.Controls.Add(cells[col, row]);
                }
            }
            cells[7, 7].Image = System.Drawing.Image.FromFile(@"..\..\..\Assets\Star.jpg");
        }
        private void writeLetter(object sender, EventArgs e)
        {
            var cell = sender as ScrabbleCell;
            try
            {
                if (!cell.IsClicked && chosenLetters.Count != 0 && chosenLetters[ids[0] - 1] != null && cell.Letter == "")
                {
                    chosenLetters[ids[0]-1].BackColor = RedColor;
                    cell.BackColor = OrangeColor;
                    cell.Text = chosenLetters[ids[0]-1].Text;
                    cell.Letter = chosenLetters[ids[0] - 1].Text;
                    cell.ID = chosenLetters[ids[0]-1].ID;
                    cell.IsClicked = true;
                    cell.Countable = false;
                    pairs.Add(new Tuple<int, int>(cell.X, cell.Y));
                    letterChosenCounter++;
                    ids.RemoveAt(0);
                    return;
                }
                if (cell.IsClicked)
                {
                    int clickedCell = 1;
                    foreach (var tempCell in chosenLetters)
                    {
                        if (cell.ID == tempCell.ID)
                        {
                            break;
                        }
                        clickedCell++;
                    }
                    letterChosenCounter--;
                    ids.Insert(0, clickedCell);
                    pairs.RemoveAt(pairs.IndexOf(Tuple.Create(cell.X, cell.Y)));
                    chosenLetters[clickedCell - 1].BackColor = OrangeColor;
                    cell.BackColor = BackgroundColor;
                    cell.Text = "";
                    cell.Letter = "";
                    cell.IsClicked = false;
                    cell.Countable = true;

                    switch (cell.Bonus)
                    {
                        case Bonus.DoubleLetter:
                            cell.Text = "2L";
                            cell.BackColor = Color.FromArgb(128, 229, 255);
                            break;
                        case Bonus.TripleLetter:
                            cell.Text = "3L";
                            cell.BackColor = Color.FromArgb(0, 102, 255);
                            break;
                        case Bonus.DoubleWord:
                            cell.Text = "2W";
                            cell.BackColor = Color.Pink;
                            break;
                        case Bonus.TripleWord:
                            cell.Text = "3W";
                            cell.BackColor = Color.Red;
                            break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("ERROR!");
            }

        }
        private void createYourPanel()
        {
            for (int col = 0; col < 7; col++)
            {
                int row = 0;
                yourCells[col, row] = new ScrabbleCell();
                yourCells[col, row].Size = new Size(50, 50);
                yourCells[col, row].Font = new Font(SystemFonts.DefaultFont.FontFamily, 14);
                yourCells[col, row].ForeColor = Color.Black;
                yourCells[col, row].Location = new Point(col * 50, row * 50);
                yourCells[col, row].BackColor = BackgroundColor;
                yourCells[col, row].FlatStyle = FlatStyle.Flat;
                yourCells[col, row].FlatAppearance.BorderColor = Color.Black;
                yourCells[col, row].X = col;
                yourCells[col, row].Y = row;
                yourCells[col, row].Click += new System.EventHandler(this.chooseLetter);

                playerBoard_panel.Controls.Add(yourCells[col, row]);
            }
        }
        private void chooseLetter(object sender, EventArgs e)
        {
            ScrabbleCell cell = (ScrabbleCell)sender;
            if (!cell.IsClicked)
            {
                cell.IsClicked = true;
                cell.BackColor = OrangeColor;
                chosenLetters.Add(cell);
                ids.Add(chosenLetters.Count);
            }
            else if(cell.IsClicked && cell.BackColor == OrangeColor)// && letterChosenCounter == 0
            {
                cell.IsClicked = false;
                cell.BackColor = BackgroundColor;
                chosenLetters.Remove(cell);
                ids.RemoveAt(ids.Count - 1);
            }
        }
        private void saveAllWords()
        {
            WordsReader reader = new WordsReader();
            reader.Words();
        }
        private void startEvent(object sender, EventArgs e)
        {
            if (PointsInGame.AmountOfPlayers == 0)
            {
                MessageBox.Show("Set the amout of players before start.", "Warning!");
                return;
            }
            MessageBox.Show("Enjoy the game!\nPlayer 1 starts", "Start game");
            clearBoard();
            GenerateFirst8();
            PointsInGame.Reset();
            this.btnConfirm.Enabled = true;
            this.btnCheat.Enabled = true;
        }
        private void cheatEvent(object sender, EventArgs e)
        {
            CheatsInfo cheatsInfo = new CheatsInfo();

            if (!cheatIsOpen)
            {
                cheatsInfo.Show();
                cheatIsOpen = true;
            }

            //Clear List of all combinations
            AllCombinations.combinations.Clear();
            AllCombinations.combinations.Add("");


            char[] chars = new char[7];
            for (int i = 0; i < 7; i++)
            {
                chars[i] = Convert.ToChar(yourCells[i, 0].Letter);
            }

            cheatsInfo.Listing(new string(chars));
        }
        private void clearBoard() //NOT FINISHED YET
        {
            for (int col = 0; col < 15; col++)
            {
                for (int row = 0; row < 15; row++)
                {
                    if (cells[col, row].Bonus == Bonus.Null)
                    {
                        cells[col, row].Clear(); // ????????????
                        cells[col, row].BackColor = BackgroundColor;
                        cells[col, row].IsClicked = false;
                    }
                }
            }
        }
        private void GenerateFirst8()
        {
            Random random = new Random();

            for (int j = 0; j < PointsInGame.AmountOfPlayers; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    int num = random.Next(0, 26); // 0 to 25
                    char letter = (char)('A' + num);
                    playersLetters[j, i] = letter;
                    listOfPoints.AmountOfLetters[letter.ToString()] = listOfPoints.AmountOfLetters[letter.ToString()] - 1;
                }
            }

            for (int i = 0; i < 7; i++)
            {
                yourCells[i, 0].Text = playersLetters[0, i].ToString();
                yourCells[i, 0].Letter = playersLetters[0, i].ToString();
                yourCells[i, 0].ID = Guid.NewGuid().ToString("N");
            }
        }
        private void confirmEvent(object sender, EventArgs e)
        {
            int letterBonus, wordBonus = 1, pointsPerRound = 0;
            bool areWordsCorrect, isVertical = false;

            if (firstMove && !cells[7, 7].IsClicked)
            {
                MessageBox.Show("The first word has to be placed in the center!", "Warning!");
                return;
            }
            try
            {
                if (pairs.Count == 1)
                {
                    goto Jump;
                }

                //Sorting the tuple
                if (pairs[0].Item2 == pairs[1].Item2)
                {
                    pairs.Sort((x, y) => x.Item1.CompareTo(y.Item1));
                    isVertical = false;
                }
                else if (pairs[0].Item1 == pairs[1].Item1)
                {
                    pairs.Sort((x, y) => x.Item2.CompareTo(y.Item2));
                    isVertical = true;
                }
                else
                {
                    MessageBox.Show("Words are misspelled!\nCorret it!", "Warning!");
                    return;
                }

                Jump:

                if (!isWordProvidedCorrectly(isVertical))
                {
                    MessageBox.Show("Words are misspelled!\nCorret it!", "Warning!");
                    return;
                }

                if (isVertical)
                {
                    areWordsCorrect = checkCreatedWordsWhenVertical(pairs[0].Item1, pairs[0].Item2);
                }
                else
                {
                    areWordsCorrect = checkCreatedWordsWhenHorizontal(pairs[0].Item1, pairs[0].Item2);
                }
                if (!areWordsCorrect)
                {
                    MessageBox.Show("Your word does not exist!\nCorret it!", "Warning!");
                    return;
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("ArgumentOutOfRangeException handled", "Warning!");
                return;
            }

            // Count points of provided word
            foreach (var coord in tempCoord)
            {
                letterBonus = 1;

                letterBonus = getLetterBonus(cells[coord.Item1, coord.Item2].Bonus);
                wordBonus = getWordBonus(cells[coord.Item1, coord.Item2].Bonus);

                pointsPerRound += ListofPoints.LetterPoints[cells[coord.Item1, coord.Item2].Letter] * letterBonus;
            }
            pointsPerRound *= wordBonus;

            letterBonus = 1;
            wordBonus = 1;
            // Count points of additional words
            foreach (var list in WordsCoordinates)
            {
                int wordsPoints = 0;
                foreach (var coord in list)
                {
                    // Get bonuses only on provided letters. The bonuses on earlier provided letters do not matter.
                    if (!cells[coord.Item1, coord.Item2].Countable)
                    {
                        letterBonus = getLetterBonus(cells[coord.Item1, coord.Item2].Bonus);
                        wordBonus = getWordBonus(cells[coord.Item1, coord.Item2].Bonus);
                    }
                    wordsPoints += ListofPoints.LetterPoints[cells[coord.Item1, coord.Item2].Letter] * letterBonus;
                }
                wordsPoints *= wordBonus;
                pointsPerRound += wordsPoints;
            }

            // Save data about points
            PointsInGame.PlayerPoints[PointsInGame.currentPlayer - 1] += pointsPerRound;

            // Update the main board
            foreach (var pair in pairs)
            {
                cells[pair.Item1, pair.Item2].Unknown = false;
                cells[pair.Item1, pair.Item2].Countable = true;
                cells[pair.Item1, pair.Item2].ForeColor = Color.Black;
                cells[pair.Item1, pair.Item2].BackColor = Color.FromArgb(255, 219, 77);
            }

            // Player's panel
            for (int col = 0; col < 7; col++)
            {
                int row = 0;

                // Genering new letters
                if (yourCells[col, row].IsClicked)
                {
                    yourCells[col, row].BackColor = BackgroundColor;
                    Random rnd = new Random();
                    int num;
                    KeyValuePair<string,int> letter;
                    do
                    {
                        num = rnd.Next(0, 26); // 0 to 25
                        letter = listOfPoints.AmountOfLetters.ElementAt(num);
                    }
                    while (letter.Value == 0);
                    listOfPoints.AmountOfLetters[letter.Key]--;

                    playersLetters[PointsInGame.currentPlayer - 1, col] = Convert.ToChar(letter.Key);

                    yourCells[col, row].IsClicked = false;
                }
            }

            // Update points labels
            this.lblPlayer1Points.Text = PointsInGame.PlayerPoints[0].ToString();
            this.lblPlayer2Points.Text = PointsInGame.PlayerPoints[1].ToString();
            this.lblPlayer3Points.Text = PointsInGame.PlayerPoints[2].ToString();
            this.lblPlayer4Points.Text = PointsInGame.PlayerPoints[3].ToString();

            // Update player's panel
            PointsInGame.NextPlayer();
            updatePlayerPanel();


            // Return to default value
            chosenLetters.Clear();
            letterChosenCounter = 0;
            pairs.Clear();
            ids.Clear();

            MessageBox.Show("It is Player "+ PointsInGame.currentPlayer.ToString()+"'s turn", "Next Round!");
            firstMove = false;
        }
        private int getLetterBonus(Bonus bonus)
        {
            if (bonus == Bonus.DoubleLetter)
            {
                return 2;
            }
            else if (bonus == Bonus.TripleLetter)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        private int getWordBonus(Bonus bonus)
        {
            if (bonus == Bonus.DoubleWord)
            {
                return 2;
            }
            else if (bonus == Bonus.TripleWord)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        private bool isWordProvidedCorrectly(bool isVertical)
        {
            if (isVertical)
            {
                int col = pairs[0].Item1;
                for (int row = pairs[0].Item2; row < pairs.Last().Item2; row++)
                {
                    if (cells[col, row].Letter == "")
                    {
                        return false;
                    }
                }
            }
            else
            {
                int row = pairs[0].Item2;
                for (int col = pairs[0].Item1; col < pairs.Last().Item1; col++)
                {
                    if (cells[col, row].Letter == "")
                    {
                        return false;
                    }
                }
            }
            return true;
            
        }
        private bool checkCreatedWordsWhenVertical(int col, int row) // arguments are first pair in sorted tuple
        {
            int end = row + pairs.Count;
            tempCoord.Clear();
            WordsCoordinates.Clear();
            int i, position = 0;
            while (row < end)
            {
                WordsCoordinates.Add(new List<(int, int)>());
                if (cells[col, row].Letter != "")
                {
                    tempCoord.Add((col, row));
                    WordsCoordinates[position].Add((col, row));
                }
                //Up
                i = 1;
                while (row - i >= 0 && cells[col, row - i].Letter != "" && cells[col, row - i].Countable)
                {
                    tempCoord.Insert(0, (col, row - i));
                    i++;
                }
                //Down
                i = 1;
                while (row + i <= 14 && cells[col, row + i].Letter != "" && cells[col, row + i].Countable)
                {
                    tempCoord.Add((col, row + i));
                    i++;
                }
                //Left
                i = 1;
                while (col - i >= 0 && cells[col - i, row].Text != "" && cells[col - i, row].Countable)
                {
                    WordsCoordinates[position].Insert(0, (col - i, row));
                    i++;
                }
                //Right
                i = 1;
                while (col + i <= 14 && cells[col + i, row].Text != "" && cells[col + i, row].Countable)
                {
                    WordsCoordinates[position].Add((col + i, row));
                    i++;
                }
                row++;
                position++;
            }
            tempCoord = tempCoord.Distinct().ToList();
            tempCoord.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            for (int x = 0; x < WordsCoordinates.Count(); x++)
            {
                if (WordsCoordinates[x].Count() <= 1)
                {
                    WordsCoordinates.RemoveAt(x);
                    x--;
                    continue;
                }
                WordsCoordinates[x] = WordsCoordinates[x].Distinct().ToList();
            }

            if (!WordsFinder.CheckWord(getWord(tempCoord)))
            {
                return false;
            }
            foreach (var list in WordsCoordinates)
            {
                if (!WordsFinder.CheckWord(getWord(list)))
                {
                    return false;
                }
            }
            return true;
        }
        private bool checkCreatedWordsWhenHorizontal(int col, int row) // arguments are first pair in sorted tuple
        {
            int end = col + pairs.Count;
            tempCoord.Clear();
            WordsCoordinates.Clear();
            int i, position = 0;
            while (col < end)
            {
                WordsCoordinates.Add(new List<(int, int)>());
                if (cells[col, row].Letter != "")
                {
                    tempCoord.Add((col, row));
                    WordsCoordinates[position].Add((col, row));
                }
                //Left
                i = 1;
                while (col - i >= 0 && cells[col - i, row].Text != "" && cells[col - i, row].Countable)
                {
                    tempCoord.Insert(0, (col - i, row));
                    i++;
                }
                //Right
                i = 1;
                while (col + i <= 14 && cells[col + i, row].Text != "" && cells[col + i, row].Countable)
                {
                    tempCoord.Add((col + i, row));
                    i++;
                }
                //Up
                i = 1;
                while (row - i >= 0 && cells[col, row - i].Letter != "" && cells[col, row - i].Countable)
                {
                    WordsCoordinates[position].Insert(0, (col, row - i));
                    i++;
                }
                //Down
                i = 1;
                while (row + i <= 14 && cells[col, row + i].Letter != "" && cells[col, row + i].Countable)
                {
                    WordsCoordinates[position].Add((col, row + i));
                    i++;
                }
                col++;
                position++;
            }
            tempCoord = tempCoord.Distinct().ToList();
            tempCoord.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            for (int x = 0; x < WordsCoordinates.Count(); x++)
            {
                if (WordsCoordinates[x].Count() <= 1)
                {
                    WordsCoordinates.RemoveAt(x);
                    x--;
                    continue;
                }
                WordsCoordinates[x] = WordsCoordinates[x].Distinct().ToList();
            }

            if (!WordsFinder.CheckWord(getWord(tempCoord)))
            {
                return false;
            }
            foreach (var list in WordsCoordinates)
            {
                if (!WordsFinder.CheckWord(getWord(list)))
                {
                    return false;
                }
            }
            return true;
        }
        private string getWord(List<(int, int)> coordinates)
        {
            string word = "";
            foreach (var XY in coordinates)
            {
                word += cells[XY.Item1, XY.Item2].Letter;
            }
            return word;
        }
        private void updatePlayerPanel()
        {
            int row = 0;
            for (int col = 0; col < 7; col++)
            {
                string tempLetter = playersLetters[PointsInGame.currentPlayer - 1, col].ToString();
                yourCells[col, row].Letter = tempLetter;
                yourCells[col, row].Text = tempLetter;
            }
        }    
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon!", "...");
        }
        private void Scrabble_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuPlayer1_Click(object sender, EventArgs e)
        {
            PointsInGame.AmountOfPlayers = 1;
            this.lblPlayer1.Visible = true;
            this.lblPlayer1Points.Visible = true;
            this.lblPlayer2.Visible = false;
            this.lblPlayer2Points.Visible = false;
            this.lblPlayer3.Visible = false;
            this.lblPlayer3Points.Visible = false;
            this.lblPlayer4.Visible = false;
            this.lblPlayer4Points.Visible = false;
        }

        private void toolStripMenuPlayer2_Click(object sender, EventArgs e)
        {
            PointsInGame.AmountOfPlayers = 2;
            this.lblPlayer1.Visible = true;
            this.lblPlayer1Points.Visible = true;
            this.lblPlayer2.Visible = true;
            this.lblPlayer2Points.Visible = true;
            this.lblPlayer3.Visible = false;
            this.lblPlayer3Points.Visible = false;
            this.lblPlayer4.Visible = false;
            this.lblPlayer4Points.Visible = false;
        }

        private void toolStripMenuPlayer3_Click(object sender, EventArgs e)
        {
            PointsInGame.AmountOfPlayers = 3;
            this.lblPlayer1.Visible = true;
            this.lblPlayer1Points.Visible = true;
            this.lblPlayer2.Visible = true;
            this.lblPlayer2Points.Visible = true;
            this.lblPlayer3.Visible = true;
            this.lblPlayer3Points.Visible = true;
            this.lblPlayer4.Visible = false;
            this.lblPlayer4Points.Visible = false;
        }

        private void toolStripMenuPlayer4_Click(object sender, EventArgs e)
        {
            PointsInGame.AmountOfPlayers = 4;
            this.lblPlayer1.Visible = true;
            this.lblPlayer1Points.Visible = true;
            this.lblPlayer2.Visible = true;
            this.lblPlayer2Points.Visible = true;
            this.lblPlayer3.Visible = true;
            this.lblPlayer3Points.Visible = true;
            this.lblPlayer4.Visible = true;
            this.lblPlayer4Points.Visible = true;
        }
    }
}
