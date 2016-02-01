using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WeatherToday
    {
        public InfoToday weatherInfo;
    }

    public class InfoToday
    {
        public string city;     //cityName  
        public string temp1;    // high temperature  
        public string temp2;    // low temperature
        public string weather;  // weather 
        public string ptime;    // update time  
    }
}
