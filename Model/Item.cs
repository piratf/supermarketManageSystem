using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Item
    {
        /// <summary>
        /// 物品的类别编号
        /// </summary>
        private string itemClassID;

        public string ItemClassID
        {
            get { return itemClassID; }
            set { itemClassID = value; }
        }

        /// <summary>
        /// 物品的编号
        /// </summary>
        private string itemID;

        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        /// <summary>
        /// 物品名称
        /// </summary>
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        /// <summary>
        /// 物品价格
        /// </summary>
        private decimal itemPrice;

        public decimal ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        /// <summary>
        /// 物品折扣
        /// </summary>
        private int itemDiscount;

        public int ItemDiscount
        {
            get { return itemDiscount; }
            set { itemDiscount = value; }
        }
        
        /// <summary>
        /// 物品的额外信息
        /// </summary>
        private string itemExtraNote;

        public string ItemExtraNote
        {
            get { return itemExtraNote; }
            set { itemExtraNote = value; }
        }

        public int ItemCount
        {
            get
            {
                return itemCount;
            }

            set
            {
                itemCount = value;
            }
        }

        private int itemCount;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Item()
        {
            this.itemClassID = string.Empty;
            this.itemName = string.Empty;
            this.itemPrice = 0;
            this.itemDiscount = 0;
            this.itemExtraNote = string.Empty;
            this.ItemCount = 0;
        }

        /// <summary>
        /// 使用全部字段的构造函数
        /// </summary>
        /// <param name="_itemClassID"></param>
        /// <param name="_itemName"></param>
        /// <param name="_itemPrice"></param>
        /// <param name="_itemDiscount"></param>
        /// <param name="_itemExtraNote"></param>
        public Item(string _itemClassID, string _itemID, string _itemName, decimal _itemPrice, int _itemDiscount, string _itemExtraNote, int _itemCount = 0)
        {
            this.itemClassID = _itemClassID;
            this.itemID = _itemID;
            this.itemName = _itemName;
            this.itemPrice = _itemPrice;
            this.itemDiscount = _itemDiscount;
            this.itemExtraNote = _itemExtraNote;
            this.itemCount = _itemCount;
        }

        /// <summary>
        /// 使用部分字段的构造函数
        /// </summary>
        /// <param name="_itemClassID"></param>
        /// <param name="_itemName"></param>
        /// <param name="_itemPrice"></param>
        /// <param name="_itemDiscount"></param>
        /// <param name="_itemExtraNote"></param>
        public Item( string _itemID, decimal _itemPrice, int _itemDiscount, string _itemExtraNote, int _itemCount)
        {
            this.itemID = _itemID;
            this.itemPrice = _itemPrice;
            this.itemDiscount = _itemDiscount;
            this.itemExtraNote = _itemExtraNote;
            this.itemCount = _itemCount;
        }
    }
}
