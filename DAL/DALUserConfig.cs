using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DataBaseHelper;

namespace DAL
{
    public class DALUserConfig
    {
        private static string SQLString = string.Empty;
        private static string CityCodeTable = "[dbo].[CityCode]";
        private static string UserLocationTable = "[dbo].[UserLocation]";
        
        //public User getUserConfig(User _user)
        //{
        //    SQLString = "select * from [dbo].[UserSetting] where username = '" + ;
        //    DataTable dt = DbHelperSQL.ExecQueryTable(SQLString);
        //    _user.Location.City = dt.Rows[0]["area"].ToString();
        //    return _user;
        //}

        /// <summary>
        /// 获得省和直辖市列表
        /// </summary>
        /// <returns>二维数组</returns>
        public static DataTable getProvince()
        {
            SQLString = "select province from " + CityCodeTable;
            DataTable dt = deWeight(DbHelperSQL.ExecQueryTable(SQLString), "province");
            return dt;
        }
        
        /// <summary>
        /// 根据省名查找市
        /// </summary>
        /// <param name="_province"></param>
        /// <returns></returns>
        public static DataTable getCityFromProvince(string _province)
        {
            SQLString = "select city from " + CityCodeTable + " where province = '" + _province + "'";
            DataTable dt = deWeight(DbHelperSQL.ExecQueryTable(SQLString), "city");
            return dt;
        }

        /// <summary>
        /// 根据城市获得地区列表
        /// </summary>
        /// <param name="_province"></param>
        /// <returns></returns>
        public static DataTable getAreaFromCity(string _city)
        {
            SQLString = "select area from " + CityCodeTable + " where city = '" + _city + "'";
            DataTable dt = deWeight(DbHelperSQL.ExecQueryTable(SQLString), "area");
            return dt;
        }

        private static DataTable deWeight(DataTable _dt, string _col)
        {
            DataTable dt = _dt;
            DataView dv = new DataView(dt);
            DataTable dt2 = dv.ToTable(true, _col);
            return dt2;
        }

        public static bool setUserLocation(string _ipv4, string _country, string _province, string _city, string _area)
        {
            Hashtable paraList = new Hashtable();
            SQLString = "insert into " + UserLocationTable + " values(@ipv4 , @country, @province, @city, @area)";
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@ipv4", SqlDbType.VarChar);
            parameters[0].Value = _ipv4;
            parameters[1] = new SqlParameter("@country", SqlDbType.VarChar);
            parameters[1].Value = _country;
            parameters[2] = new SqlParameter("@province", SqlDbType.VarChar);
            parameters[2].Value = _province;
            parameters[3] = new SqlParameter("@city", SqlDbType.VarChar);
            parameters[3].Value = _city;
            parameters[4] = new SqlParameter("@area", SqlDbType.VarChar);
            parameters[4].Value = _area;

            paraList.Add(SQLString, parameters);
            return DbHelperSQL.ExecuteReturnSqlTran(paraList) > 0;
        }
    }
}
