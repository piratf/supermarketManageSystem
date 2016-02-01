using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using Model;
using DAL;

namespace BLL
{
    public class IPPostion
    {
        /// <summary>
        /// 创建实例
        /// </summary>
        GetCityId GetCityId = new GetCityId();

        public string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return "获取本机IP出错:" + ex.Message;
            }
        }

        public string getLocation(string _ip)
        {
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.weather.com.cn/data/sk/101010100.html");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://api.map.baidu.com/location/ip?ak=A4ffdd25e9a09a3d12868749a55bfbfd&ip="+_ip+"&coor=bd09ll");
            request.Timeout = 5000;
            request.Method = "GET";
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return null;
            }
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string jsonstr = sr.ReadLine();
            if (jsonstr[0] != '{')
            {
                return null;
            }
            return jsonstr;
        }

        public IPLocation ParaseString(string _content, IPLocation _iplocation)
        {
            JavaScriptSerializer j = new JavaScriptSerializer();
            IPLocation Iplocation = new IPLocation();
            Iplocation = j.Deserialize<IPLocation>(_content);
            return Iplocation;
        }

        /// <summary>
        /// 根据ipv4地址获取城市id
        /// </summary>
        /// <param name="_ip"></param>
        /// <returns></returns>
        public string getCityId(string _ip)
        {
            IPLocation iplocation = new IPLocation();
            string locationString = getLocation(_ip);
            if (locationString == null)
            {
                return null;
            }
            iplocation = ParaseString(locationString, iplocation);
            string city = iplocation.content.address_detail.city;
            string province = iplocation.content.address_detail.province;
            string districts = iplocation.content.address_detail.district;

            string cityid = GetCityId.getCityId(province, city, districts);
            return cityid;
        }

        /// <summary>
        /// 根据现有的省市地址获取城市id
        /// </summary>
        /// <param name="_ip"></param>
        /// <returns></returns>
        public string getCityId(string _province, string _city, string _districts = "")
        {
            string province = _province;
            string city = _city;
            string districts = _districts;
            string cityid = GetCityId.getCityId(province, city, districts);
            return cityid;
        }

        /// <summary> 
        /// 得到真实IP以及所在地详细信息（Porschev） 
        /// </summary> 
        /// <returns></returns> 
        public string GetIp()
        {
            //设置获取IP地址
            string url = "http://1111.ip138.com/ic.asp";
            string pattern = @"(?<=\[).{7,15}(?=\])";
            //得到网页源码 
            string html = GetHtml(url);
            if (html == null)
            {
                return null;
            }
            Regex ipPattern = new Regex(pattern);
            //得到IP 
            return ipPattern.Match(html).Value;
        }

        /// <summary> 
        /// 获取HTML源码信息(Porschev) 
        /// </summary> 
        /// <param name="url">获取地址</param> 
        /// <returns>HTML源码</returns> 
        public string GetHtml(string url)
        {
            string str = "";
            try
            {
                Uri uri = new Uri(url);
                WebRequest wr = WebRequest.Create(uri);
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                str = sr.ReadToEnd();
            }
            catch (Exception)
            {
                return null;
            }
            return str;
        }
    }
}
