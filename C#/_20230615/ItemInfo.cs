using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230615
{
    public class ItemInfo
    {
        private string itemName;
        public int ItemCount {  get; private set; }

        private int _itemPrice;
        public int ItemPrice
        {
            get
            {
                return _itemPrice;
            }
            private set
            {
                _itemPrice = value;
            }
        }

        // 생성자
        public ItemInfo()
        {

        }

        public void InitItem(string name, int count, int price)
        {
            itemName = name;
            ItemCount = count;
            ItemPrice = price;

        }       // InitItem()


        // getter 함수 , setter 함수
        // 아이템 name을 Return 해보겠음.
        public string Get_ItemName()
        {
            return itemName;
        }       // Get_ItemName()

        //! 아이템 name을 외부에서 변결할 수 있게 해주겠음.
        public void Set_ItemName(string changedName)
        {
            itemName = changedName;
        }       // Set_ItemName()
    
    
    }

   
}
