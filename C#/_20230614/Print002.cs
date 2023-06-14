using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614
{
    public static class Print002       // 클래스의 접근 수준이 public
    {
        private static string message = default;

        public static void PrintMessage(string localMessage)       // 매서드의 접근 수준도 public
        {
            message = localMessage;
            Console.WriteLine("이런걸 출력할것 -> {0}" , message);
        }       // PrintMessage()

    }
}
