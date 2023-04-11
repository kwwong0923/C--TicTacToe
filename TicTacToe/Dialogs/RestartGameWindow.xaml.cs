using System.Windows;

namespace TicTacToe.Dialogs
{
    /// <summary>
    /// Interaction logic for RestartGameWindow.xaml
    /// </summary>
    public partial class RestartGameWindow : Window
    {
        public bool Success { get; set; } = false;
        public RestartGameWindow(MainWindow parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Success = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Success = false;
            Close();
        }
    }
}
