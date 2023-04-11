using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.Dialogs;
using TicTacToe.Models;

namespace TicTacToe
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Properties with Data Binding
        private int _player1Score;
        public int Player1Score
        {
            get { return _player1Score; }
            set
            {
                _player1Score = value;
                OnPropertyChanged();
            }
        }

        private int _player2Score;
        public int Player2Score
        {
            get { return _player2Score; }
            set
            {
                _player2Score = value;
                OnPropertyChanged();
            }
        }

        private string _topMessage;
        public string TopMessage
        {
            get { return _topMessage; }
            set
            {
                _topMessage = value;
                OnPropertyChanged();
            }
        }

        // Property without Data Binding
        // Player1Round - Setter will triggers the top message
        private bool _player1Round;
        public bool Player1Round
        {
            get { return _player1Round; }
            set
            {
                _player1Round = value;
                DetermineTopMessage();
            }
        }

        // IsGaming - Setter will toggles the gaming button
        private bool _isGaming;
        public bool IsGaming
        {
            get{ return _isGaming;}
            set
            {
                _isGaming = value;
                ToggleGamingButton();
            }
        }

        // List of the play field buttons
        private List<Button> buttons;
        // instance of Game
        private Game _game;      

        public MainWindow()
        {
            DataContext = this;
            Player1Score = 0;
            Player2Score = 0;
            _game = new Game(this);
            InitializeComponent();
            buttons = new List<Button>()
            {
                btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9
            };
        }

        // Data Binding - Event
        public event PropertyChangedEventHandler? PropertyChanged;

        // Data Binding - Method
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // ----------------------------Events of GUI-----------------------------------
        // Nine button's Click Event
        // To interact with User clicking
        private void PlayFieldButton_Click(object sender, RoutedEventArgs e)
        {
            // Check the current round
            char playerSign = ' ';
            if (Player1Round)
                playerSign = 'X';
            else
                playerSign = 'O';

            // Get the button was clicked
            Button button = (Button)sender;
            // Prevent double click
            button.IsEnabled = false;
            // GUI display
            button.Content = playerSign;
            // Back-end process
            _game.EnterXorO(button);

            // check any winner
            bool isWon = _game.Checker();
            if (isWon)
            {
                if (Player1Round)
                {
                    Player1Score++;
                    WinningWindow winningWindow = new WinningWindow(this, Player1Round);
                    Opacity = 0.4;
                    winningWindow.ShowDialog();
                    Opacity = 1;
                }
                else
                {
                    Player2Score++;
                    WinningWindow winningWindow = new WinningWindow(this, Player1Round);
                    Opacity = 0.4;
                    winningWindow.ShowDialog();
                    Opacity = 1;
                }
                // GUI will stays on the last monent
                GetReadyToStartAgain();
                return;
            }

            // Check draw situation
            _game.Steps++;
            if (_game.Steps == 9)
            {
                TopMessage = "DRAW";
                DrawWindow drawWindow = new DrawWindow(this);
                Opacity = 0.4;
                drawWindow.ShowDialog();
                Opacity = 1;
                GetReadyToStartAgain();
                return;
            }

            // switching round
            Player1Round = !Player1Round;
        }

        // Start Button Click Event
        // To Start the game
        private void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            IsGaming = true;
            DetermineWhichPlayerFirst();
            // manually call the top message method for beginning
            DetermineTopMessage();
            // clear up the previous game display
            GetIntoNewRound();
        }

        // Restart Game Button Click Event
        // To Restart whole game, remove the records, game will be started immediately
        private void RestartGamebtn_Click(object sender, RoutedEventArgs e)
        {
            RestartGameWindow restartGameWindow = new RestartGameWindow(this);
            Opacity = 0.4;
            restartGameWindow.ShowDialog();
            Opacity = 1;
            if (restartGameWindow.Success)
            {
                Player1Score = 0;
                Player2Score = 0;
                RestartTheGame();
                //GetIntoNewRound();                
                //DetermineWhichPlayerFirst();
            }
        }

        // Restart Round Button Click Event
        // To Restart the current round, new round will be started imediately
        private void RestartRoundbtn_Click(object sender, RoutedEventArgs e)
        {
            RestartRoundWindow restartRoundWindow= new RestartRoundWindow(this);
            Opacity = 0.4;
            restartRoundWindow.ShowDialog();
            Opacity = 1;
            if (restartRoundWindow.Success)
            {
                GetIntoNewRound();
                DetermineWhichPlayerFirst();
            }
        }
        
        // Give Up Button Click Event
        // To give up the round, and the game won't be started until user press start button
        private void GiveUpbtn_Click(object sender, RoutedEventArgs e)
        {
            GiveUpWindow giveUpWindow = new GiveUpWindow(this);
            Opacity = 0.4;
            giveUpWindow.ShowDialog();

            if (giveUpWindow.Success)
            {
                GiveUpConfirmedWindow giveUpConfirmedWindow = new GiveUpConfirmedWindow(this, Player1Round);
                giveUpConfirmedWindow.ShowDialog();
                Opacity = 1;
                if (Player1Round)
                {
                    Player2Score++;
                }
                else
                {
                    Player1Score++;
                }
                GetReadyToStartAgain();
            }
            Opacity = 1;
        }

        // ----------------------------Methods related to GUI-----------------------------------

        /// <summary>
        /// To Restart the game just like first time opening of application
        /// </summary>
        private void RestartTheGame()
        {
            IsGaming = false;
            _game.Steps = 0;
            _game.InitializePlayField();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Content = null;
                buttons[i].IsEnabled = false;
            }
        }

        /// <summary>
        /// Get into the new round
        /// All the play field button will be available
        /// </summary>
        private void GetIntoNewRound()
        {
            _game.Steps = 0;
            _game.InitializePlayField();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Content = null;
                buttons[i].IsEnabled = true;
            }
        }

        /// <summary>
        /// To display a dialog Determining which player will goes first
        /// </summary>
        private void DetermineWhichPlayerFirst()
        {
            DeterminePlayerFirstWindow determinePlayerFirstWindow = new DeterminePlayerFirstWindow(this);
            Opacity = 0.4;
            determinePlayerFirstWindow.ShowDialog();
            Opacity = 1;
            Player1Round = determinePlayerFirstWindow.Player1Round;
        }

        /// <summary>
        /// To Determine top message by current round of whom
        /// </summary>
        private void DetermineTopMessage()
        {
            if (Player1Round)
                TopMessage = "Now is Player 1(X) turn";
            else
                TopMessage = "Now is Player 2(O) turn";
        }

        /// <summary>
        /// Get the play field ready for clicking start button
        /// The play field will be displaying the last game, all the play field button will be freezed
        /// The start button will be available
        /// </summary>
        private void GetReadyToStartAgain()
        {
            IsGaming = false;
            _game.Steps = 0;
            _game.InitializePlayField();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].IsEnabled = false;
            }
        }

        /// <summary>
        /// To toggle the gaming button (Restart Round Button, Give Up Button)
        /// These buttons only work during the game is starting.
        /// </summary>
        private void ToggleGamingButton()
        {
            if (IsGaming)
            {
                RestartRoundbtn.IsEnabled = true;
                GiveUpbtn.IsEnabled = true;
                Startbtn.IsEnabled = false;
                Startbtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                RestartRoundbtn.IsEnabled = false;
                GiveUpbtn.IsEnabled = false;
                Startbtn.IsEnabled = true;
                Startbtn.Visibility = Visibility.Visible;
            }
        }

    }
}
