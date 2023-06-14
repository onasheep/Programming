using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614
{
    public class Print001       // 클래스의 접근 수준이 public
    {
        public static string staticMessage = default;
        private string message = "인스턴스 필드에 미리 넣어둔 값";

        public void PrintMessage(string localMessage)       // 매서드의 접근 수준도 public
        {
            message = localMessage;
            Console.WriteLine("이런걸 출력할것 -> {0}" , message);
        }       // PrintMessage()


        //public static void PrintMessage()
        //{
        //    Console.WriteLine("Static 메서드에서 인스턴스 필드를 찍어볼 수 있을까? - > {0}", message)
        //}

    }
}
