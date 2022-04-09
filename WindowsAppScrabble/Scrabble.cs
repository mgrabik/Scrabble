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
        List<string> stackedWords = new List<string>();

        private int letterChosenCounter = 0;
        public static bool cheatIsOpen = false;
        private bool firstMove = true;

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
                if (!cell.IsClicked && chosenLetters.Count != 0 && chosenLetters[ids[0] - 1] != null)
                {
                    chosenLetters[ids[0]-1].BackColor = RedColor;
                    cell.BackColor = OrangeColor;
                    cell.Text = chosenLetters[ids[0]-1].Text;
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
                chars[i] = Convert.ToChar(yourCells[i, 0].Text);
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
                yourCells[i, 0].ID = Guid.NewGuid().ToString("N");
            }
        }
        private void confirmEvent(object sender, EventArgs e)
        {
            int wordBonus = 1;
            int letterBonus;
            int pointsPerRound = 0;
            bool isVertical = false;
            string wordToCheck = "";

            if (firstMove && !cells[7, 7].IsClicked)
            {
                MessageBox.Show("The first word has to be placed in the center!", "Warning!");
                return;
            }
            try
            {
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
                if(!firstMove) checkCorrectness(pairs[0].Item1, pairs[0].Item2);


                if (isVertical)
                {
                    int col = pairs[0].Item1;
                    for (int i = pairs[0].Item2; i <= pairs[pairs.Count() - 1].Item2; i++)
                    {
                        wordToCheck += cells[col, i].Text.ToCharArray()[0];
                    }
                }
                else
                {
                    int row = pairs[0].Item2;
                    for (int i = pairs[0].Item1; i <= pairs[pairs.Count() - 1].Item1; i++)
                    {
                        wordToCheck += cells[i, row].Text.ToCharArray()[0];
                    }
                }
                if (!WordsFinder.CheckWord(new string(wordToCheck)))
                {
                    MessageBox.Show("Your word does not exist!\nCorret it!", "Warning!");
                    return;
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Exception handled", "Warning!");
                return;
            }

            

            //Score points
            for (int col = 0; col < 15; col++)
            {
                for (int row = 0; row < 15; row++)
                {
                    if (cells[col, row].IsClicked)
                    {
                        letterBonus = 1;
                        //Searching for Letter Bonus
                        if (cells[col, row].Bonus == Bonus.DoubleLetter)
                        {
                            letterBonus = 2;
                        }
                        if (cells[col, row].Bonus == Bonus.TripleLetter)
                        {
                            letterBonus = 3;
                        }

                        //Searching for Word Bonus
                        if (cells[col, row].Bonus == Bonus.DoubleWord)
                        {
                            wordBonus *= 2;
                        }
                        if (cells[col, row].Bonus == Bonus.TripleWord)
                        {
                            wordBonus *= 3;
                        }

                        pointsPerRound += countPoints(col, row, letterBonus);
                        cells[col, row].IsClicked = false;
                    }
                }
            }
            pointsPerRound *= wordBonus;

            //Main Board
            foreach (var pair in pairs)
            {
                cells[pair.Item1, pair.Item2].Unknown = false;
                cells[pair.Item1, pair.Item2].Countable = true;
                cells[pair.Item1, pair.Item2].ForeColor = Color.Black;
                cells[pair.Item1, pair.Item2].BackColor = Color.FromArgb(255, 219, 77);
            }

            //Player's panel
            for (int col = 0; col < 7; col++)
            {
                int row = 0;

                //Genering new letters
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

            //Save data about points
            PointsInGame.PlayerPoints[PointsInGame.currentPlayer - 1] += pointsPerRound;

            // Update points labels
            this.lblPlayer1Points.Text = PointsInGame.PlayerPoints[0].ToString();
            this.lblPlayer2Points.Text = PointsInGame.PlayerPoints[1].ToString();
            this.lblPlayer3Points.Text = PointsInGame.PlayerPoints[2].ToString();
            this.lblPlayer4Points.Text = PointsInGame.PlayerPoints[3].ToString();

            // Update player's panel
            PointsInGame.NextPlayer();
            updatePlayerPanel();


            //Return to default value
            chosenLetters.Clear();
            letterChosenCounter = 0;
            pairs.Clear();
            ids.Clear();

            MessageBox.Show("It is Player "+ PointsInGame.currentPlayer.ToString()+"'s turn", "Next Round!");
            firstMove = false;
        }
        private void checkCorrectness(int col, int row)
        {
            List<string> word = new List<string>();
            int i = 1;
            word.Add(cells[col, row].Text);
            //Left
            while (col - i >= 0 && cells[col - i, row].Text != "" && cells[col - i, row].Countable)
            {
                word.Insert(0, cells[col - i, row].Text);
                i++;
            }
            i = 1;
            while (cells[col + i, row].Text != "" && cells[col + i, row].Countable)
            {
                word.Add(cells[col + i, row].Text);
                i++;
            }
            if(word.Count != 1)
            {
                stackedWords.Add(merge(word));
            }
            //Up
            i = 1;
            while (row - i >= 0 && cells[col, row - i].Text != "" && cells[col, row - i].Countable)
            {
                word.Insert(0, cells[col, row - i].Text);
                i++;
            }
            i = 1;
            while (cells[col, row + i].Text != "" && cells[col, row + i].Countable)
            {
                word.Add(cells[col, row + i].Text);
                i++;
            }


        }
        private int countPoints(int col, int row, int letterBonus)
        {
            List<string> word = new List<string>();
            int points = 0;
            //Score points for single letter
            points += ListofPoints.LetterPoints[cells[col, row].Text] * letterBonus;

            //Searching for neabry words
            //left
            if (col - 1 >= 0 && cells[col - 1, row].Text != "" && cells[col - 1, row].Countable)
            {
                points += ListofPoints.LetterPoints[cells[col - 1, row].Text];
                cells[col - 1, row].Countable = false;
                pairs.Add(new Tuple<int, int>(col - 1, row));
                for (int i = 2; col - i >= 0; i++)
                {
                    if (cells[col - i, row].Text != "" && cells[col - i, row].Countable)
                    {
                        points += ListofPoints.LetterPoints[cells[col - i, row].Text];
                    }
                    else break;
                }
            }
            //right
            if (col + 1 < 15 && cells[col + 1, row].Text != "" && cells[col + 1, row].Countable)
            {
                points += ListofPoints.LetterPoints[cells[col + 1, row].Text];
                cells[col + 1, row].Countable = false;
                pairs.Add(new Tuple<int, int>(col + 1, row));
                for (int i = 2; col + i < 15; i++)
                {
                    if (cells[col + i, row].Text != "" && cells[col + i, row].Countable)
                    {
                        points += ListofPoints.LetterPoints[cells[col + i, row].Text];
                    }
                    else break;
                }
            }
            //bottom
            if (row + 1 < 15 && cells[col, row + 1].Text != "" && cells[col, row + 1].Countable)
            {
                points += ListofPoints.LetterPoints[cells[col, row + 1].Text];
                cells[col, row + 1].Countable = false;
                pairs.Add(new Tuple<int, int>(col, row + 1));
                for (int i = 2; i + row < 15; i++)
                {
                    if (cells[col, row + i].Text != "" && cells[col, row + i].Countable)
                    {
                        points += ListofPoints.LetterPoints[cells[col, row + i].Text];
                    }
                    else break;
                }
            }
            //top
            if (row - 1 >= 0 && cells[col, row - 1].Text != "" && cells[col, row - 1].Countable)
            {
                points += ListofPoints.LetterPoints[cells[col, row - 1].Text];
                cells[col, row - 1].Countable = false;
                pairs.Add(new Tuple<int, int>(col, row - 1));
                for (int i = 2; row - i >= 0; i++)
                {
                    if (cells[col, row - i].Text != "" && cells[col, row + i].Countable)
                    {
                        points += ListofPoints.LetterPoints[cells[col, row - i].Text];
                    }
                    else break;
                }
            }
            return points;
        }

        private void updatePlayerPanel()
        {
            int row = 0;
            for (int col = 0; col < 7; col++)
            {
                yourCells[col, row].Text = playersLetters[PointsInGame.currentPlayer - 1, col].ToString();
            }
        }
        private string merge(List<string> letters)
        {
            string result = "";
            for (int i = 0; i < letters.Count(); i++)
            {
                result += letters[i];
            }
            return result;
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
