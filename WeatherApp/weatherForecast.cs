using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class weatherForecast
    {
        public city city { get; set; }
        public List<list> list { get; set; } // forecast list   
        public string country { get; set; }
        public string population { get; set; }
        public string timezone { get; set; }
    }
       
    public class main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double brnd_level { get; set; }
        public double humidity { get; set; }
        public double temp_kf { get; set; }
    }
    public class weather
    {
        public int id { get; set; }
        public string main { get; set; } // weather condition
        public string description { get; set; } // weather description
        public string icon { get; set; }
    }
    public class city
    {
        public string id { get; set; }
        public string name { get; set; }
        public coord coord { get; set; }
        public string country { get; set; }
    }
    public class coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }
 
    public class clouds
    {
        public double all { get; set; }
    }

    public class wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class sys
    {
        public string pod { get; set; }
    }
    public class list
    {
        public double dt { get; set; } // day in milli second
        public main main { get; set; } // pressure hpa
        public List<weather> weather { get; set; } // weather list
        public clouds clouds { get; set; } 
        public wind wind { get; set; } // humidity &
        public sys sys { get; set; } // wind speed km/h
        public DateTime dt_txt { get; set; }   
    }
}
