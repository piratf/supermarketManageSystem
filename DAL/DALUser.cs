using System.Data;
using System.Data.SqlClient;
using DataBaseHelper;

namespace DAL
{
    public class DALUser
    {
        private static string SQLString = string.Empty;
        private static readonly string userInfoSafeView = "userInfoSafeView";
        private static readonly string userInfoFullView = "userInfoFullView";

        /// <summary>
        /// 通过视图获取不包括密码的用户表
        /// </summary>
        /// <returns></returns>
        public static DataTable getUserInfoSafe()
        {
            SQLString = "select * from " + userInfoSafeView;
            return DbHelperSQL.ExecQueryTable(SQLString);
        }

        /// <summary>
        /// 通过外连接视图获取除密码外用户的完整信息
        /// </summary>
        /// <returns></returns>
        public static DataTable getUserInfoFull()
        {
            SQLString = "select * from " + userInfoFullView;
            return DbHelperSQL.ExecQueryTable(SQLString);
        }

        /// <summary>
        /// 修改用户的密码
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static bool changePassword(string _userID, string _password)
        {
            string enc_password = DESEncrypt.Encrypt(_password);
            SqlParameter userID = new SqlParameter("@userID", SqlDbType.VarChar);
            userID.Value = _userID;
            SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar);
            password.Value = enc_password;
            SqlParameter[] paras = { userID, password };
            int result = 0;
            return DbHelperSQL.RunProcedure("[dbo].[setPassword]", paras, result) > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="_userID"></param>
        /// <returns></returns>
        public static bool deleteUser(string _userID)
        {
            SqlParameter userId = new SqlParameter("@userID", SqlDbType.VarChar);
            userId.Value = _userID;
            userId.Direction = ParameterDirection.Input;
            int result = 0;
            SqlParameter[] paras = { userId };
            return DbHelperSQL.RunProcedure("[dbo].[deleteUser]", paras, result) > 0;
        }
    }
}
