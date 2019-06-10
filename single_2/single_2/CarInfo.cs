using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace single_2
{
    public class CarInfo
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string Year { get; set; }
        public string Fuel { get; set; }
        public string Type { get; set; }
        public string seats { get; set; }
        public int fuelTankCapacity { get; set; }
        public string horsePower { get; set; }
        public string carType { get; set; }
        public string image { get; set; }

        [XmlIgnore]
        public string imagePath
        {
            get
            {
                return @"\Resources\Images\" + image;
            }
        }
    }
}
