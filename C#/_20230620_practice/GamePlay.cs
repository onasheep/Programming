using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230620_practice
{
    public class GamePlay
    {
        int p_X;
        int p_Y;
        
        public void Play()
        {
            while (true)
            {
                Map map = new Map();
                map.Init();


                string[,] myMap = map.board;

                SetPlayerPos(myMap, out int player_Y, out int player_X);
                
                p_Y = player_Y;
                p_X = player_X;



                while (true)
                {
                    
                    DrawBoard(myMap);

                  
                    MovePlayer(myMap, map, ref p_Y, ref p_X);
                    Console.WriteLine("{0}", p_Y);

                    if (p_Y == MapMaker.portal_Y[3] && p_X == MapMaker.portal_X[3])
                    {
                        Console.Clear();
                        break;
                    }
                    Console.SetCursorPosition(0, 0);


                }


            }






        }
        public void DrawBoard(string[,] myMap)
        {
            for (int i = 0; i < myMap.GetLength(0); i++)
            {
                for (int j = 0; j < myMap.GetLength(1); j++)
                {
                    
                        Console.Write("{0}", myMap[i, j]);
                    
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine();

            }
        }

        public void SetPlayerPos(string[,] myMap, out int player_Y, out int player_X)
        {
            // 플레이어 넣기
            Random rand = new Random();
            while (true)
            {
                player_Y = rand.Next(3, myMap.GetLength(0) - 2);
                player_X = rand.Next(3, myMap.GetLength(1) - 2);
                if (myMap[player_Y, player_X] == "□")
                {
                    myMap[player_Y, player_X] = "▲";
                    break;
                }

            }

        }
        // 인풋
        public void MovePlayer(string[,] myMap, Map map,ref int p_Y, ref int p_X)
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:

                    if (p_Y > 1 && myMap[p_Y - 1, p_X] != "▣")
                    {
                      
                        myMap[p_Y, p_X] = "□";
                        p_Y--;
                        Console.WriteLine("{0}", p_Y);
                    }                    

                    myMap[p_Y, p_X] = "▲";


                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (p_Y < myMap.GetLength(0) - 2 && myMap[p_Y + 1, p_X] != "▣")
                    {
                        myMap[p_Y, p_X] = "□";
                        p_Y++;
                        
                    }
                    myMap[p_Y, p_X] = "▼";

                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (p_X > 1 && myMap[p_Y , p_X - 1] != "▣")
                    {
                        myMap[p_Y, p_X] = "□";
                        p_X--;

                    }
                    myMap[p_Y, p_X] = "◀";

                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (p_X < myMap.GetLength(1) - 2 && myMap[p_Y , p_X + 1] != "▣")
                    {
                        myMap[p_Y, p_X] = "□";
                        p_X++;

                    }
                    myMap[p_Y, p_X] = "▶";
                    break;

            }

        }

     

    }
}
