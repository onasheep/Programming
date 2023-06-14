using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614
{
    internal class ItemInfo
    {
        public string itemName;
        public int itemCount;
        public int itemPrice;

        public void InitItem(string name, int count, int price)
        {
            this.itemName = name;
            this.itemCount = count;
            this.itemPrice = price;
        }

    }
}
