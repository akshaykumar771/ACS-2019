using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace single_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public static ObservableCollection<CarInfo> Info;
        bool carNameSet = false;
        bool carYearSet = false;
        bool carPriceSet = false;
        bool carFuelSet = false;
        bool carManualSet = false;
        bool carAutoSet = false;
        String selectedBrand = "";
        String selectedYear = "";
        int selectedPriceFrom;
        int selectedPriceTo;
        String selectedFuel = "";
        public static ObservableCollection<CarInfo> compareList = new ObservableCollection<CarInfo>();
        //string srcVar = "C:/Users/ins_IT/Desktop/delete/ACS-2019/single_2/single_2/Images/1-37-512.png";
        public event PropertyChangedEventHandler PropertyChanged;


        public MainWindow()
        {
            InitializeComponent();
            remoMethod();
            Grd_carInfo.ItemsSource = Info;
        }

        private void remoMethod()
        {
            var manInfo = new ObservableCollection<CarInfo>();
            Info = Storage.ReadXml<ObservableCollection<CarInfo>>("allDataCarInfo.xml");
            Grd_carInfo.ItemsSource = Info;
            var manName = Info.Select(c => c.Manufacturer).Distinct();
            foreach (var item in manName)
            {
                Cbx_Cb.Items.Add(item);
            }
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.carNameSet = true;
            if (Cbx_Cb.SelectedValue != null)
            {
                selectedBrand = Cbx_Cb.SelectedValue.ToString();
                Console.WriteLine(selectedBrand);
            }
         }

        private void Cbx_year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx_Cb_Year.SelectedItem != null)
            {
                this.carYearSet = true;
                String cbxYearValue = Cbx_Cb_Year.SelectedItem.ToString();
                switch (cbxYearValue)
                {
                    case "System.Windows.Controls.ComboBoxItem: 2014":
                        selectedYear = "2014";
                        break;
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
            }
        }
        private void Cbx_Cb_Price_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx_Cb_Price.SelectedValue != null)
            {
                this.carPriceSet = true;
                var cbxPriceValue = Cbx_Cb_Price.SelectedValue.ToString();
                switch (cbxPriceValue)
                {
                    case "System.Windows.Controls.ComboBoxItem: 0 - 20000":
                        selectedPriceTo = 20000;
                        selectedPriceFrom = 0;
                        break;
                    case "System.Windows.Controls.ComboBoxItem: 20000 - 40000":
                        selectedPriceTo = 40000;
                        selectedPriceFrom = 20000;
                        break;
                    case "System.Windows.Controls.ComboBoxItem: 40000 - 60000":
                        selectedPriceTo = 60000;
                        selectedPriceFrom = 40000;
                        break;
                    case "System.Windows.Controls.ComboBoxItem: 60000 - 80000":
                        selectedPriceTo = 80000;
                        selectedPriceFrom = 60000;
                        break;
                    case "System.Windows.Controls.ComboBoxItem: 80000 - 100000":
                        selectedPriceTo = 100000;
                        selectedPriceFrom = 80000;
                        break;
                }
            }
        }
        private void Cbx_Cb_Fuel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx_Cb_Fuel.SelectedValue != null)
            {
                this.carFuelSet = true;
                var cbxFuelValue = Cbx_Cb_Fuel.SelectedValue.ToString();
                switch (cbxFuelValue)
                {
                    case "System.Windows.Controls.ComboBoxItem: Petrol":
                        selectedFuel = "Petrol";
                        break;
                    case "System.Windows.Controls.ComboBoxItem: Diesel":
                        selectedFuel = "Diesel";
                        break;
                    case "System.Windows.Controls.ComboBoxItem: Electric":
                        selectedFuel = "Electric";
                        break;
                    case "System.Windows.Controls.ComboBoxItem: Gas":
                        selectedFuel = "Gas";
                        break;
                }
            }
        }

        private void Btn_addCompare_Click(object sender, RoutedEventArgs e)
        {
            if (Grd_carInfo.SelectedItem == null)
            {
                MessageBox.Show("Please select a car to add to the list!!");
            }
            else
            {
                if (compareList.Count<=2)
                {
                    CarInfo carInfo = (CarInfo)Grd_carInfo.SelectedItem;
                    if (compareList.Contains(carInfo))
                    {
                        MessageBox.Show("Already added to the list!!");
                    }
                    else
                    {
                        compareList.Add(carInfo);
                    }
                }
                else
                {
                    MessageBox.Show("You can only compare 3 items at once.");
                }

            }
        }

        private void Btn_gotoCompare_Click(object sender, RoutedEventArgs e)
        {
            W_compareList cmp = new W_compareList();
            cmp.Owner = this;
            cmp.Show();
            Visibility = Visibility.Hidden;
        }

        private void Button_Sales_Click(object sender, RoutedEventArgs e)
        {
            CarSales cs = new CarSales();
            cs.Owner = this;
            cs.Show();
            Visibility = Visibility.Hidden;
           
        }

        private void Btn_Go_Click(object sender, RoutedEventArgs e)
        {
            bool isdataset = (carNameSet && carYearSet && carPriceSet && carFuelSet );
            if (isdataset)
            {

                bool TypeM = (bool)Chbx_manual.IsChecked;
                bool TypeA = (bool)Chbx_auto.IsChecked;
                string carTypeString = "";
                if(TypeM)
                {
                    carTypeString = "Manual";
                }
                if(TypeA)
                {
                    carTypeString = "Automatic";
                }
                var res = Info;
                if(String.IsNullOrEmpty(carTypeString))
                {
                    res = new ObservableCollection<CarInfo>(Info.Where(car => car.Manufacturer == selectedBrand && car.Year == selectedYear && float.Parse(car.Price) >= selectedPriceFrom && float.Parse(car.Price) <= selectedPriceTo && car.Fuel == selectedFuel)); 
                }
                else
                {
                    res = new ObservableCollection<CarInfo>(Info.Where(car => car.Manufacturer == selectedBrand && car.Year == selectedYear && float.Parse(car.Price) >= selectedPriceFrom && float.Parse(car.Price) <= selectedPriceTo && car.Fuel == selectedFuel && car.Type == carTypeString));
                }
                Grd_carInfo.ItemsSource = res;
                if (res.Count == 0)
                {
                    MessageBox.Show("No match found");
                   
                }
            }
            else
            {
                MessageBox.Show("Please select all the options and then proceed");
            }
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Cbx_Cb.SelectedIndex = -1;
            Cbx_Cb_Fuel.SelectedIndex = -1;
            Cbx_Cb_Price.SelectedIndex = -1;
            Cbx_Cb_Year.SelectedIndex = -1;
            Grd_carInfo.ItemsSource = Info;
            carNameSet = false;
            carYearSet = false;
            carPriceSet = false;
            carFuelSet = false;
        }
    }
}






