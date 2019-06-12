using System;
using System.IO;
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

namespace single_2
{
    /// <summary>
    /// Interaction logic for W_compareList.xaml
    /// </summary>
    public partial class W_compareList : Window
    {
       public W_compareList()
        {
            InitializeComponent();
            Grd_cmpTable.ItemsSource = MainWindow.compareList;
        }

        //Back Button
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            Owner.Show();
            Visibility = Visibility.Hidden;
        }

        //Remove Button
        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Grd_cmpTable.SelectedItem != null)
            {
                MainWindow.compareList.Remove((CarInfo)Grd_cmpTable.SelectedItem);
                --MainWindow.count;
            }
            else
            {
                MessageBox.Show("Please select a car to remove from the screen","Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
