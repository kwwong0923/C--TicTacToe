using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
