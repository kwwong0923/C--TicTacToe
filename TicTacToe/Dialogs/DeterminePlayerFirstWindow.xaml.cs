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
