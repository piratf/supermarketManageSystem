using System.Data;
using System.Data.SqlClient;
using DataBaseHelper;

namespace DAL
{
    public class Authority
    {
        readonly static string authorityTable = "[dbo].[level]";
        readonly static string supermarketTable = "[dbo].[supermarket]";

        private static string SQLString = string.Empty;

        public static DataTable getAuthorityTable()
        {
            SQLString = "select * from " + authorityTable;
            return DbHelperSQL.ExecQueryTable(SQLString);
        }

        /// <summary>
        /// 设置一个用户的权限
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_level"></param>
        /// <param name="_supermarketID"></param>
        /// <returns></returns>
        public static bool setAuthority(string _userID, int _level, string _supermarketID)
        {
            SqlParameter name = new SqlParameter("@userID", SqlDbType.VarChar);
            name.Value = _userID;
            name.Direction = ParameterDirection.Input;
            SqlParameter level = new SqlParameter("@levelID", SqlDbType.Int);
            level.Value = _level;
            level.Direction = ParameterDirection.Input;
            SqlParameter supermarketID = new SqlParameter("@supermarketID", SqlDbType.VarChar);
            supermarketID.Value = _supermarketID;
            supermarketID.Direction = ParameterDirection.Input;
            SqlParameter[] paras = {name, level, supermarketID};
            int val = 0;
            return DbHelperSQL.RunProcedure("updateUserInfo", paras, val) > 0;
        }

        /// <summary>
        /// 获取超市表
        /// </summary>
        /// <returns></returns>
        public static DataTable getSupermarketList()
        {
            SQLString = "select * from " + supermarketTable;
            return DbHelperSQL.ExecQueryTable(SQLString);
        }
    }
}
