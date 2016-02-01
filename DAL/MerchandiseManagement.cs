using System;
using System.Data.SqlClient;
using DataBaseHelper;
using System.Data;

namespace DAL
{
    public class MerchandiseManagement
    {
        private static string SQLString = string.Empty;

        /// <summary>
        /// 通过存储过程修改物品
        /// </summary>
        /// <param name="_item">Item类</param>
        /// <returns></returns>
        public static bool modifyItem(string _itemID, decimal _itemPrice, int _itemDiscount, string _itemExtraNote, int _itemCount)
        {
            SqlParameter itemID = new SqlParameter("@itemID", SqlDbType.VarChar);
            itemID.Value = _itemID;
            itemID.Direction = ParameterDirection.Input;
            SqlParameter itemPrice = new SqlParameter("@itemPrice", SqlDbType.Decimal);
            itemPrice.Value = _itemPrice;
            itemPrice.Direction = ParameterDirection.Input;
            SqlParameter itemDiscount = new SqlParameter("@itemDiscount", SqlDbType.Int);
            itemDiscount.Value = _itemDiscount;
            itemDiscount.Direction = ParameterDirection.Input;
            SqlParameter itemExtraNote = new SqlParameter("@itemExtraNote", SqlDbType.VarChar);
            itemExtraNote.Value = _itemExtraNote;
            itemExtraNote.Direction = ParameterDirection.Input;
            SqlParameter itemCount = new SqlParameter("@itemCount", SqlDbType.Int);
            itemCount.Value = _itemCount;
            itemCount.Direction = ParameterDirection.Input;
            SqlParameter[] paras = { itemID, itemPrice, itemDiscount, itemExtraNote, itemCount };
            int val = 0;
            try
            {
                return DbHelperSQL.RunProcedure("updateItemInfo", paras, val) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 通过存储过程获取指定类别的物品列表
        /// </summary>
        /// <param name="_className"></param>
        /// <returns></returns>
        public static DataTable getItemListFromClassID(string _classID)
        {
            SqlParameter classID = new SqlParameter("@classID", SqlDbType.Char);
            classID.Value = _classID;
            SqlParameter[] paras = {classID};
            DataTable dt = new DataTable();
            dt.Load(DbHelperSQL.RunProcedure("getItemByClassID", paras));
            return dt;
        }


        /// <summary>
        /// 通过存储过程添加物品
        /// </summary>
        /// <param name="_item">Item类</param>
        /// <returns></returns>
        public static bool insertItem(string _classID, string _itemName, decimal _itemPrice, int _itemDiscount, string _itemExtraNote, int _itemCount)
        {
            // 加密规则是物品名为value，类别编号为key
            string itemID = DataBaseHelper.DESEncrypt.Encrypt(_itemName, _classID);
            SqlParameter[] paras = new SqlParameter[7];
            paras[0] = new SqlParameter("@classID", SqlDbType.VarChar);
            paras[0].Value = _classID;
            paras[1] = new SqlParameter("@itemID", SqlDbType.VarChar);
            paras[1].Value = itemID;
            paras[2] = new SqlParameter("@itemName", SqlDbType.VarChar);
            paras[2].Value = _itemName;
            paras[3] = new SqlParameter("@itemPrice", SqlDbType.Money);
            paras[3].Value = _itemPrice;
            paras[4] = new SqlParameter("@itemDiscount", SqlDbType.Int);
            paras[4].Value = _itemDiscount;
            paras[5] = new SqlParameter("@itemExtraNote", SqlDbType.VarChar);
            paras[5].Value = _itemExtraNote;
            paras[6] = new SqlParameter("@itemCount", SqlDbType.VarChar);
            paras[6].Value = _itemCount;
            try
            {
                int val = 0;
                return DbHelperSQL.RunProcedure("[dbo].[insertItem]", paras, val) > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 通过存储过程删除物品
        /// </summary>
        /// <param name="_item">Item类</param>
        /// <returns></returns>
        public static bool deleteItem(string _itemID)
        {
            SqlParameter[] paras = new SqlParameter[7];
            paras[0] = new SqlParameter("@itemID", SqlDbType.VarChar);
            paras[0].Value = _itemID;
            paras[0].Direction = ParameterDirection.Input;
            try
            {
                int val = 0;
                return DbHelperSQL.RunProcedure("[dbo].[deleteItem]", paras, val) > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 从商品名称中中模糊搜索字符串
        /// 长度范围为32字节
        /// </summary>
        /// <param name="_condition"></param>
        /// <returns></returns>
        public static DataTable searchItem(string _condition)
        {
            SqlParameter condition = new SqlParameter("@condition", SqlDbType.VarChar);
            condition.Value = _condition;
            condition.Direction = ParameterDirection.Input;
            SqlParameter[] paras = { condition };
            try
            {
                SqlDataReader dr = DbHelperSQL.RunProcedure("[dbo].[searchItem]", paras);
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                return dt;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
