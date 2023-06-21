using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230621
{
    public  class Button : Clickable, IClickable
    {
        public override void ClickThisObject(bool isClick_)
        {
            base.ClickThisObject(isClick_);
        }

        public void Damaged(int damage)
        {
            
        }

        public void TestFunc()
        {
            Console.WriteLine("함수 테스트");
        }
    }
}
