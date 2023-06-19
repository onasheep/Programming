using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619
{
    public partial class Dog : MonsterBase
    {

        public void PrintAnotherThings()
        {
            Console.WriteLine("파일을 2개로 나누었다." +
                "정말로 Dog 클래스에서 이 함수를 Call 할 수 있을까?");
        }
    }
}
