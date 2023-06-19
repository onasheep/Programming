using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619
{
    public class MonsterBase
    {
        protected string name = default;

        public virtual void PrintInfos()
        {
            Console.WriteLine("몬스터의 이름은 :{0} ", name);
        }


    }
}
