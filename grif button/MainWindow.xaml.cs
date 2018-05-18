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

        public int x, y;

        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonCreateIvent(object sender, RoutedEventArgs e) {

           
            GridInner.RowDefinitions.Clear();
            GridInner.ColumnDefinitions.Clear();

            if (TextBoxR.Text != null && TextBoxC.Text != null) {
                x = Convert.ToInt32(TextBoxR.Text);
                y = Convert.ToInt32(TextBoxC.Text);

                for (int i = 0; i < x; i++) {
                    GridInner.RowDefinitions.Add(new RowDefinition());
                }

                for (int i = 0; i < y; i++) {
                    GridInner.ColumnDefinitions.Add(new ColumnDefinition());
                }

            }


        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e) {

            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    Button tmp = new Button();
                    GridInner.Children.Add(tmp);
                    Grid.SetRow(tmp, i);
                    Grid.SetColumn(tmp, j);
                }
            }

        }
    }
}
