using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _20230617_weekend_hw
{

    public class Shop
    {
        private List<Item> itemList;
        private List<Item> showItemList;
        private List<Item> invenList;
        private int myGold;
        public static int sPosCol = 10;
        public static int sPosRow = 10;


        public void Init()
        {
            myGold = 1000;

            Item redPotion = new Item();
            Item bluePotion = new Item();
            Item sword = new Item();
            Item shield = new Item();
            Item armor = new Item();
            Item helm = new Item();
            Item bow = new Item();
            Item arrow = new Item();

            redPotion.Init("레드 포션", 20);
            bluePotion.Init("블루 포션", 30);
            sword.Init("칼", 120);
            shield.Init("방패", 80);
            armor.Init("갑옷", 150);
            helm.Init("투구", 70);
            bow.Init("활", 100);
            arrow.Init("화살", 15);


            itemList = new List<Item>
            {
                redPotion,
                bluePotion,
                sword,
                shield,
                armor,
                helm,
                bow,
                arrow
            };


            showItemList = new List<Item>();

            invenList = new List<Item>();


        }

        public void Play()
        {

            Init();

            DrawMenu();

            while (true)
            {
                GetRandomItem();


                DrawField();

                Input();

                Console.Clear();

                if (myGold <= 0)
                {
                    Console.WriteLine("소지금이 없습니다.");
                    Console.WriteLine("영업을 종료하겠습니다.");
                    Thread.Sleep(1000);
                    return;
                }
            }



           



        }

        public void GetRandomItem()
        {
            Random rand = new Random();

            showItemList.Clear();

            for (int i = 0; i < 3; i++)
            {
                int randIndex = rand.Next(0, itemList.Count);
                showItemList.Add(itemList[randIndex]);
                itemList.Remove(itemList[randIndex]);
            }



        }
        public void DrawField()
        {
            Console.WriteLine("소지금 : {0}", myGold);
            Console.WriteLine("상점");
            Console.WriteLine("==================================================================");
            for (int showIndex = 0; showIndex < showItemList.Count; showIndex++)
            {
                Console.WriteLine("{0}. {1}  :  {2}원", showIndex + 1, showItemList[showIndex].itemName, showItemList[showIndex].itemPrice);
            }

            Console.WriteLine("==================================================================");
            Console.WriteLine();
            Console.WriteLine("인벤토리");
            Console.WriteLine("──────────────────────────────────────────────────────────────────");


            if (invenList.Count == 0)
            {
                Console.WriteLine("아직 아이템이 없습니다.");
            }

            for (int invenIndex = 0; invenIndex < invenList.Count; invenIndex++)
            {

                Console.WriteLine("{0}. {1}  :  {2}원", invenIndex + 1, invenList[invenIndex].itemName, invenList[invenIndex].itemPrice);
            }
            Console.WriteLine("──────────────────────────────────────────────────────────────────");




        }

        public void DrawMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점에 오신 것을 환영합니다.");
                Console.WriteLine("게임을 시작하시려면 S키를 눌러주세요.");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                if (input.Key != ConsoleKey.S)
                {
                    continue;
                }
                return;
            }
        }

        public void Input()
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("사고 싶은 아이템의 번호를 선택해 주세요(1~ 3)");
                ConsoleKeyInfo input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        invenList.Add(showItemList[0]);
                        myGold -= showItemList[0].itemPrice;
                        foreach(Item showItem in showItemList)
                        {
                            
                            itemList.Add(showItem);
                        }
                        return;
                    case ConsoleKey.D2:
                        invenList.Add(showItemList[1]);
                        myGold -= showItemList[1].itemPrice;
                        foreach (Item showItem in showItemList)
                        {
                            itemList.Add(showItem);
                        }
                        return;
                    case ConsoleKey.D3:
                        invenList.Add(showItemList[2]);
                        myGold -= showItemList[2].itemPrice;
                        foreach (Item showItem in showItemList)
                        {
                            itemList.Add(showItem);
                        }
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("잘못된 입력입니다");
                        break;
                }

            }
        }
    }
}
