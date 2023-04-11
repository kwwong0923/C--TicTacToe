using System.Windows;

namespace TicTacToe.Dialogs
{
    /// <summary>
    /// Interaction logic for DrawWindow.xaml
    /// </summary>
    public partial class DrawWindow : Window
    {
        public DrawWindow(MainWindow parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
