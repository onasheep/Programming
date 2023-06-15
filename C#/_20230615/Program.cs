using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230615
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemInfo itemInfo = new ItemInfo();

            int n = itemInfo.ItemCount + 1;


        }       // Main()




        public static void Desc001()
        {
            // 내가 정의한 enum 타입 변수를 선어해 볼 것임.
            ItemType_SJ itemType;

            itemType = ItemType_SJ.POTION;
            Console.WriteLine("enum type은 무엇이라고 출력이 될까?? - > {0} ", (int)itemType);
            // 내부적으로는 숫자로 되어 있다 (int)형

            if ((int)itemType == 1)
            {
                Console.WriteLine("itemType을 int로 형변환 한 값은 1과 같은 값이 맞다");
            }



            switch (itemType)
            {
                case ItemType_SJ.POTION:
                    Console.WriteLine("이 아이템의 타입은 포션 입니다.");
                    break;
                case ItemType_SJ.GOLD:
                    Console.WriteLine("이 아이템의 타입은 골드 입니다.");
                    break;
                case ItemType_SJ.WEAPON:
                    Console.WriteLine("이 아이템의 타입은 무기 입니다.");
                    break;
                case ItemType_SJ.ARMOR:
                    Console.WriteLine("이 아이템의 타입은 방어구 입니다.");
                    break;
                default:
                    Console.WriteLine("이 아이템의 타입은 정해지지 않았습니다.");
                    break;
            }
        }
    }


}

