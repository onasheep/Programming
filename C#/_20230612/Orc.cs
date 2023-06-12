using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230612
{
    public class Orc : MonsterBase
    {
        
        public override void Init(string name, int hp, int mp, int damage, int defence, string type)
        {
            base.Init(name, hp, mp, damage, defence, type);
            // 이렇게 부모에 정의 되어 있는 함수를 내려 받아서 사용하는 것은 
            // overriding 이라고 한다.
        }
        public override void Print_MonsterInfo()
        {
            base.Print_MonsterInfo();         
        }

        public void Print_OverloadingTest()
        {
            Console.WriteLine("함수 찍힌다");
        }

        public void Print_OverloadingTest(int textStr)
        {
            Console.WriteLine("함수 찍힌다 -> {0}", textStr);
        }
    }
}
