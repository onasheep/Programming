using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230621_practice
{
    public class MapMaker
    {
        public string[,] board;
        const int BOARD_Y = 20;
        const int BOARD_X = 30;

        int rand_Y;
        int rand_X;


        public  void Init()
        {

            // 맵 넣기 

            board = new string[BOARD_Y, BOARD_X];

            for (int i = 0; i < BOARD_Y; i++)
            {
                for (int j = 0; j < BOARD_X; j++)
                {
                    if (i == 0 || j == 0 || i == BOARD_Y - 2 || j == BOARD_X - 2)
                    {
                        board[i, j] = "■";
                        continue;
                    }
                    board[i, j] = "□";
                }
            }


            // 장애물 넣기
            Random rand = new Random();


            for (int i = 0; i < BOARD_X + BOARD_Y * 2; i++)
            {
                rand_Y = rand.Next(2, BOARD_Y - 2);
                rand_X = rand.Next(2, BOARD_X - 2);

                if (board[rand_Y,rand_X] == "□" && board[rand_Y,rand_X] != "▣" && board[rand_Y,rand_X] != "■")
                {
                    board[rand_Y, rand_X] = "▣";

                }
              

            }




        }

    }
}
