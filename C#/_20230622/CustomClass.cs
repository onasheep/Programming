using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230622
{
    public class CustomClass
    {
        public int xPos;
        public int yPos;

        public void Intialize(int xPos_, int yPos_)
        {
            xPos = xPos_;
            yPos = yPos_;
        }

        public virtual void PrintPosition()
        {
            Console.WriteLine("현 위치는 [{0}, {1}] 입니다.", xPos, yPos);
        }
    }
}
