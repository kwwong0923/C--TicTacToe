using System.Windows;

namespace TicTacToe.Dialogs
{
    /// <summary>
    /// Interaction logic for DeterminePlayerFirstWindow.xaml
    /// </summary>
    public partial class DeterminePlayerFirstWindow : Window
    {
        public bool Player1Round { get; set; }
        public DeterminePlayerFirstWindow(MainWindow parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
        }

        private void Player1Btn_Click(object sender, RoutedEventArgs e)
        {
            Player1Round = true;
            Close();
        }

        private void Player2Btn_Click(object sender, RoutedEventArgs e)
        {
            Player1Round = false;
            Close();
        }
    }
}
