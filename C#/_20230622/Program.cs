using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230622
{
    public class Program
    {
        static void Main(string[] args)
        {
          

        }


        // Generic <T> 
        public void Desc001()
        {
            List<int> intList = new List<int>();

            CustomClass customClass = new CustomClass();

            CustomChild customChild = new CustomChild();

            customChild.Intialize(0, 1);



            PrintValue(customClass);

        }

        // string split
        public void Desc002()
        {
            string str = "I am a boy";



            string[] strArray = str.Split(' ');

            Console.WriteLine("몇 개로 split 되었는가? -> {0}", strArray.Count());
            Console.WriteLine();

            foreach (string str_ in strArray)
            {
                Console.WriteLine("{0}", str_);
            }
        }

        // nullable
        public void Desc003()
        {
            List<int> intList = new List<int>();

            CustomClass customClass = new CustomClass();

            CustomChild customChild = new CustomChild();

            customChild.Intialize(0, 1);



            PrintValue(customClass);

            customChild = null;

            if (customChild == null)
            {
                Console.WriteLine("customChild는 null 입니다.");
            }
            else
            {
                customChild.PrintPosition();
            }

            // 위와 아래는 예외 메세지 출력외에는 동일하다 
            customChild?.PrintPosition();

            // ? 를 넣지 않으면 null 값이 담기지 않는다
            //int? number = null;
            //int number = null;

        }

        // tuple 튜플
        public void Desc004()
        {
            // 튜플 선언하는 법
            (int xPos, int yPos) playerPosition = (0, 1);
            playerPosition.xPos = 10;
            playerPosition.yPos = 20;



            Console.WriteLine("Player position: ({0},{1})", playerPosition.xPos, playerPosition.yPos);
            // 튜플로 스왑하기
            (playerPosition.xPos, playerPosition.yPos) = (playerPosition.yPos, playerPosition.xPos);
            Console.WriteLine("Player position: ({0},{1})", playerPosition.xPos, playerPosition.yPos);

        }

        // 얕은 복사, 깊은 복사
        public void Desc005()
        {
            List<int> intList = new List<int>();

            CustomClass customClass = new CustomClass();
            CustomClass customClass1 = default;


            CustomChild customChild = new CustomChild();
            CustomChild customChild2 = default;
            CustomChild customChild3 = new CustomChild();

            // 얕은 복사.. customChild2는 customChild의 주소를 가리키므로 customChild2가 변경되면 customChild도 변경 된다.
            customChild2 = customChild;

            customChild.Intialize(0, 1);

            // 각 값은 0, 0
            customChild3.Intialize(customClass.xPos, customClass.yPos);

            customChild2.PrintPosition();

        }


        static void PrintValue<T>(T anyValue) where T : CustomClass
        {
            anyValue.PrintPosition();
        }


        //static void PrintValue(int intValue)
        //{
        //    Console.WriteLine("int 매개변수로 넘겨받은 값을 출력했다. -> {0}", intValue);
        //}

        //static void PrintValue(float floatValue)
        //{
        //    Console.WriteLine("float 매개변수로 넘겨받은 값을 출력했다. -> {0}", floatValue);
        //}
        //static void PrintValue(string stringValue)
        //{
        //    Console.WriteLine("string 매개변수로 넘겨받은 값을 출력했다. -> {0}", stringValue);
        //}
    }
}
