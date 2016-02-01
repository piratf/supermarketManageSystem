using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户名：默认为空
    /// 用户等级：
    /// 1：售货员
    /// 2: 超市管理员
    /// 0：系统管理员
    /// </summary>
    public class User
    {
        private string userID = string.Empty;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private string supermarket;

        public string Supermarket
        {
            get { return supermarket; }
            set { supermarket = value; }
        }

        public User()
        {

        }
        public User(string _name, int _level, string _supermarket)
        {
            this.userID = _name;
            this.level = _level;
            this.supermarket = _supermarket;
        }

        public User(User _user)
        {
            this.userID = _user.userID;
            this.level = _user.level;
            this.supermarket = _user.supermarket;
        }

        public User Clone(User _user)
        {
            this.userID = _user.userID;
            this.level = _user.level;
            this.supermarket = _user.supermarket;
            return this;
        }

    }
}
