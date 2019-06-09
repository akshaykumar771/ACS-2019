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
        public string srcUri {
            get { return System.IO.Path.GetFullPath("/A_Class.jpg"); }
                
                }
        public W_compareList()
        {
            InitializeComponent();
            Grd_cmpTable.ItemsSource = MainWindow.compareList;
            //src = new BitmapImage(new Uri("A_Class.jpg", UriKind.Relative));
            
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Owner = this;
            mw.Show();
            Visibility = Visibility.Hidden;
        }
    }
}
