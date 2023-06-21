using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230620_practice
{
    public class MapMaker
    {
      
        public string[,] board;
        const int BOARD_X = 13;
        const int BOARD_Y = 13;

        int rand_Y;
        int rand_X;

        public static int[] portal_Y = new int[4]{ 1, 6, 11, 6 };

        public static int[] portal_X = new int[4] {6, 11, 6,  1 };
       

        public virtual void Init()
        {

            // 맵 넣기 

            board = new string[BOARD_Y, BOARD_X];

            for (int i = 0; i < BOARD_Y; i++)
            {
                for (int j = 0; j < BOARD_X; j++)
                {
                    if (i == 0 || j == 0 || j == BOARD_Y - 1 || i == BOARD_Y - 1)
                    {
                        board[j, i] = "■";
                        continue;
                    }
                    board[j, i] = "□";
                }
            }


            // 장애물 넣기
            Random rand = new Random();


            for (int i = 0; i < 10; i++)
            {
                rand_Y = rand.Next(4, BOARD_Y - 4);
                rand_X = rand.Next(4, BOARD_X - 4);
                board[rand_X, rand_Y] = "▣";

            }






          

            //board[6,11]= "♨";

        }


    }
}
