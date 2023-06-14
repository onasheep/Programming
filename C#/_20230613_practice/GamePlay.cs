using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _20230613_practice
{
    public class GamePlay
    {


        public void Paly(Shop itemShop, List<Item> itemList, List<Item> inventory, Player player)
        {
            // 시작화면 그리기
            Console.WriteLine("게임을 시작하려면 아무 키나 누르세요");
            Console.ReadKey(true);

            // 아이템 리스트 및 플레이어(인벤토리, 코인) 초기화
            itemShop.InitItemInfo(itemList);
            player.InitPlayer(inventory,500);

            Console.Clear();

            while (true)
            {
                if(itemList.Count < 3)
                {
                    Console.Clear();
                    Console.WriteLine("준비된 아이템을 모두 소진하였습니다.");
                    Console.WriteLine("영업 종료하겠습니다.");
                    return;
                }

                if(player.coin <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("가지고 있는 코인을 모두 소모하셨습니다.");
                    Console.WriteLine("영업 종료하겠습니다.");
                    return;

                }


                Console.WriteLine("현재 코인 : {0}", player.coin);
                Console.WriteLine();
                Console.Write("-------------------------------------------------");
                itemShop.GetRandomItem(itemList, out List<Item> showedItem);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("상점에 오신 것을 환영합니다.");
                Console.WriteLine();
                Console.WriteLine("3가지 아이템을 보여드립니다.");
                Console.WriteLine();
                Console.WriteLine("원하시는 아이템의 숫자를 눌러 주세요. (1 ~ 3)");

                // 상점에 나타난 아이템의 가격보다 소지금이 작은 경우 게임 종료

                if (player.coin < GetItemCost(showedItem))
                {
                    Console.Clear();
                    Console.WriteLine("이런, 소지금이 부족하신것 같습니다.");
                    Console.WriteLine("물건을 팔 수 없을것 같네요.");
                    Console.WriteLine("영업 종료하겠습니다.");
                    return;
                }


                // true if 문으로 전부를 묶고 else 문으로 예외 처리를 했었는데
                // false 문으로 예외 처리를 하고, 일반문에서 처리 
                if (int.TryParse(Console.ReadLine(), out int num) == false)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

                // 정상 입력 처리하는 로직 {

                if (num > 3)
                {
                    Console.Clear();
                    continue;
                }

          

                Console.Clear();
                int selNum = num - 1; // 인덱스 접근하기 때문에 -1 을 해준다.

                player.inventory.Add(showedItem[selNum]);

                if ((player.coin - player.inventory[player.inventory.Count - 1].itemPrice) < 0)
                {
                    player.inventory.RemoveAt(player.inventory.Count - 1);
                    Console.WriteLine("가지고 있는 코인으로 살 수 있는 아이템을 선택하세요.");
                    Print_Invetory(player.inventory);

                    continue;
                }

                player.coin -= player.inventory[player.inventory.Count - 1].itemPrice;

                itemShop.DeleteItem(itemList, player.inventory[player.inventory.Count - 1]);
                Console.WriteLine("{0} 아이템을 구매했습니다.", player.inventory[player.inventory.Count - 1].itemName);
                Print_Invetory(player.inventory);
                // 정상 입력 처리하는 로직 }


                // LEGACY:

                //if (int.TryParse(Console.ReadLine(), out int num))
                //{
                //    if (num > 3)
                //    {
                //        Console.Clear();
                //        continue;
                //    }


                //    Console.Clear();
                //    selNum = num - 1; // 인덱스 접근하기 때문에 -1 을 해준다.

                //    myInventory.Add(showedItem[selNum]);

                //    if ((myCoin - myInventory[myInventory.Count - 1].itemPrice) < 0)
                //    {
                //        myInventory.RemoveAt(myInventory.Count - 1);
                //        Console.WriteLine("가지고 있는 코인으로 살 수 있는 아이템을 선택하세요.");
                //        Print_Invetory(myInventory);

                //        continue;
                //    }

                //    myCoin -= myInventory[myInventory.Count - 1].itemPrice;

                //    itemShop.DeleteItem(itemList, myInventory[myInventory.Count - 1]);
                //    Console.WriteLine("{0} 아이템을 구매했습니다.", myInventory[myInventory.Count - 1].itemName);
                //    Print_Invetory(myInventory);


                //    // LEGACY:
                //    //else
                //    //{
                //    //    myCoin -= myInventory[myInventory.Count - 1].itemPrice;

                //    //    itemShop.DeleteItem(itemList, myInventory[myInventory.Count - 1]);
                //    //    Console.WriteLine("{0} 아이템을 구매했습니다.", myInventory[myInventory.Count - 1].itemName);
                //    //    Print_Invetory(myInventory);
                //    //}


                //}
                //else
                //{
                //    Console.Clear();
                //    Console.WriteLine("잘못된 입력입니다.");
                //}

            }


        }

        public int GetItemCost(List<Item> showedItem)
        {
            int minCost = 1000;

            for(int i = 0; i < showedItem.Count;i++)
            {
                if(minCost > showedItem[i].itemPrice)
                {
                    minCost = showedItem[i].itemPrice;
                }
            }
            return minCost;
        }


        // 인벤토리 목록 출력 함수
        public void Print_Invetory(List<Item> inventory)
        {
            Console.WriteLine();
            Console.WriteLine("현재 인벤토리 목록 ");

            Console.WriteLine("===================================================");
            foreach (Item item in inventory)
            {
                Console.WriteLine("아이템 이름 : {0} | 아이템 가격 : {1}", item.itemName, item.itemPrice);

            }
            Console.WriteLine("===================================================");

        }

        
    }
}
