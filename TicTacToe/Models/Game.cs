using System.Windows.Controls;

namespace TicTacToe.Models
{
    public class Game
    {
        public char[,] PlayField { get; set; }
        public int Steps { get; set; }

        readonly MainWindow _mainWindow;

        /// <summary>
        /// Constructor of Game class, it gets the MainWindow, initializes the Steps and PlayField Array
        /// </summary>
        /// <param name="mainWindow"> From the Main Window, Game can accesses the data from MainWondow Object</param>
        public Game(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
            Steps = 0;
            InitializePlayField();
        }
        public void InitializePlayField()
        {
            this.PlayField = new char[,]
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };
        }

        /// <summary>
        /// To Check if winner appears
        /// </summary>
        /// <returns>Winner appears = true</returns>
        public bool Checker()
        {
            for (int i = 0; i < 3; i++)
            {
                // Horizontal Checking 
                if (PlayField[i, 0] == PlayField[i, 1] && PlayField[i, 1] == PlayField[i, 2])
                    return true;
                // Vertical Checking
                else if (PlayField[0, i] == PlayField[1, i] && PlayField[1, i] == PlayField[2, i])
                    return true;
                // Cross Checking (Upper Left to Bottom Right)
                else if (PlayField[0, 0] == PlayField[1, 1] && PlayField[1, 1] == PlayField[2, 2])
                    return true;
                // Cross Checking (Upper Right to Bottom Left)
                else if (PlayField[0, 2] == PlayField[1, 1] && PlayField[1, 1] == PlayField[2, 0])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// To record each step in back-end part
        /// </summary>
        /// <param name="input"> the button user clicked</param>
        public void EnterXorO(Button input)
        {
            char playerSign = ' ';
            if (_mainWindow.Player1Round)
                playerSign = 'X';
            else
                playerSign = 'O';

            switch (input.Name)
            {
                case "btn1": PlayField[0, 0] = playerSign; break;
                case "btn2": PlayField[0, 1] = playerSign; break;
                case "btn3": PlayField[0, 2] = playerSign; break;
                case "btn4": PlayField[1, 0] = playerSign; break;
                case "btn5": PlayField[1, 1] = playerSign; break;
                case "btn6": PlayField[1, 2] = playerSign; break;
                case "btn7": PlayField[2, 0] = playerSign; break;
                case "btn8": PlayField[2, 1] = playerSign; break;
                case "btn9": PlayField[2, 2] = playerSign; break;
            }
        }
    }
}
