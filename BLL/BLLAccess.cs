using System.Collections.Generic;
using DAL;
using Model;
using System.Data.SqlClient;

namespace BLL
{
    public class BLLAccess
    {
        readonly static string userName = "userID";
        readonly static string userLevel = "levelID";
        readonly static string userSupermarketID = "supermarketID";

        /// <summary>
        /// 判断是否可以登录
        /// 判断用户名是否存在
        /// 判断密码是否正确
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static int login(string _username, string _password)
        {
            if (DALAccess.isNameExist(_username))
            {
                if (DALAccess.checkPwd(_username, _password))
                {
                    //success
                    return 0;
                }
                //wrong password
                return 1;
            }
            //worng username
            return -1;
        }

        public static void setUserList()
        {
            DALAccess.setUserList();
        }

        /// <summary>
        /// 得到一个键值对组
        /// 键值对为(用户名， 用户等级)
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public static User fillUserInfo(string _userName)
        {
            Dictionary<string, string> userInfo = DALAccess.fillUserInfo(_userName);
            Model.User user = new Model.User();
            try
            {
                user.UserID = userInfo[userName];
                user.Level = int.Parse(userInfo[userLevel]);
                user.Supermarket = userInfo[userSupermarketID];
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            return user;
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="_userName"></param>
        /// <returns></returns>
        public static bool isNameExist(string _userName)
        {
            return DALAccess.isNameExist(_userName);
        }

        /// <summary>
        /// 注册新的用户
        /// </summary>
        /// <param name="_userName"></param>
        /// <param name="_pwd"></param>
        /// <param name="_lev"></param>
        /// <returns></returns>
        public static bool regist(string _userName, string _pwd, int _lev)
        {
            try
            {
                return DALAccess.regist(_userName, _pwd, _lev);
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
