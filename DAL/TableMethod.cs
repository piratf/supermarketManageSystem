using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DataBaseHelper;

namespace DAL
{
    public class TableMethod
    {
        private readonly static string itemClassTable = "[dbo].[itemClass]";
        private readonly static string userTable = "[dbo].[user]";
        private readonly static string itemTable = "[dbo].[ItemList]";
        private readonly static string supermarketTable = "[dbo].[supermarket]";

        private readonly static string itemClassKey = "classID";
        private readonly static string userLevel = "levelID";
        private readonly static string itemClassView = "itemClassView";
        private readonly static string itemListView = "itemListView";

        private static string SQLString = string.Empty;

        /// <summary>
        /// 通过视图获取物品类别表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetitemClassTable()
        {
            SQLString = "select * from " + itemClassView;
            return DbHelperSQL.ExecQueryTable(SQLString);
        }
        
        /// <summary>
        /// 通过视图获取物品列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetItemListTable()
        {
            SQLString = "select * from " + itemListView;
            return DbHelperSQL.ExecQueryTable(SQLString);
        }

        public static bool insertItemClass(string _classID, string _className, string _classNote)
        {
            Hashtable paraList = new Hashtable();
            SQLString = "insert into " + itemClassTable + " values(@classID ,@className, @classNote)";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@classID", SqlDbType.VarChar);
            parameters[0].Value = _classID;
            parameters[1] = new SqlParameter("@className", SqlDbType.VarChar);
            parameters[1].Value = _className;
            parameters[2] = new SqlParameter("@classNote", SqlDbType.VarChar);
            parameters[2].Value = _classNote;

            paraList.Add(SQLString, parameters);
            return DbHelperSQL.ExecuteReturnSqlTran(paraList) > 0;
        }

        public static bool deleteItemClass(string _classID)
        {
            Hashtable paraList = new Hashtable();
            SQLString = "delete from " + itemClassTable + " where " + itemClassKey + " = '" + _classID + "'";

            return DbHelperSQL.ExecuteSql(SQLString) > 0;
        }

        public static DataTable getSupermarketList()
        {
            SQLString = "select * from " + supermarketTable;
            return DbHelperSQL.ExecQueryTable(SQLString);
        }      
    }
}
