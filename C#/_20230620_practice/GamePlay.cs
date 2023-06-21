using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230620_practice
{
    public class GamePlay
    {
        int p_Y = 7;
        int p_X = 7;
        int mapIndex;

        List<string[,]> mapList;

        public void Init()
        {
            Map map = new Map();

            map.Init();

            string[,] myMap = map.board;

            mapList = new List<string[,]>();
            mapList.Add(myMap);
        }
        

        public void Play()
        {
            Init();

            mapIndex = mapList.Count - 1;


            SetPlayerPos(mapList[mapIndex], p_Y, p_X);
            DrawBoard(mapList[mapIndex]);

            while (true)
            {




                MovePlayer(mapList[mapIndex], ref p_Y, ref p_X);

                Console.SetCursorPosition(0, 0);


                DrawBoard(mapList[mapIndex]);




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

        public void SetPlayerPos(string[,] myMap , int playerPos_Y, int playerPos_X)
        {
            // 플레이어 넣기
            while (true)
            {

                if (myMap[playerPos_Y, playerPos_X] == "□")
                {
                    p_Y = playerPos_Y;
                    p_X = playerPos_X;
                    break;
                }

            }

        }
        // 인풋
        public void MovePlayer(string[,] myMap,ref int p_Y, ref int p_X)
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

                    if (p_Y == MapMaker.portal_Y[3] && p_X == MapMaker.portal_X[3] - 1)
                    {
                        Init();
                        DrawBoard(mapList[mapIndex]);
                        SetPlayerPos(mapList[mapIndex], MapMaker.portal_Y[1], MapMaker.portal_X[1]);
                        mapList[mapIndex][p_Y, p_X] = "◀";
                        mapList[mapIndex][MapMaker.portal_Y[1], MapMaker.portal_X[1]] = "♨";
                        Console.Clear();
                    }

                    if (p_X > 1 && myMap[p_Y , p_X - 1] != "▣")
                    {
                        myMap[p_Y, p_X] = "□";
                        p_X--;

                    }
                    myMap[p_Y, p_X] = "◀";

                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (p_Y == MapMaker.portal_Y[1] && p_X == MapMaker.portal_X[1] - 1)
                    {
                        Init();
                        DrawBoard(mapList[mapIndex]);
                        SetPlayerPos(mapList[mapIndex],MapMaker.portal_Y[3], MapMaker.portal_X[3]);
                        mapList[mapIndex][p_Y, p_X] = "▶";
                        mapList[mapIndex][MapMaker.portal_Y[3], MapMaker.portal_X[3]] = "♨";
                        Console.Clear();
                    }

                    if (p_X < myMap.GetLength(1) - 2 && myMap[p_Y , p_X + 1] != "▣")
                    {
                        myMap[p_Y, p_X] = "□";
                        p_X++;

                    }
                    myMap[p_Y, p_X] = "▶";
                    break;

            }

        }

        public void EnterPortal()
        {

            if (p_Y == MapMaker.portal_Y[0] && p_X == MapMaker.portal_X[0])
            {
                p_Y = MapMaker.portal_Y[2] - 1;
                p_X = MapMaker.portal_X[2];

                Console.Clear();
            }
            if (p_Y == MapMaker.portal_Y[1] && p_X == MapMaker.portal_X[1])
            {
                p_Y = MapMaker.portal_Y[3] ;
                p_X = MapMaker.portal_X[3] + 1;

                Console.Clear();
            }
            if (p_Y == MapMaker.portal_Y[2] && p_X == MapMaker.portal_X[2])
            {
                p_Y = MapMaker.portal_Y[0] + 1;
                p_X = MapMaker.portal_X[0];

                Console.Clear();
            }
            if (p_Y == MapMaker.portal_Y[3] && p_X == MapMaker.portal_X[3])
            {
                p_Y = MapMaker.portal_Y[1] + 1;
                p_X = MapMaker.portal_X[1];

                Console.Clear();
            }
        }
     

    }
}
