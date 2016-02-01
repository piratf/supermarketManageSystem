using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DataBaseHelper;

namespace DAL
{
    public class DALAccess
    {
        static string SQLString = string.Empty;
        const string UserTable = "[dbo].[user]";
        const string userInfoSafeView = "userInfoSafeView";
        const string userName = "userID";
        const string password = "password";
        const string level = "levelID";
        const string supermarketID = "supermarketID";
        static HashSet<string> userList = null;

        public static bool checkPwd(string _id, string _password)
        {
            _password = DataBaseHelper.DESEncrypt.Encrypt(_password);
            SQLString = "select " + userName + ", " + password + " from " + UserTable + " where " + userName + " = '" + _id + "'";
            DataTable dt = DbHelperSQL.ExecQueryTable(SQLString);
            for (int i = 0; i < dt.Rows.Count; i++ )
            {
                string decPwd = DESEncrypt.Decrypt(dt.Rows[i][1].ToString());
                if (dt.Rows[i][0].ToString() == _id && dt.Rows[i][1].ToString() == _password)
                {
                    return true;
                }
            }
            return false;
        }

        public static void setUserList()
        {
            userList = new HashSet<string>();
            SQLString = "select " + userName + " from" + UserTable;
            DataTable dt = DbHelperSQL.ExecQueryTable(SQLString);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userList.Add(dt.Rows[i][0].ToString());
            }
        }

        public static Dictionary<string, string> fillUserInfo(string _userName)
        {
            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            SQLString = "select * from " + userInfoSafeView + " where " + userName + " = '" + _userName + "'";
            DataTable dt = DbHelperSQL.ExecQueryTable(SQLString);
            userInfo.Add(userName, dt.Rows[0][userName].ToString());
            userInfo.Add(level, dt.Rows[0][level].ToString());
            userInfo.Add(supermarketID, dt.Rows[0][supermarketID].ToString());
            return userInfo;
        }

        public static bool isNameExist(string _userName)
        {
            return userList.Contains(_userName);
        }

        /// <summary>
        /// 通过参数化过程注册用户
        /// </summary>
        /// <param name="_userName">用户名</param>
        /// <param name="_password">密码</param>
        /// <param name="_lev">用户等级编号</param>
        /// <returns></returns>
        public static bool regist(string _userName, string _password, int _lev)
        {
            Hashtable paraList = new Hashtable();
            _password = DESEncrypt.Encrypt(_password);
            SQLString = "insert into " + UserTable + " values(@userName ,@password, @levelID, null)";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@userName", SqlDbType.VarChar);
            parameters[0].Value = _userName;
            parameters[1] = new SqlParameter("@password", SqlDbType.VarChar);
            parameters[1].Value = _password;
            parameters[2] = new SqlParameter("@levelID", SqlDbType.Int);
            parameters[2].Value = _lev;
            try
            {
                paraList.Add(SQLString, parameters);
                return DbHelperSQL.ExecuteReturnSqlTran(paraList) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
