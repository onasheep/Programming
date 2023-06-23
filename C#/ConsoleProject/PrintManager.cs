using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class MapMaker

    {
        public int Board_Y { get; private set; }
        public int Board_X {get; private set;}

        public string[,] Board { get; private set; }
        public MapMaker()
        {
            Board_Y = 15;
            Board_X = 50;
            Board = new string[Board_Y, Board_X];
        }




        public void Print_GameScene()
        {
            int startX = 5;
            int startY = 1;

            Console.SetCursorPosition(startX, startY);
            Console.Write($"┌── {"< 게임 화면 >".PadRight(120, '─')}┐");

            for (int i = 0; i < 21; i++)
            {
                PaddingSpace(startX, startY + (1 + i), 127);
            }

            Console.SetCursorPosition(startX, startY + 22);
            Console.Write($"└{"".PadRight(127, '─')}┘");
        }

        public void DrawMap()
        {
            for (int i = 0; i < Board_Y; i++)
            {
                for (int j = 0; j < Board_X; j++)
                {
                    Console.Write("{0}", Board[i,j]);
                }
                Console.WriteLine();
            }
        }

        private void PaddingSpace(int x, int y, int spaceCount)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"│{" ".PadRight(spaceCount, ' ')}│");
        }
    }
}
