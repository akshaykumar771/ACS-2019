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

namespace single_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static ObservableCollection<CarInfo> Info = new ObservableCollection<CarInfo>();
       

        bool carNameSet = false;
        bool carYearSet = false;
        bool carPriceSet = false;
        bool carFuelSet = false;
        String selectedBrand = "";
        String selectedYear = "";
        int selectedPriceFrom;
        int selectedPriceTo;
        String selectedFuel = "";
        public static ObservableCollection<CarInfo> compareList = new ObservableCollection<CarInfo>();
        
        public MainWindow()
        {
            InitializeComponent();
            remoMethod();
            
            Grd_carInfo.ItemsSource = Info;
            //Grd_carInfo.
            

        }

        private void remoMethod()
        {
            var manInfo = new ObservableCollection<CarInfo>();
            //for (int i = 0; i < 5; i++)
            //{
            //    manInfo.Add(new CarInfo { Manufacturer = "BMW", Model = "520" + i, Price = 20000, Year = (2012 + i).ToString(), Type = "manual", Fuel="Petrol" });
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    manInfo.Add(new CarInfo { Manufacturer = "Benz", Model = "520" + i, Price = 40000, Year = (2014 + i).ToString(), Type = "auto", Fuel = "Diesel" });
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    manInfo.Add(new CarInfo { Manufacturer = "Audi", Model = "520" + i, Price = 60000 , Year = (2016 + i).ToString(), Type = "manual", Fuel = "Electric" });
            //}

            //manInfo.Add(new CarInfo { Manufacturer = "BMW", Model = "akshay" , Price = 30000, Year = 2016.ToString(), Type = "manual", Fuel = "Petrol" });

            Info = Storage.ReadXml<ObservableCollection<CarInfo>>("Info.xml");
            Grd_carInfo.ItemsSource = Info;
            // Storage.WriteXml<ObservableCollection<CarInfo>>(Info, "Info.xml");
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.carNameSet = true;
            //Grd_carInfo.ItemsSource = InfoToDisplay;
            var cbxValue = Cbx_Cb.SelectedValue.ToString();

            switch (cbxValue)
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }

        private void Cbx_year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.carYearSet = true;
            String cbxYearValue = Cbx_Cb_Year.SelectedItem.ToString();

            //TempInfo = new ObservableCollection<CarInfo>(from n in TempInfo where n.Year == cbxYearValue.Content select n);

            switch (cbxYearValue)
            {
                case "System.Windows.Controls.ComboBoxItem: 2012":
                    selectedYear = "2012";
                    break;
                case "System.Windows.Controls.ComboBoxItem: 2014":
                    selectedYear = "2014";
                    break;
                case "System.Windows.Controls.ComboBoxItem: 2016":
                    selectedYear = "2016";
                    break;
            }
            
        }
        private void Cbx_Cb_Price_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            }
            //Console.WriteLine(selectedPrice);
         }
        private void Cbx_Cb_Fuel_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            }
            //Console.WriteLine(selectedPrice);
        }

        private void Btn_addCompare_Click(object sender, RoutedEventArgs e)
        {
            if (Grd_carInfo.SelectedItem == null)
            {
                MessageBox.Show("Please select a car to add to the list!!");
            }
            else
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
        }

        private void Btn_gotoCompare_Click(object sender, RoutedEventArgs e)
        {
            W_compareList cmp = new W_compareList();
            cmp.Show();
        }

    

        private void Button_Sales_Click(object sender, RoutedEventArgs e)
        {
            CarSales cs = new CarSales();
            cs.Show();
        }

        private void Btn_Go_Click(object sender, RoutedEventArgs e)
        {
            bool isdataset = (carNameSet && carYearSet && carPriceSet && carFuelSet);
            if(isdataset)
            {
                var res = Info;
                if ((bool)Chbx_manual.IsChecked && (bool)Chbx_auto.IsChecked)
                {
                    //where car.Type =manual || car.type = auto
                    res = new ObservableCollection<CarInfo>(Info.Where(car => car.Manufacturer == selectedBrand && car.Year == selectedYear && car.Price >= selectedPriceFrom && car.Price <= selectedPriceTo && car.Fuel == selectedFuel && (car.Type == "manual" || car.Type == "auto")));
                }
                else
                {
                    bool isTypeSelected = false;
                    string selectedType = "";
                    if((bool)Chbx_manual.IsChecked)
                    {
                        selectedType = "manual";
                        isTypeSelected = true;
                    }
                    else if((bool)Chbx_auto.IsChecked)
                    {
                        selectedType = "auto";
                        isTypeSelected = true;
                    }

                    res = new ObservableCollection<CarInfo>(Info.Where(car => car.Manufacturer == selectedBrand && car.Year == selectedYear && car.Price >= selectedPriceFrom && car.Price <= selectedPriceTo && car.Fuel == selectedFuel && (isTypeSelected ? car.Type == selectedType : (car.Type == "manual" || car.Type == "auto"))));
                    //COndi car.Type = selectedType
                }
                //var res = Info.Where(car => car.Manufacturer == selectedBrand && car.Year == selectedYear && car.Price >= selectedPriceFrom && car.Price <= selectedPriceTo && car.Fuel == selectedFuel);
                Grd_carInfo.ItemsSource = res;
            }
            else
            {
                MessageBox.Show("Please select all the options and then proceed");
            }
        }

        private void Chbx_manual_Checked(object sender, RoutedEventArgs e)
        {
            if (Chbx_manual.IsChecked == true)
            {
                foreach (var car in Info)
                {
                    if (car.Type == "manual")
                    {
                        
                    }
                }

            }
            Console.WriteLine();

        }
    }
}

//}
//}



//private void CheckBox_Checked(object sender, RoutedEventArgs e)
//{
//    if (Chbx_manual.IsChecked == true)
//    {
//        foreach (var car in Info)
//        {
//            if (car.type == "manual")
//            {
//                InfoToDisplay.Add(car);
//            }
//        }
//    }
//    Console.WriteLine();

//}

//private void OnCheckBoxClick(object sender, RoutedEventArgs e)
//{
//    if (Chbx_manual.IsChecked == true) {
//        foreach (var car in Info)
//        {
//            if (car.type == "manual")
//            {
//                InfoToDisplay.Add(car);
//            }
//        }
//    }

//}





