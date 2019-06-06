using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CarSales.xaml
    /// </summary>
    public partial class CarSales : Window
    {
        ObservableCollection<CarSale> Info;
        bool carNameSet = false;
        bool carYearSet = false;
        String selectedBrand = "";
        String selectedYear = "";
        public static ObservableCollection<CarSale> carSales = new ObservableCollection<CarSale>();

        public CarSales()
        {
            InitializeComponent();
            removeMethod();
            Grd_carSaleInfo.ItemsSource = Info;
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };
             //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        private void removeMethod()
        {
            var salesInfo = new ObservableCollection<CarSale>();
            for (int i = 0; i < 5; i++)
            {
                salesInfo.Add(new CarSale { manufacturer = "BMW", year = (2014 + i).ToString() });
            }
            for (int i = 0; i < 5; i++)
            {
                salesInfo.Add(new CarSale { manufacturer = "Audi", year = (2017 + i).ToString() });
            }
            for (int i = 0; i < 5; i++)
            {
                salesInfo.Add(new CarSale { manufacturer = "Benz", year = (2018 + i).ToString() });
            }


            Info = salesInfo;
        }

        private void Cbx_Manf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.carNameSet = true;
            //Grd_carInfo.ItemsSource = InfoToDisplay;
            var cbxManf = Cbx_Manf.SelectedValue.ToString();

            switch (cbxManf)
            {
                case "System.Windows.Controls.ComboBoxItem: BMW":
                    selectedBrand = "BMW";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Audi":
                    selectedBrand = "Audi";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Benz":
                    selectedBrand = "Benz";
                    break;
            }
            Console.WriteLine(selectedBrand);
            if (this.carYearSet)
            {
                var res = Info.Where(car => car.manufacturer == selectedBrand && car.year == selectedYear);
                Grd_carSaleInfo.ItemsSource = res;
            }
            else
            {
                var res = Info.Where(car => car.manufacturer == selectedBrand);
                Grd_carSaleInfo.ItemsSource = res;
            }
        }
    }
}
