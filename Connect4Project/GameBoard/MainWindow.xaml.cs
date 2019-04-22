//Cheyenne Hale, Aaron Schmidt, Brendan Taylor
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BoardPieces play1 = new BoardPieces();
            play1.Player1Name = txtPlayer1Input.Text;
            play1.Player2Name = txtPlayer2Input.Text;



        }

        private void btnReady_Click(object sender, RoutedEventArgs e)
        {
            string name = txtPlayer1Input.Text;
          
        }
    }
}
