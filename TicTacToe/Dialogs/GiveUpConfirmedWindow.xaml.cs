using System.Windows;

namespace TicTacToe.Dialogs
{
    /// <summary>
    /// Interaction logic for GiveUpConfirmedWindow.xaml
    /// </summary>
    public partial class GiveUpConfirmedWindow : Window
    {
        public string GiveUpMessage { get; set; }
        public GiveUpConfirmedWindow(MainWindow parentWindow, bool player1Round)
        {
            Owner = parentWindow;
            if (player1Round)
                GiveUpMessage = "Player1(X) gives up this round";
            else
                GiveUpMessage = "Player2(O) gives up this round";
            DataContext = this;
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
