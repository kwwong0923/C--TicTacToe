using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe.Models
{
    public class Game
    {
        public char[,] PlayField { get; set; }
        public int Steps { get; set; }
        readonly MainWindow _mainWindow;

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
