using System;
using System.Data;

namespace BLL
{
    public class TableMethod
    {
        /// <summary>
        /// 通过视图获取物品类别表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetitemClassTable()
        {
            return DAL.TableMethod.GetitemClassTable();
        }

        /// <summary>
        /// 插入新的物品类别
        /// </summary>
        /// <param name="_ic"></param>
        /// <returns></returns>
        public static bool insertItemClass(Model.itemClass _ic)
        {
            if (_ic.ItemNote == "")
            {
                _ic.ItemNote = null;
            }
            return DAL.TableMethod.insertItemClass(_ic.ItemID, _ic.ItemName, _ic.ItemNote);
        }

        /// <summary>
        /// 删除一个物品类别
        /// </summary>
        /// <param name="_classID"></param>
        /// <returns></returns>
        public static bool deleteItemClass(String _classID)
        {
            return DAL.TableMethod.deleteItemClass(_classID);
        }

        /// <summary>
        /// 获取超市列表
        /// </summary>
        /// <returns></returns>
        public static DataTable getSupermarketList()
        {
            return DAL.TableMethod.getSupermarketList();
        }
    }
}
