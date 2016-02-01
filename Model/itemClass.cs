using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class itemClass
    {
        private string itemID;

        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        private string itemNote;

        public string ItemNote
        {
            get { return itemNote; }
            set { itemNote = value; }
        }
    }
}
