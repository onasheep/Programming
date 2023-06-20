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

        public static int[] portal_Y = new int[4]{ 6, 1, 11, 6 };

        public static int[] portal_X = new int[4] { 1, 6, 6, 11 };
       

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


            Random rand = new Random();






            // 장애물 넣기



            for (int i = 0; i < 10; i++)
            {
                rand_Y = rand.Next(2, BOARD_Y - 2);
                rand_X = rand.Next(2, BOARD_X - 2);
                board[rand_X, rand_Y] = "▣";

            }





            //int portal_Pos = rand.Next(0, 4);


            //board[portal_Y[portal_Pos], portal_X[portal_Pos]] = "♨";

            board[6,11]= "♨";

        }


    }
}
