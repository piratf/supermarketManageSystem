using System.Data;

namespace BLL
{
    public class BLLUserConfig
    {

        public static DataTable getProvince()
        {
            DataTable dt = DAL.DALUserConfig.getProvince();
            return dt;
        }

        /// <summary>
        /// 根据城市选择地区
        /// </summary>
        /// <param name="_city"></param>
        /// <returns></returns>
        public static DataTable getAreaFromCity(string _city)
        {
            DataTable dt = DAL.DALUserConfig.getAreaFromCity(_city);
            return dt;
        }
    }
}
