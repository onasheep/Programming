using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _20230621_practice
{
    public class GamePlay
    {
        int bestScore = default;
        
        int player_Y = 1;
        int player_X = 1;

        int enemyCount = 0;
        int enemyMaxCount = 5;

        List<Enemy> enemyList;

        public void Play()
        {
            int score = 0;

            Random rand = new Random();
            MapMaker mapMaker = new MapMaker();
            Enemy myEnenmy;
            
                        
            mapMaker.Init();

            string[,] myMap = mapMaker.board;
            enemyList = new List<Enemy>();


            myMap[player_Y, player_X] = "♡";

        

            while(true)
            {



                // 맵그리기

                for (int i = 0; i < myMap.GetLength(0) - 1; i++)
                {

                    for (int j = 0; j < myMap.GetLength(1) - 1; j++)
                    {
                        Console.Write(myMap[i, j]);
                    }
                    Console.WriteLine();

                }

                Console.WriteLine("점수 : {0}", score);



             

                Input(myMap,ref score);



                // 적 랜덤 생성 후 , 리스트에 담기

                // 오래 고민했던 문제 
                // 리스트에 있는 모든 좌표 값들이 같고, 마지막에 생성되는 적만 움직이는 문제가 잇었음
                // Enemy Class 초기화를 상단에서 한번하고 그대로 계속 사용하고 있어서 문제가 발생한것이였음;
                // 리스트에 넣기전에 new를 통해서 새로 만들어주니 문제없이 작동했다.
                while (enemyCount < enemyMaxCount)
                {
                    myEnenmy = new Enemy();
                    int enemy_Y = rand.Next(2, myMap.GetLength(0) - 2);
                    int enemy_X = rand.Next(2, myMap.GetLength(1) - 2);
                    myEnenmy.Init("◎", enemy_Y, enemy_X);
                    enemyList.Add(myEnenmy);
                    
                    if (myMap[enemyList[enemyCount].Enemy_Y, enemyList[enemyCount].Enemy_X] == "□" && enemy_Y != player_Y && enemy_X != player_X)
                    {                      
                        myMap[enemyList[enemyCount].Enemy_Y, enemyList[enemyCount].Enemy_X] = enemyList[enemyCount].Mark;
                        enemyCount++;
                        break;
                    }
                    else
                    {
                        enemyList.RemoveAt(enemyList.Count - 1);
                    }
                }


                // 적이 플레이어 쫒아가기


                for (int i = 0; i < enemyCount; i++)
                {
                    enemyList[i].ComparePos(myMap, player_Y, player_X);
                    if (enemyList[i].Enemy_X == player_X && enemyList[i].Enemy_Y == player_Y)
                    {
                        myMap[enemyList[i].Enemy_Y, enemyList[i].Enemy_X] = "□";
                        myMap[player_Y, player_X] = "◎";

                        return;
                    }
                }



                Console.SetCursorPosition(0, 0);
            }



        }

        public void Input(string[,] myMap, ref int score)
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (player_Y > 1 && myMap[player_Y - 1, player_X] != "▣")
                    {
                        myMap[player_Y, player_X] = "□";
                        player_Y -= 1;
                        score += 1;
                    }
                    myMap[player_Y, player_X] = "♡";



                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (player_Y < myMap.GetLength(0) - 3 && myMap[player_Y + 1, player_X] != "▣")
                    {
                        myMap[player_Y, player_X] = "□";
                        player_Y += 1;
                        score += 1;
                    }
                    myMap[player_Y, player_X] = "♡";

                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (player_X > 1 && myMap[player_Y, player_X - 1] != "▣")
                    {
                        myMap[player_Y, player_X] = "□";
                        player_X -= 1;
                        score += 1;
                    }


                    myMap[player_Y, player_X] = "♡";

                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (player_X < myMap.GetLength(1) - 3 && myMap[player_Y, player_X + 1] != "▣")
                    {
                        myMap[player_Y, player_X] = "□";
                        player_X += 1;
                        score += 1;

                    }

                    myMap[player_Y, player_X] = "♡";
                    break;


            }
        }
    }
}
