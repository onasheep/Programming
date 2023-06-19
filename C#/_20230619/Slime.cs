using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619
{
    public class Slime : MonsterBase
    {
        public override void PrintInfos()
        {
            this.name = "슬라임";
            base.PrintInfos();
        }

    }
}
