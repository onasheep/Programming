using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619
{
    public class Wolf : MonsterBase
    {
        public override void PrintInfos()
        {
            this.name = "늑대";
            base.PrintInfos();
        }
    }
}
