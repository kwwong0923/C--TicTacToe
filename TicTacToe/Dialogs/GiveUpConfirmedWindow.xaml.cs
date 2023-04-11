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
