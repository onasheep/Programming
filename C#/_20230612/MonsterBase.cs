using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230612
{
    public class MonsterBase
    {
        // 캡슐화 -> 필드를 private로 처리해서 외부에서 접근 불가능하도록 하겠다는 의미
        // protected 는 상속받은 자식 클래스에서는 쓸 수 있도록 하겠다는 의미
        protected string name;
        protected int hp;
        protected int mp;
        protected int damage;
        protected int defence;
        protected string type;

        public virtual void Init(string name, int hp, int mp, int damage, int defence, string type)
        {
            //초기화라는 의미
            this.name = name;
            this.hp = hp;
            this.mp = mp;
            this.damage = damage;
            this.defence = defence;
            this.type = type;
        }       // Init()

        public virtual void Print_MonsterInfo()
        {
            Console.WriteLine("몬스터 :{0} Hp :{1} Mp :{2} damage :{3} defence :{4} type :{5}", name, hp, mp, damage, defence, type);
        
        }
    }       // MonsterBase()
}
