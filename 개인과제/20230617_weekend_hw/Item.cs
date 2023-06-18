using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230617_weekend_hw
{
    public class Item
    {
        public string itemName;
        public int itemPrice;
        
        public void Init(string name, int price)
        {
            this.itemName = name;
            this.itemPrice = price;
        }
    }
}
