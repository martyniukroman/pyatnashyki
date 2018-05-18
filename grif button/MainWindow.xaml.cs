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

        public MainWindow() {
            InitializeComponent();
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {

                    if (i == x - 1 && j == y - 1) {
                        break;
                    }

                    Button tmp = new Button();
                    tmp.Content = counter++;
                    GridInner.Children.Add(tmp);
                    Grid.SetRow(tmp, i);
                    Grid.SetColumn(tmp, j);
                }
            }
        }

    }
}
