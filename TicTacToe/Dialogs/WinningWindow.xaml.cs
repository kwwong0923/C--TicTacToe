using System.Windows;

namespace TicTacToe.Dialogs
{
    /// <summary>
    /// Interaction logic for WinningWindow.xaml
    /// </summary>
    public partial class WinningWindow : Window
    {
        public string WinningMessage { get; set; }
        public WinningWindow(MainWindow parentWindow, bool player1Round)
        {
            Owner = parentWindow;
            if (player1Round)
                WinningMessage = "Winner: Player1(X)";
            else
                WinningMessage = "Winner: Player2(O)";
            DataContext = this;
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
