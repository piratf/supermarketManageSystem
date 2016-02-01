using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Model;

namespace BLL
{
    public class Weather
    {
        public WeatherToday loadWeatherToday(string _cityId)
        {
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.weather.com.cn/data/sk/101010100.html");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.weather.com.cn/data/cityinfo/" + _cityId  + ".html");
            request.Timeout = 5000;
            request.Method = "GET";
            HttpWebResponse response = null;
            WeatherToday wt = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return wt;
            }
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string jsonstr = sr.ReadLine();
            //MessageBox.Show(jsonstr);
            JavaScriptSerializer j = new JavaScriptSerializer();
            wt = new WeatherToday();
            wt = j.Deserialize<WeatherToday>(jsonstr);
            //MessageBox.Show(wt.weatherInfo.city);
            return wt;
        }

        public WeatherNow loadWeatherNow(string _cityId)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.weather.com.cn/data/sk/" + _cityId + ".html");
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.weather.com.cn/data/cityinfo/101010100.html");
            request.Timeout = 5000;
            request.Method = "GET";
            HttpWebResponse response = null;
            WeatherNow wn = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return wn;
            }
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string jsonstr = sr.ReadLine();
            //MessageBox.Show(jsonstr);
            JavaScriptSerializer j = new JavaScriptSerializer();
            wn = new WeatherNow();
            wn = j.Deserialize<WeatherNow>(jsonstr);
            //MessageBox.Show(wn.weatherInfo.city);
            return wn;
        }
    }
}
