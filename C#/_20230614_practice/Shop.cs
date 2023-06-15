using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614_practice
{
    public class Shop
    {  
        public void InitItemInfo(List<Item> itemList)
        {
            // Item 생성자 각각 호출
            Item redPortion = new Item();
            Item bluePortion = new Item();
            Item sword = new Item();
            Item shield = new Item();
            Item armor = new Item();
            Item helmet = new Item();
            Item bow = new Item();
            Item arrow = new Item();

            // Item 각각 초기화
            redPortion.Init("빨간 물약", 30);
            bluePortion.Init("파란 물약", 35);
            sword.Init("칼", 120);
            shield.Init("방패", 90);
            armor.Init("갑옷", 140);
            helmet.Init("헬맷", 70);
            arrow.Init("화살", 20);
            bow.Init("활", 110);

            // itemList에 아이템 추가
            itemList.Add(redPortion);
            itemList.Add(redPortion);
            itemList.Add(bluePortion);
            itemList.Add(bluePortion);
            itemList.Add(sword);
            itemList.Add(shield);
            itemList.Add(armor);
            itemList.Add(arrow);
            itemList.Add(arrow);
            itemList.Add(arrow);
            itemList.Add(bow);

        }

        // 랜덤으로 뽑아낸 아이템 선정
        // 갯수는 3개
        // 선택된 3개의 아이템은 out List<Item> showItem 로 가지고 나간다.
        // 가지고 나간 아이템들은 플레이어 선택에 의해 다시 itemList에서 제거된다.
        public void GetRandomItem(List<Item> itemList, out List<Item> showItem )
        {

            List<Item> randItem = new List<Item>();
            int count = 1;
            while(true)
            {
                if(count > 3)
                {
                    break;
                }
                Random rand = new Random();
                int randNum = rand.Next(0, itemList.Count);

                Print_Item(itemList[randNum], count);

                randItem.Add(itemList[randNum]);
                itemList.Remove(itemList[randNum]);

                count += 1;
            }

            for (int i = 0; i < randItem.Count; i++)
            {
                itemList.Add(randItem[i]);
            }

            showItem = randItem;
        }



        public void Print_Item(Item item, int itemCount)
        {
            Console.WriteLine();
            Console.WriteLine("[{0}] 아이템 이름 : {1} | 아이템 가격 : {2}", itemCount,item.itemName, item.itemPrice);
        }


        // 플레이어가 선택한 아이템을 아이템 리스트에서 제거 
        public void DeleteItem(List<Item> itemList, Item selectedItem)
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                if(selectedItem == itemList[i])
                {
                    itemList.Remove(selectedItem);
                    break;
                }
            }
        }

    }
}
