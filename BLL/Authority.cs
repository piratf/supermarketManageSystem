using System.Collections.Generic;
using System.Data;
namespace BLL
{
    public class Authority
    {
        public static Dictionary<string, string> getAuthorityRelation()
        {
            Dictionary<string, string> authorityRelation = new Dictionary<string, string>();
            DataTable dt = DAL.Authority.getAuthorityTable();
            foreach (DataRow dr in dt.Rows)
            {
                authorityRelation.Add(dr[0].ToString(), dr[1].ToString());
            }
            return authorityRelation;
        }

        public static DataTable getAuthorityTable()
        {
            return DAL.Authority.getAuthorityTable();
        }

        public static bool setAuthority(Model.User _user)
        {
            return DAL.Authority.setAuthority(_user.UserID, _user.Level, _user.Supermarket);
        }

        public static DataTable getSupermarketList()
        {
            return DAL.Authority.getSupermarketList();
        }
    }
}
