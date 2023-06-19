using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _20230619
{
    public class Program
    {
        static void Main(string[] args)
        {

            Desc003();
        }

        static void Desc001()
        {
            int number = 10;
            char charValue = 'A';
            string textStr = "Hello World!";

            object canSave1 = number;
            object canSave2 = charValue;
            object canSave3 = textStr;

            var canSaveAnything1 = number;
            var canSaveAnything2 = charValue;
            var canSaveAnything3 = textStr;

            int number2 = (int)canSave1;

            Console.WriteLine(canSave1);
            Console.WriteLine(canSave2);
            Console.WriteLine(canSave3);
        }

        static void Desc002()
        {
            Parent myParent = new Parent();
            Child myChild = new Child();

            //myParent.PrintInfos();
            //myChild.PrintInfos();


            Parent tempParent = myChild;
            Child tempChild = (Child)tempParent;
            // 다운 캐스팅 할때 자식 클래스가 부모 클래스가 가지고 있지 않은 임의의 변수를 가지고 있을 때 
            // 변수에 접근 할 수 가 없다.



            tempParent.PrintInfos();
            tempChild.PrintInfos();
        }

        // MonsterBase를 사용하는 List 사용법
        static void Desc003()
        {
            // ! List 안의 Elelment가 유요한지 검사한다.
            
            List<MonsterBase> monsterList = new List<MonsterBase>();

            if (monsterList.IsValid())
            {
                Console.WriteLine("이 리스트는 유효하다. Null도 아니고 값도 들어 있다.");
            }
            else
            {
                Console.WriteLine("이 리스트는 유효하지 않다. Null이거나 값이 없다.");
            }



            Dictionary<string, MonsterBase> monsterDic = new Dictionary<string, MonsterBase>();

            Wolf wolf = new Wolf();
            Slime slime = new Slime();
            Dog dog = new Dog();

            monsterList.Add(wolf);
            monsterList.Add(slime);
            monsterList.Add(dog);





            // 타입은 명시되는게 더 좋다 var 말고 MonsterBase
            foreach (MonsterBase monster_ in monsterList)
            {
                monster_.PrintInfos();
            }


        }

        static void Desc004()
        {
            int number = 10;


            number.PlusAndPrint(2);
        }
    }
}
