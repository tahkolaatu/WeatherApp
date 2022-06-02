using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp2
{
    public class LocalNames
    {
        public string uk { get; set; }
        public string la { get; set; }
        public string fi { get; set; }
        public string lt { get; set; }
        public string lv { get; set; }
        public string ru { get; set; }
    }

    public class PropertiesList
    {
        public string name { get; set; }
        public LocalNames local_names { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string country { get; set; }
    }

    public class CoordinatesObject
    {
        public PropertiesList PropertiesList { get; set; }
    }

}
