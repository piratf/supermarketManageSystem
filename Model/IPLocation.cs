using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class IPLocation
    {
        public string address;
        public Content content;
        public string status;
        public IPLocation()
        {
            content = new Content();
        }
    }

    public class Content
    {
        public string address;     // 地址
        public Address_detail address_detail;
        public LocationPoint point;
        public Content()
        {
            address_detail = new Address_detail();
        }
    }

    public class Address_detail
    {
        public string city;
        public string city_code;
        public string district;
        public string province;    // 省
        public string street;
        public string street_number;
        public Address_detail()
        {
            
        }
    }

    public class LocationPoint
    {
        public string x;
        public string y;
        public LocationPoint()
        {
            x = "0";
            y = "0";
        }
    }
}
