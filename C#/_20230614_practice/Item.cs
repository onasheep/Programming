using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614_practice
{

    // 아이템 정보
    public class Item
    {
        public string itemName;
        public int itemPrice;
        


        // 아이템 초기화 함수
        public void Init(string name, int price)
        {
            this.itemName = name;
            this.itemPrice = price;
        }


    }
}
