using System;
using System.Data;
using System.Reflection;

namespace BLL
{
    public class MerchandiseManagement
    {
        public static bool deleteItem(string _itemID)
        {
            return DAL.MerchandiseManagement.deleteItem(_itemID);
        }

        /// <summary>
        /// 通过存储过程添加物品
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public static bool insertItem(Model.Item _item)
        {
            try
            {
                return DAL.MerchandiseManagement.insertItem(_item.ItemClassID, _item.ItemName, _item.ItemPrice, _item.ItemDiscount, _item.ItemExtraNote == "" ? null : _item.ItemExtraNote, _item.ItemCount);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 通过存储过程修改物品
        /// </summary>
        /// <param name="_item">Item类</param>
        /// <returns></returns>
        public static bool modifyItem(Model.Item _item)
        {
            try
            {
                return DAL.MerchandiseManagement.modifyItem(_item.ItemID, _item.ItemPrice, _item.ItemDiscount, _item.ItemExtraNote == "" ? null : _item.ItemExtraNote, _item.ItemCount);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 获取指定类别的物品列表
        /// </summary>
        /// <param name="_classID"></param>
        /// <returns></returns>
        public static DataTable getItemListFromClassID(string _classID)
        {
            return DAL.MerchandiseManagement.getItemListFromClassID(_classID);
        }


        /// <summary>
        /// 利用反射机制,通过类型名称，方法名称和参数跨方法调用函数
        /// </summary>
        /// <param name="_className"></param>
        /// <param name="_methodName"></param>
        /// <param name="_paras"></param>
        /// <returns></returns>
        public static bool delegateHelper(string _className, string _methodName, object[] _paras)
        {
            Type type;
            try
            {
                type = Type.GetType(_className, true, true);
            }
            catch (Exception)
            {
                throw;
            }
            MethodInfo method = type.GetMethod(_methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (method == null)
            {
                return false;
            }
            method.Invoke(Activator.CreateInstance(type), _paras);
            return true;
        }

        /// <summary>
        /// 从商品名称中中模糊搜索字符串
        /// 长度范围为32字节
        /// </summary>
        /// <param name="_condition"></param>
        /// <returns></returns>
        public static DataTable searchItem(string _condition)
        {
            try
            {
                return DAL.MerchandiseManagement.searchItem(_condition);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
