using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230616
{
    public class InputManager
    {
        // 반환 값이 없으므로 static 
        public static int Input_Mapsize()
        {
            int input = default;
            while (true)
            {
                Console.WriteLine("맵의 크기를 입력하세요. (3 ~ 15)");

                string s = Console.ReadLine();
                int.TryParse(s, out input);

                if (input < 3 || input > 15)
                {
                    Console.WriteLine("제대로 된 숫자를 입력하세요.");
                    continue;

                }
                return input;
            }
        }
        // 반환 값이 없으므로 static 

        public static ConsoleKey InputKey()
        {
            ConsoleKeyInfo inputKey = Console.ReadKey();
            
            return inputKey.Key;

        }
    }
}
