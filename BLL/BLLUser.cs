using System.Collections.Generic;
using System.Collections;
using System.Data;

namespace BLL
{
    public class BLLUser
    {
        /// <summary>
        /// 获取用户信息的列表
        /// </summary>
        /// <returns>ArrayList 其中的对象是Model.User</returns>
        public static ArrayList getUserList()
        {
            DataTable dt = DAL.DALUser.getUserInfoSafe();
            Dictionary<string, string> userFrom = new Dictionary<string, string>();
            ArrayList UserList = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(new Model.User(dr[0].ToString(), int.Parse(dr[1].ToString()), dr[2].ToString()));
            }
            return UserList;
        }

        /// <summary>
        /// 获取不包括密码的用户表
        /// </summary>
        /// <returns></returns>
        public static DataTable getUserInfoSafe()
        {
            return DAL.DALUser.getUserInfoSafe();
        }

        /// <summary>
        /// 通过外连接视图获取除密码外用户的完整信息
        /// </summary>
        /// <returns></returns>
        public static DataTable getUserInfoFull()
        {
            return DAL.DALUser.getUserInfoFull();
        }

        /// <summary>
        /// 修改用户的密码
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static bool changePassword(string _userID, string _password)
        {
            return DAL.DALUser.changePassword(_userID, _password) ;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="_userID"></param>
        /// <returns></returns>
        public static bool deleteUser(string _userID)
        {
            return DAL.DALUser.deleteUser(_userID);
        }
    }
}
