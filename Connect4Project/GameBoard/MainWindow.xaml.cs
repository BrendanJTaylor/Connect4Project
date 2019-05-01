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
        //create the boolean turn. When false its player1/when true its player2 so don't need a loop for turns
        //created two string images for the turns. 
        private bool turn = false;
        private string player1URL = "https://cdn.pixabay.com/photo/2018/09/22/03/34/cat-3694498_960_720.jpg";
        private string player2URL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIMuT2ZSGbTNDGdg7juXsLfebQGYfmyXhg1ygFUYq3LrXhexBeJA";

        //created boolean for when true, you can start clicking column buttons
        private bool begin = false;

        BoardPieces[] play1 = new BoardPieces[42];

        public MainWindow()
        {
            InitializeComponent();

            imgDog.Visibility = Visibility.Collapsed;
            imgCat.Visibility = Visibility.Collapsed;
            btnBegin.Visibility = Visibility.Collapsed;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BoardPieces play1 = new BoardPieces();
            play1.Player1Name = txtPlayer1Input.Text;
            play1.Player2Name = txtPlayer2Input.Text;

            //When click "Begin" button, becomes true
            begin = true;

            lblTurn.Content = txtPlayer1Input.Text + "'s Turn";




        }

        private void btnReady_Click(object sender, RoutedEventArgs e)
        {
            //player names become visible when ready button is clicked
            string name = txtPlayer1Input.Text;
            string name2 = txtPlayer2Input.Text;
            lblNameofPlayer1.Content = name + " Coin";
            lblNameofPlayer2.Content = name2 + " Coin";

            //images and names become visible when ready
            imgCat.Visibility = Visibility.Visible;
            imgDog.Visibility = Visibility.Visible;
            lblNameofPlayer1.Visibility = Visibility.Visible;
            lblNameofPlayer2.Visibility = Visibility.Visible;
            btnBegin.Visibility = Visibility.Visible;
        }


        //each column button click creates image action in column
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                placePiece(1);
            }

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                placePiece(2);
            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                placePiece(3);
            }
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                placePiece(4);
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                placePiece(5);
            }
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                placePiece(6);
            }
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                placePiece(7);
            }
        }


        public void placePiece(int col)
        {
            if (turn == true)
            {
                lblTurn.Content = txtPlayer1Input.Text + "'s Turn";
            }
            else
            {
                lblTurn.Content = txtPlayer2Input.Text + "'s Turn";
            }

            string url;

            if (turn == false)
            {
                url = player1URL;
            }
            else
            {
                url = player2URL;
            }

            setGridCell(createImage(url, 60, 60), 0, col - 1);

            

            turn = !turn;
        }

        //Adding an image to the grid
        private Image createImage(string url, int width, int height)
        {
            //Source from: https://stackoverflow.com/questions/350027/setting-wpf-image-source-in-code

            BitmapImage source = new BitmapImage();

            Image image = new Image();
            image.Width = width;
            image.Height = height;


            source.BeginInit();
            source.UriSource = new Uri(url);
            source.EndInit();

            image.Source = source;

            return image;
        }



        private void setGridCell(Image img, int row, int col)
        {
            //Source from: https://stackoverflow.com/questions/16742262/adding-image-to-grid-c-sharp    
            Grid.SetRow(img, row);
            Grid.SetColumn(img, col);
            mainWindow.Children.Add(img);
        }

        //private void PickAWinner(int a, int b, int c, int d)
        //{
        //    if (play1[a] == play1[b] && play1[a] == play1[c] && play1[a] == play1[d])
        //    {
        //        if (play1[a] == player1URL)
        //        {
        //            txtPlayer1Input.Text = "Player1 is the winner";
        //            txtPlayer2Input.Text = "";
        //        }
        //        else
        //        {
        //            txtPlayer1Input.Text = "";
        //            txtPlayer2Input.Text = "Player2 is the winner";

        //        }
        //    }








        //}
    }
}
