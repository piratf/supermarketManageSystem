using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WeatherNow
    {
        public InfoNow weatherInfo;
    }

    public class InfoNow
    {
        public string city;     //城市  
        public string temp;     //温度  
        public string WD;       //风向  
        public string WS;       //风力  
        public string SD;       //相对湿度  
        public string time;     //更新时间
    }
}
