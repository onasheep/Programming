using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class UIManager
    {
        

        public void DrawTitleScene()
        {
            


            for (int j = 0; j < 15; j++)
            {
                Console.SetCursorPosition(70, j);
                if (j == 0)
                {
                    Console.WriteLine("┏───────────────────────────┓");
                }
                else if (j == 14)
                {
                    Console.WriteLine("┗───────────────────────────┛");
                }
                else
                {
                    Console.WriteLine("┃                           ┃");
                }
            }


        }

    }
}
