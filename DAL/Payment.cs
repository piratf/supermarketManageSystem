using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DataBaseHelper;

namespace DAL
{
    public class Payment
    {
        readonly static string supermarketTable = "[dbo].[supermarket]";
        readonly static string moneyColumn = "supermarketMoney";
        readonly static string nameColumn = "supermarketName";


        static string SQLString = string.Empty;

        /// <summary>
        /// 增加超市的金额数
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_money"></param>
        /// <returns></returns>
        public static bool addMoney(string _name, decimal _money)
        {
            Hashtable paraList = new Hashtable();
            SQLString = "update " + supermarketTable + " set " + moneyColumn + " = @Money where " + nameColumn + " = '" + _name + "'";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Money", SqlDbType.Money);
            parameters[0].Value = _money;
            paraList.Add(SQLString, parameters);
            try
            {
                return DbHelperSQL.ExecuteReturnSqlTran(paraList) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取超市的金额数
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static DataTable getMoney(string _name)
        {
            SQLString = "select " + moneyColumn + " from " + supermarketTable + " where " + nameColumn + " = '" + _name + "'";
            try
            {
                return DbHelperSQL.ExecQueryTable(SQLString);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加售卖记录
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_purchaseContent"></param>
        /// <param name="_purchaseDiscount"></param>
        /// <param name="_purchaseCost"></param>
        /// <param name="_purchaseTime"></param>
        /// <param name="_purchaseNote"></param>
        /// <returns></returns>
        public static bool addPurchaseLog(string _userID, string _purchaseContent, int _purchaseDiscount, decimal _purchaseCost, int _purchaseCount , string _purchaseNote)
        {
            SqlParameter userID = new SqlParameter("@userID", SqlDbType.VarChar);
            userID.Value = _userID;
            SqlParameter purchaseContent = new SqlParameter("@purchaseContent", SqlDbType.VarChar);
            purchaseContent.Value = _purchaseContent;
            SqlParameter purchaseDiscount = new SqlParameter("@purchaseDiscount", SqlDbType.Int);
            purchaseDiscount.Value = _purchaseDiscount;
            SqlParameter purchaseCost = new SqlParameter("@purchaseCost", SqlDbType.Money);
            purchaseCost.Value = _purchaseCost;
            SqlParameter purchaseCount = new SqlParameter("@purchaseCount", SqlDbType.Int);
            purchaseCount.Value = _purchaseCount;
            SqlParameter purchaseNote = new SqlParameter("@purchaseNote", SqlDbType.VarChar);
            purchaseNote.Value = _purchaseNote;
            SqlParameter[] paras = { userID, purchaseContent, purchaseDiscount, purchaseCost, purchaseCount, purchaseNote };
            int value = 0;
            try
            {
                return DbHelperSQL.RunProcedure("[dbo].[insertPurchaseLog]", paras, value) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取物品当前的数量
        /// </summary>
        /// <param name="_itemID"></param>
        /// <returns></returns>
        public static int getCurrentCount(string _itemID)
        {
            SqlParameter itemID = new SqlParameter("@itemID", SqlDbType.VarChar);
            itemID.Value = _itemID;
            itemID.Direction = ParameterDirection.Input;
            SqlParameter[] paras = { itemID };
            SqlDataReader dr;
            try
            {
                dr = DbHelperSQL.RunProcedure("[dbo].[getItemCount]", paras);
            }
            catch (SqlException)
            {

                throw;
            }
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            if (dt.Rows.Count > 0)
            {
                return (int)dt.Rows[0][0];
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 设置物品新的数量
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_itemCount"></param>
        /// <returns></returns>
        public static bool setItemCount(string _itemID, int _itemCount)
        {
            SqlParameter itemID = new SqlParameter("@itemID", SqlDbType.VarChar);
            itemID.Value = _itemID;
            itemID.Direction = ParameterDirection.Input;
            SqlParameter itemCount = new SqlParameter("@itemCount", SqlDbType.Int);
            itemCount.Value = _itemCount;
            itemCount.Direction = ParameterDirection.Input;
            SqlParameter[] paras = { itemID, itemCount };
            int value = 0;
            try
            {
                return DbHelperSQL.RunProcedure("[dbo].[decreaseItemCount]", paras, value) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
