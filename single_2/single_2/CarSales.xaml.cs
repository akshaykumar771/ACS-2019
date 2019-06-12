using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class CarSales : Window, INotifyPropertyChanged
    {

       public static ObservableCollection<CarSale> SalesInfo;
        bool carYearSet = false;
        String selectedYear = "";
        public static ObservableCollection<CarSale> carSales = new ObservableCollection<CarSale>();
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public SeriesCollection _SeriesCollection;
        public SeriesCollection SeriesCollection
        {
            get { return _SeriesCollection; }
            set
            {
                _SeriesCollection = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SeriesCollection"));
            }
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public CarSales()
        {
            InitializeComponent();
            carSales = Storage.ReadXml<ObservableCollection<CarSale>>("salesInfo.xml");
        }

        //Plotting of Graph
        private void plotGraph(float audi, float benz, float bmw, float vw, float kia, float lr, float smart, float mazda, string year)
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "AUDI",
                    Values = new ChartValues<double> { audi}
                }
            };
            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Benz",
                Values = new ChartValues<double> { benz }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "BMW",
                Values = new ChartValues<double> { bmw }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Volkswagen",
                Values = new ChartValues<double> { vw }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "KIA",
                Values = new ChartValues<double> { kia }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "LandRover",
                Values = new ChartValues<double> { lr }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Smart",
                Values = new ChartValues<double> { smart }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Mazda",
                Values = new ChartValues<double> { mazda }
            });

            Labels = new[] { year };
            Formatter = value => value.ToString("N");
            DataContext = this;
        }

        //Manufactured Year Filter
        private void Cbx_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.carYearSet = true;
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
            }
            if (this.carYearSet == true)
            {
                ArrayList a1 = new ArrayList();
                var res = carSales.Where(car => car.year == selectedYear);
                Grd_carSaleInfo.ItemsSource = res;
               
                    var resGraph = from car in carSales where car.year.Equals(selectedYear) select car.sold;
                    foreach (var cnt in resGraph)
                    {
                        a1.Add(cnt);
                    }

                    plotGraph((float)a1[0], (float)a1[1], (float)a1[2], (float)a1[3], (float)a1[4], (float)a1[5], (float)a1[6], (float)a1[7], selectedYear);
            }
        }

        //Navigate to Car Details Screen
        private void Button_CarDetails_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw; 
            Owner.Show();
            Visibility = Visibility.Hidden;
        }
    }
}
