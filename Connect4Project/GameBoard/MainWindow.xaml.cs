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
    /// 
    /// </summary>


    public partial class MainWindow : Window
    {
        //create the boolean turn. When false its player1/when true its player2 so don't need a loop for turns
        //created two string images for the turns. 
        private bool turn = false;
        //counters that will track where the picture will go (row location)
        private int click1count = 5;
        private int click2count = 5;
        private int click3count = 5;
        private int click4count = 5;
        private int click5count = 5;
        private int click6count = 5;
        private int click7count = 5;
        //set value to use for finding a winner
        private enum value
        {
            Empty,
            P1,
            P2
        }

        private value[,] cells = new value[7, 6];
  
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
        //once an image is placed the next will stack on top
        //if the stack is full it will give a message saying so
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
                                   
            if (begin == true)
            {
                if (click1count >= 0)
                {
                    placePiece(1, click1count);

                }
                else
                {
                    MessageBox.Show("Colum is full, you will not be able to place additional pieces here");
                }
                click1count--;
            }
                        

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                if (click2count >= 0)
                {
                    placePiece(2, click2count);

                }
                else
                {
                    MessageBox.Show("Colum is full, you will not be able to place additional pieces here");
                }
                click2count--;
            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                if (click3count >= 0)
                {
                    placePiece(3, click3count);

                }
                else
                {
                    MessageBox.Show("Colum is full, you will not be able to place additional pieces here");
                }
                click3count--;
            }
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                if (click4count >= 0)
                {
                    placePiece(4, click4count);

                }
                else
                {
                    MessageBox.Show("Colum is full, you will not be able to place additional pieces here");
                }
                click4count--;
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                if (click5count >= 0)
                {
                    placePiece(5, click5count);

                }
                else
                {
                    MessageBox.Show("Colum is full, you will not be able to place additional pieces here");
                }
                click5count--;
            }
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
               
                
                if (click6count >= 0)
                {
                    placePiece(6, click6count);

                }
                else
                {
                    MessageBox.Show("Colum is full, you will not be able to place additional pieces here");
                }
                click6count--;
            }
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            if (begin == true)
            {
                if (click7count >= 0)
                {
                    placePiece(7, click7count);

                }
                else
                {
                    MessageBox.Show("Colum is full, you will not be able to place additional pieces here");
                }
                click7count--;

            }
        }


        public void placePiece(int col,int row)
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

            
            setGridCell(createImage(url, 60, 60), row, col - 1);

            updateMatrix(row, col -1, turn);

            CheckHorizontal(row, col -1);

            turn = !turn;
        }

        private void CheckHorizontal(int row, int col)
        {
            int search = (int)cells[col, row];
            // declares a winner and prevents additional piece placement
            //Horizontal Right
            if(col <= 3 && search == (int)cells[col + 1, row] && search == (int)cells[col+ 2, row] && search == (int)cells [col +3, row])
            {
                begin = false;
                MessageBox.Show("Winner!");

            }
            //Horizontal Left
            if (col >= 3 && search == (int)cells[col - 1, row] && search == (int)cells[col - 2, row] && search == (int)cells[col - 3, row])
            {
                begin = false;
                MessageBox.Show("Winner!");
            }
            //Vertical up
            if (row >= 3 && search == (int)cells[col, row -1] && search == (int)cells[col, row -2] && search == (int)cells[col , row -3])
            {
                begin = false;
                MessageBox.Show("Winner!");
            }
            //Vertical Down
            if (row <= 2 && search == (int)cells[col, row + 1] && search == (int)cells[col, row +2] && search == (int)cells[col , row +3])
            {
                begin = false;
                MessageBox.Show("Winner!");
            }
            // cgane starting calue and how many addition coll/row needed
            //Diagonal Bottom Right

            if (col <= 3 && row <= 3 && search == (int)cells[col + 1, row + 1] && search == (int)cells[col + 2, row + 2] && search == (int)cells[col + 3, row + 3])
            {
                begin = false;
                MessageBox.Show("Winner!");
            }
            //Diagonal Bottom Left
            if (col >= 3 && row >= 3 && search == (int)cells[col - 1, row - 1] && search == (int)cells[col - 2, row - 2] && search == (int)cells[col - 3, row - 3])
            {
                begin = false;
                MessageBox.Show("Winner!");
            }


        }

        private void updateMatrix(int row, int col, bool turn)
        {
            
            if (turn == false)
            {
                cells[col, row] = value.P1;
            }
            else
            {
                cells[col, row] = value.P2;
            }

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

        //reset board and ready to play
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            
            
            BoardPieces[] play1 = new BoardPieces[42];

             click1count = 5;
             click2count = 5;
             click3count = 5;
             click4count = 5;
             click5count = 5;
             click6count = 5;
             click7count = 5;

            
            begin = true;


        }
        //private void PickAWinner(int a, int b, int c, int d)
        //{
        //    if (play1[a] == play1[b] && play1[a] == play1[c] && play1[a] == play1[d])
        //    {
        //        if (play1[a] == player1URL)
        //        {
        //            messagebox.text("Player 1 is the winner!)
        //        }
        //        else
        //        {
        //            messagebox.text("player 2 is the winner!)

        //        }
        //    }








        //}
    }
}
