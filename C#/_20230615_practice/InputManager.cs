using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230615_practice
{
    public class InputManager
    {
        public static int Input_MapSize()
        {
            while(true)
            {
                Console.WriteLine("맵의 크기를 입력하세요.");

                string s = Console.ReadLine();

                if(!int.TryParse(s, out int input))
                {

                }

                return input;

            }
        }


        public static ConsoleKey KeyInput()
        {
            ConsoleKeyInfo inputKey = Console.ReadKey();

            return inputKey.Key;
        }
    }
}
