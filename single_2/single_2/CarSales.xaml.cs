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
       public static ObservableCollection<CarSale> SalesInfo;
        bool carYearSet = false;
        String selectedYear = "";
        public static ObservableCollection<CarSale> carSales = new ObservableCollection<CarSale>();

        public CarSales()
        {
            InitializeComponent();
            // removeMethod();
            carSales = Storage.ReadXml<ObservableCollection<CarSale>>("salesInfo.xml");
            Grd_carSaleInfo.ItemsSource = carSales;
            
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "AUDI",
                    Values = new ChartValues<double> { 10, 50 }
                }
            };
             //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Benz",
                Values = new ChartValues<double> { 11 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "BMW",
                Values = new ChartValues<double> { 11 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Volkswagen",
                Values = new ChartValues<double> { 11 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "KIA",
                Values = new ChartValues<double> { 56 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "LandRover",
                Values = new ChartValues<double> { 42 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Smart",
                Values = new ChartValues<double> {  42 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Mazda",
                Values = new ChartValues<double> { 12 }
            });

            //also adding values updates and animates the chart automatically
            SeriesCollection[1].Values.Add(2d);

            Labels = new[] { "2017", "2018" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        //private void removeMethod()
        //{

        //    var salesInfo = new ObservableCollection<CarSale>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        salesInfo.Add(new CarSale { manufacturer = "BMW", year = (2014 + i).ToString(), sold= i*100+i});
        //    }
        //    for (int i = 0; i < 5; i++)
        //    {
        //        salesInfo.Add(new CarSale { manufacturer = "Audi", year = (2014 + i).ToString(), sold = i * 200 + i });
        //    }
        //    for (int i = 0; i < 5; i++)
        //    {
        //        salesInfo.Add(new CarSale { manufacturer = "Benz", year = (2014 + i).ToString(), sold = i * 300 + i });
        //    }

        //    Storage.WriteXml<ObservableCollection<CarSale>>(salesInfo,"salesInfo.xml");

        //    Info = salesInfo;
        //}

        private void Cbx_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.carYearSet = true;
           // Grd_carSaleInfo.ItemsSource = SalesInfo;
            var cbxYear = Cbx_Year.SelectedValue.ToString();

            switch (cbxYear)
            {
                case "System.Windows.Controls.ComboBoxItem: 2015":
                    selectedYear = "2015";
                    break;
                case "System.Windows.Controls.ComboBoxItem: 2016":
                    selectedYear = "2016";
                    break;
                case "System.Windows.Controls.ComboBoxItem: 2017":
                    selectedYear = "2017";
                    break;
                case "System.Windows.Controls.ComboBoxItem: 2018":
                    selectedYear = "2018";
                    break;
                case "System.Windows.Controls.ComboBoxItem: 2019":
                    selectedYear = "2019";
                    break;
            }
            Console.WriteLine(selectedYear);
            //if (this.carYearSet == true)
            //{
            //    var res = SalesInfo.Where(car=> car.year == selectedYear);
            //    Grd_carSaleInfo.ItemsSource = res;
            //}
            //else
            //{
            //    MessageBox.Show("abc");
            //}
        }
    }
}
