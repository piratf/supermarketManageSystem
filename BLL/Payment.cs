using System;
using System.Data;

namespace BLL
{
    public class Payment
    {

        /// <summary>
        /// 获取现有的金额
        /// 加上增加的金额
        /// 得到总金额
        /// 设置金额为总金额的值
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_money"></param>
        /// <returns>是否成功设置金额</returns>
        public static bool addMoney(string _name, decimal _money)
        {
            DataTable moneyTable = DAL.Payment.getMoney(_name);
            decimal currentMoney = decimal.Parse(moneyTable.Rows[0][0].ToString());
            currentMoney += _money;
            return DAL.Payment.addMoney(_name, currentMoney);
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
        public static bool addPurchaseLog(string _userID, string _purchaseContent, int _purchaseDiscount, decimal _purchaseCost, int _purchaseCount, string _purchaseNote)
        {
            return DAL.Payment.addPurchaseLog(_userID, _purchaseContent, _purchaseDiscount, _purchaseCost, _purchaseCount, _purchaseNote);
        }

        /// <summary>
        /// 获取物品当前的数量
        /// </summary>
        /// <param name="_itemID"></param>
        /// <returns></returns>
        public static int getCurrentCount(string _itemID)
        {
            return DAL.Payment.getCurrentCount(_itemID);
        }

        /// <summary>
        /// 设置物品新的数量
        /// </summary>
        /// <param name="_itemID"></param>
        /// <param name="_itemCount"></param>
        /// <returns></returns>
        public static bool setItemCount(string _itemID, int _itemCount)
        {
            return DAL.Payment.setItemCount(_itemID, _itemCount);
        }
    }
}
