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

namespace grif_button {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public int x = 4, y = 4;
        public int counter = 1;
        int tempEmptyX = 0, tempEmptyY = 0, tempButtonX = 0, tempButtonY = 0;
        List<Button> Buttons = new List<Button>();
        bool initialized = false;
        private void Exit(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void InitializeGrid()
        {
            Buttons.Clear();
            counter=1;
            GridInner.RowDefinitions.Clear();
            GridInner.ColumnDefinitions.Clear();
            for (int i = 0; i < x; i++)
            {
                GridInner.RowDefinitions.Add(new RowDefinition());
                GridInner.ColumnDefinitions.Add(new ColumnDefinition());
                for (int j = 0; j < y; j++)
                {
                    
                    if (i == x - 1 && j == y - 1)
                    {
                        tempEmptyX = i;
                        tempEmptyY = j;
                        break;
                    }
                    
                    Button tmp = new Button();
                    Buttons.Add(tmp);
                    tmp.FontSize = 50;
                    tmp.Click += Tmp_Click;
                    tmp.Content = counter++;
                    tmp.Tag = i + " " + j; // for check
                    GridInner.Children.Add(tmp);
                    Grid.SetRow(tmp, i);
                    Grid.SetColumn(tmp, j);
                }

            }
        }
        private void NightMode(object sender, RoutedEventArgs e) {

            if ((sender as CheckBox).IsChecked == true) {
                foreach (var item in GridInner.Children) 
                    (item as Button).Background = new SolidColorBrush(Colors.DimGray);                         
                GridInner.Background = new SolidColorBrush(Colors.DarkGray);
                MenuUpper.Background = new SolidColorBrush(Colors.DimGray);
            }
            else {
                foreach (var item in GridInner.Children) 
                    (item as Button).Background = new SolidColorBrush(Colors.Azure);
                GridInner.Background = new SolidColorBrush(Colors.Azure);
                MenuUpper.Background = new SolidColorBrush(Colors.Azure);
            }

        }
        Random r = new Random();

        private void NewGame(int dif) {
            // start new game
            // MessageBox.Show("abs");

                InitializeGrid();
          
            
  
            for (int i = 0; i < dif; i++)
            {
                SwapButtons(Buttons[r.Next(0, Buttons.Count)]);
            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            int dif = 0;

            if((sender as MenuItem).Header.ToString() == "Child") {
                dif = 50;
                x = 4;
                y = 4;
            }
            if ((sender as MenuItem).Header.ToString() == "Normal") {
                dif = 250;
                x = 5;
                y = 5;
            }
            if ((sender as MenuItem).Header.ToString() == "Dark Souls") {
                dif = 500;
                x = 6;
                y = 6;
            }
            NewGame(dif);
        }

        public MainWindow() {
            InitializeComponent();
        }

        public void SwapButtons(Button b) {
            tempButtonY = Grid.GetColumn(b);
            tempButtonX = Grid.GetRow(b);
            if (tempButtonY + 1 == tempEmptyY && tempButtonX == tempEmptyX) {
                Grid.SetColumn(b, tempEmptyY);
                tempEmptyY = tempButtonY;
            }
            else if (tempButtonY - 1 == tempEmptyY && tempButtonX == tempEmptyX) {
                Grid.SetColumn(b, tempEmptyY);
                tempEmptyY = tempButtonY;
            }
            else if (tempButtonX + 1 == tempEmptyX && tempEmptyY == tempButtonY) {
                Grid.SetRow(b, tempEmptyX);
                tempEmptyX = tempButtonX;
            }
            else if (tempButtonX - 1 == tempEmptyX && tempEmptyY == tempButtonY) {
                Grid.SetRow(b, tempEmptyX);
                tempEmptyX = tempButtonX;
            }
        }

        private void Tmp_Click(object sender, RoutedEventArgs e)
        {

            // logic swap

           SwapButtons(sender as Button);
            //else if (tempButtonX + 1 == tempEmptyX || tempButtonX - 1 == tempEmptyX )
            //{
            //    Grid.SetRow(sender as Button, tempEmptyX);
            //    tempEmptyX = tempButtonX;
            //}



           // win check 

           bool win = true;

           foreach(Button b in Buttons) {
                int x = Grid.GetColumn(b);
                int y = Grid.GetRow(b);

                if((y + " " + x) != b.Tag.ToString() ) {
                    win = false;
                    break;
                }

            }
           if(win == true) {
                MessageBox.Show("You win");
            }

        }


    }
}
