using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _20230612
{

    public class Goblin : MonsterBase
    {
        public override void Print_MonsterInfo()
        {
            base.Print_MonsterInfo();

        }
        public override void Init(string name, int hp, int mp, int damage, int defence, string type)
        {
            base.Init(name, hp, mp, damage, defence, type); 
            // 이렇게 부모에 정의 되어 있는 함수를 내려 받아서 사용하는 것은 
            // overriding 이라고 한다.
        }       
    }

 

   
    
}
