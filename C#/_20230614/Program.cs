using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackNumbers = new Stack<int>();
            stackNumbers.Push(1);
            stackNumbers.Pop();
            
        }

        public static void Desc001()
        {
            //Print001 printClass = new Print001();
            //printClass.PrintMessage();
            Print001.staticMessage = "여기에 값이 들어가나?";
            Console.WriteLine(Print001.staticMessage);


            List<int> numbers = new List<int>();


            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i + 1);
            }

            foreach (int n in numbers)
            {
                Console.Write("{0} ", n);
            }
            Console.WriteLine();




            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine("[데이터 지우는 중] 내가 지우려는 데이터 -> {0}", numbers[i]);
                    numbers.RemoveAt(i);
                }

            }
            Console.WriteLine("내 리스트의 크기는 몇일까? -> {0}", numbers.Count);


        }

        public static void Desc002()
        {
            Dictionary<string, int> myInventory = new Dictionary<string, int>();
            myInventory.Add("빨간 포션", 5);
            myInventory.Add("골드", 500);
            myInventory.Add("몰락한 왕의 검", 1);



            ItemInfo redPotion = new ItemInfo();
            ItemInfo gold = new ItemInfo();
            ItemInfo sword = new ItemInfo();

            redPotion.InitItem("빨간 포션", 5, 100);
            gold.InitItem("골드", 500, 1);
            sword.InitItem("몰락한 왕의 검", 1, 39800);

            Dictionary<string, ItemInfo> myInventory2 = new Dictionary<string, ItemInfo>();
            myInventory2.Add("빨간 포션", redPotion);
            myInventory2.Add("골드", gold);
            myInventory2.Add("몰락한 왕의 검", sword);

            foreach (var item in myInventory2)
            {
                Console.WriteLine("아이템 이름: {0}, 아이템 갯수: {1}, 아이템 가격: {2}", item.Value.itemName, item.Value.itemCount, item.Value.itemPrice);
            }



            //foreach (KeyValuePair<string, int> item in myInventory)
            //{
            //    Console.WriteLine("아이템 이름 : {0}, 아이템 갯수 : {1}", item.Key, item.Value);
            //}

            //Console.WriteLine("아이템 갯수 : {0}", myInventory["빨간 포션"]);
        }
    }
}
