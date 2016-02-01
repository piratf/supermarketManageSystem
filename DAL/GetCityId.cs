using System.Data;
using DataBaseHelper;

namespace DAL
{
    public class GetCityId
    {
        string SQLString = string.Empty;
        public string getCityId(string _province, string _city, string _area)
        {
            if (_area == "")
            {
                _area = _city;
            }
            SQLString = "select code from dbo.CityCode where province = '" + _province + "' and city = '" + _city + "' and area = '" + _area + "'";
            DataTable dt = DbHelperSQL.ExecQueryTable(SQLString);
            string cityCode = dt.Rows[0][0].ToString();
            return cityCode;
        }
    }
}
