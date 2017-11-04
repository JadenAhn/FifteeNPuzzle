/* GameBoard.cs
* Assignment 3
* Revision History
*   Jaden Ahn, 2017.10.08: Created
*   Jaden Ahn, 2017.10.15: Improved class structure
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAhnAssignment3
{
    /// <summary>
    /// A class used for 15 Puzzle game
    /// </summary>
    public partial class GameBoard : Form
    {
        int emptyIndex;
        int emptyRow;
        int emptyCol;
        int numberOfRow;
        int numberOfCol;
        int totalClick;
        string[] board;
        const int TILE_WIDTH = 60;
        const int TILE_HEIGHT = 60;
        const int GAP = 6;
        const int BASE_X = 10;
        const int BASE_Y = 10;

        /// <summary>
        /// A constructor to Initialize form components
        /// </summary>
        public GameBoard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A method to Initialize game board
        /// </summary>
        private void Initialize()
        {
            pnlTile.Controls.Clear();
            pnlTile.Hide();
            pnlMenu.Enabled = true;
            pnlMenu.Show();
            menuNewGame.Enabled = false;
            menuSaveFile.Enabled = false;
            this.Size = new Size(400, 400);
            totalClick = 0;
            lblClickNumber.Text = "";
            this.Text = "15 Puzzle";
        }

        /// <summary>
        /// A method to check if a certain Tile is available to move or not
        /// </summary>
        /// <param name="row">Row index of a Tile</param>
        /// <param name="col">Column index of a Tile</param>
        /// <returns>Returns true if the Tile is available to move</returns>
        private bool CheckAvailability(int row, int col)
        {
            if (row + 1 == emptyRow && col == emptyCol ||
                row - 1 == emptyRow && col == emptyCol ||
                row == emptyRow && col + 1 == emptyCol ||
                row == emptyRow && col - 1 == emptyCol
                )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// A method to check available(movable) Tiles in the game board
        /// </summary>
        /// <param name="newNumberOfRow">Number of rows of the game board</param>
        /// <param name="newNumberOfCol">Number of columns of the game board</param>
        /// <returns>Returns array of available Tiles</returns>
        private Tile[] CheckAvailableButton(int newNumberOfRow, int newNumberOfCol)
        {
            List<Tile> availableButtonsList = new List<Tile>();

            for (int i = 0; i < newNumberOfRow; i++)
            {
                for (int j = 0; j < newNumberOfCol; j++)
                {
                    if (i == newNumberOfRow - 1 && j == newNumberOfCol - 1)
                    {
                        continue;
                    }
                    string btnName = "Btn" + ((newNumberOfCol * i) + j).ToString();
                    Tile btn = this.Controls.Find(btnName, true).FirstOrDefault() as Tile;
                    if (CheckAvailability(btn.Row, btn.Col))
                    {
                        availableButtonsList.Add(btn);
                    }
                }
            }
            Tile[] availableButtons = availableButtonsList.ToArray();
            return availableButtons;
        }

        /// <summary>
        /// A method to check if all Tiles are in the right place
        /// </summary>
        /// <returns>Returns true if all Tiles are in place</returns>
        private bool CheckAnswer()
        {
            //check anwer
            if (board[board.Length - 1] != "Empty")
            {
                return false;
            }
            else
            {
                for (int i = 0; i < board.Length - 1; i++)
                {
                    if (board[i] != i.ToString())
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        /// <summary>
        /// A method to Shuffle tiles according to difficulty setting
        /// </summary>
        private void Shuffle()
        {
            //Set the difficulty according to selected index
            //0: Easy = Shuffle 10 times
            //1: Normal = Shuffle 40 times
            //2: Hard = Shuffle 90 times
            //3: HELL = Shuffle 160 times
            int difficulty = (cbDifficulty.SelectedIndex + 1) * (10 * (cbDifficulty.SelectedIndex + 1));
            Random rnd = new Random();
            do
            {
                for (int i = 0; i < difficulty; i++)
                {
                    Tile[] availableButton = CheckAvailableButton(numberOfRow, numberOfCol);
                    //Get a random index from availableButton array
                    int rndButton = rnd.Next(0, availableButton.Length);
                    Tile btn = availableButton[rndButton];
                    SwitchTile(btn);
                }

            } while (CheckAnswer());
        }

        /// <summary>
        /// A method to get the coordinate of a tile in the game board
        /// </summary>
        /// <param name="x">x coordinate of a tile</param>
        /// <param name="y">y coordinate of a tile</param>
        /// <param name="indexNumber">index of the tile to get coordinate</param>
        /// <param name="newNumberOfCol">number of columns of the game board</param>
        private void GetLocation(out int x, out int y, int indexNumber, int newNumberOfCol)
        {
            int rowNum = indexNumber / newNumberOfCol;
            int colNum = indexNumber % newNumberOfCol;

            x = BASE_X + ((TILE_WIDTH + GAP) * colNum);
            y = BASE_Y + ((TILE_HEIGHT + GAP) * rowNum);
        }

        /// <summary>
        /// A method to switch clicked Tile and empty space
        /// </summary>
        /// <param name="btn">Tile object to switch</param>
        private void SwitchTile(Tile btn)
        {
            //Switch value in the board array
            int temp = Array.IndexOf(board, (int.Parse(btn.Text) - 1).ToString());
            int tempRow = btn.Row;
            int tempCol = btn.Col;
            board[emptyIndex] = (int.Parse(btn.Text) - 1).ToString();
            board[temp] = "Empty";

            //Get the location of emptyIndex
            GetLocation(out int x, out int y, emptyIndex, numberOfCol);
            //Change the location of button
            btn.Location = new Point(x, y);
            btn.Row = emptyRow;
            btn.Col = emptyCol;
            emptyIndex = temp;
            emptyRow = tempRow;
            emptyCol = tempCol;
        }
        /// <summary>
        /// A method to generate a game board with tiles.
        /// </summary>
        /// <param name="newNumberOfRow">number of rows of the game board</param>
        /// <param name="newNumberOfCol">number of columns of the game board</param>
        private void GenerateBoard(int newNumberOfRow, int newNumberOfCol)
        {
            menuNewGame.Enabled = true;
            menuSaveFile.Enabled = true;
            int startX = BASE_X;
            int startY = BASE_Y;
            Size size = new Size((newNumberOfCol * (TILE_WIDTH + GAP)) + 30, (newNumberOfRow * (TILE_HEIGHT + GAP)) + 84);
            pnlMenu.Enabled = false;
            pnlMenu.Hide();

            //Generate buttons
            for (int i = 0; i < newNumberOfRow; i++)
            {
                for (int j = 0; j < newNumberOfCol; j++)
                {
                    //Remove the last tile
                    if (i == newNumberOfRow - 1 && j == newNumberOfCol - 1)
                    {
                        emptyRow = i;
                        emptyCol = j;
                        continue;
                    }
                    Tile t = new Tile(i, j);
                    t.Left = startX;
                    t.Top = startY;
                    t.Width = TILE_WIDTH;
                    t.Height = TILE_HEIGHT;
                    t.Text = ((newNumberOfCol * i) + j + 1).ToString();
                    t.Name = "Btn" + ((newNumberOfCol * i) + j).ToString();
                    pnlTile.Controls.Add(t);
                    startX += TILE_WIDTH + GAP;
                    t.Click += T_Click;
                }
                startX = 10;
                startY += TILE_HEIGHT + GAP;
            }
            pnlTile.Size = size;
            this.Size = size;

            //Generate answer board
            board = new string[newNumberOfRow * newNumberOfCol];
            for (int i = 0; i < newNumberOfRow * newNumberOfCol; i++)
            {
                board[i] = i.ToString();
            }
            emptyIndex = (newNumberOfRow * newNumberOfCol) - 1;
            //Assign a default empty value for the last cell
            board[emptyIndex] = "Empty";
            this.Text = $"{newNumberOfRow * newNumberOfCol - 1} Puzzle";
        }

        /// <summary>
        /// A method called when the form loads. Call Initialize method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameBoard_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// A method called when clicked Generate button. Call GenerateBoard method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                numberOfRow = int.Parse(txtRow.Text);
                numberOfCol = int.Parse(txtCol.Text);
                if (numberOfRow < 2 || numberOfCol < 2 || numberOfRow > 10 || numberOfCol > 10)
                {
                    //For performance issue, limit the max to 10
                    MessageBox.Show("Please enter numbers between 2 and 10");
                }
                else
                {
                    pnlTile.Show();
                    GenerateBoard(numberOfRow, numberOfCol);
                    Shuffle();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter numbers only");
            }

        }

        /// <summary>
        /// A method called when a Tile is clicked. Move clicked tile to the empty space if available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Click(object sender, EventArgs e)
        {
            Tile btn = (Tile)sender;
            //Get the index number of the clicked button
            //int buttonNumber = Array.IndexOf(board, btn.Text);
            if (CheckAvailability(btn.Row, btn.Col))
            {
                //Change location
                SwitchTile(btn);
                totalClick++;
                string plural = totalClick == 1 ? "" : "s";
                lblClickNumber.Text = $"[{totalClick} click{plural}]";
            }

            if (CheckAnswer())
            {
                DialogResult dialogResult = MessageBox.Show($" PUZZLE SOLVED!\n (TOTAL NUMBER OF CLICKS: {totalClick})\n TRY AGAIN?", "GAME OVER", MessageBoxButtons.YesNo);

                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        Initialize();
                        break;
                    case DialogResult.No:
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// A method called when clicked New Game menu. Call Initialize method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuNewGame_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// A method to save current board array into a text file
        /// </summary>
        /// <param name="filename">file name of a text file to save</param>
        private void DoSave(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(numberOfRow);
            writer.WriteLine(numberOfCol);
            writer.WriteLine(emptyIndex);
            writer.WriteLine(emptyRow);
            writer.WriteLine(emptyCol);
            writer.WriteLine(totalClick);
            for (int i = 0; i < board.Length; i++)
            {
                writer.WriteLine(board[i]);
            }
            writer.Close();
        }

        /// <summary>
        /// A method to load relevant information from text file to generate and relocate Tiles
        /// </summary>
        /// <param name="filename">file name of a text file to save</param>
        private void DoLoad(string filename)
        {
            Initialize();
            StreamReader reader = new StreamReader(filename);
            int newNumberOfRow = int.Parse(reader.ReadLine());
            int newNumberOfCol = int.Parse(reader.ReadLine());
            int newEmptyIndex = int.Parse(reader.ReadLine());
            int newEmptyRow = int.Parse(reader.ReadLine());
            int newEmptyCol = int.Parse(reader.ReadLine());
            int newTotalClick = int.Parse(reader.ReadLine());
            pnlTile.Show();
            GenerateBoard(newNumberOfRow, newNumberOfCol);
            for (int i = 0; i < newNumberOfRow * newNumberOfCol; i++)
            {
                string boardValue = reader.ReadLine();
                board[i] = boardValue;
                if (boardValue != "Empty")
                {
                    //Get the location of current index
                    GetLocation(out int x, out int y, i, newNumberOfCol);
                    string btnName = "Btn" + boardValue;
                    Tile btn = this.Controls.Find(btnName, true).FirstOrDefault() as Tile;
                    //Change the location of button
                    btn.Location = new Point(x, y);
                    btn.Row = i / newNumberOfCol;
                    btn.Col = i % newNumberOfCol;
                }
            }
            reader.Close();

            //Change the numberOfRow and numberOfCol to the value in the loaded file
            numberOfRow = newNumberOfRow;
            numberOfCol = newNumberOfCol;
            emptyIndex = newEmptyIndex;
            emptyRow = newEmptyRow;
            emptyCol = newEmptyCol;
            totalClick = newTotalClick;
            string plural = totalClick == 1 ? "" : "s";
            lblClickNumber.Text = $"[{totalClick} click{plural}]";
        }

        /// <summary>
        /// A method called when clicked Save Game menu. Set time stamp as a file name and call DoSave method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSaveFile_Click(object sender, EventArgs e)
        {
            //Create a timeStamp and serve it as a default file name
            String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            dlgSave.FileName = timeStamp + ".txt";
            dlgSave.Filter = "Text File | *.txt";

            DialogResult result = dlgSave.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    try
                    {
                        string filename = dlgSave.FileName;
                        DoSave(filename);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error in file save");
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// A method called when clicked Load Game menu. Choose a text file and call DoLoad method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuLoadFile_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgOpen.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    try
                    {
                        string filename = dlgOpen.FileName;
                        DoLoad(filename);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error in file load");
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// A method to assign shortcut key
        /// New Game(Ctrl+N), Load Game(Ctrl+O), Save Game(Ctrl+S)
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                Initialize();
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                menuLoadFile.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                menuSaveFile.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
