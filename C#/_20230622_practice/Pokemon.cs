using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace _20230622_practice
{
    public class Pokemon
    {
        // 맵
        string[,] myMap;
        const int map_Y = 10;
        const int map_X = 20;

        // 플레이어 좌표
        int player_Y = default;
        int player_X = default;

        // 타일맵 
        BushTile bushTile;
        List<BushTile> bushTileList;
        bool isBush = false;

        // NPC 
        Npc myNpc;

        // 몬스터 배틀
        MonsterBattle monsterBattle;

        // 퀘스트 목표
        int questCount;
        int questMaxCount;
        bool isFirstQuest = true;
        bool isQuestLog = false;

        public void Init()
        {
            myMap = new string[map_Y, map_X];

            for(int y = 0; y < map_Y; y ++)
            {
                for(int x = 0; x < map_X; x++)
                {
                    if (y == 0 || x == 0 || y == map_Y - 1|| x == map_X - 1)
                    {
                        myMap[y, x] = "■";
                        continue;
                    }
                    myMap[y, x] = "□";

                }
            }


            // 부쉬 맵에 넣기
            // 맵에 넣은 부쉬를 리스트에 넣기
            bushTileList = new List<BushTile>();
            
            for (int y = map_Y / 3; y < map_Y / 2; y++)
            {
                for (int x = map_X / 3; x < map_X / 2; x++)
                {
                    bushTile = new BushTile();
                    bushTile.Init(y, x);
                    bushTileList.Add(bushTile);
                    myMap[y, x] = bushTile.Tile;

                }
            }

            // 플레이어 넣기

            player_Y = map_Y / 2;
            player_X = map_X / 2;
            myMap[player_Y, player_X] = "○";



            // 몬스터 배틀 초기화
            monsterBattle = new MonsterBattle();

            // NPC 초기화
            myNpc = new Npc();
            myNpc.Init();
            myMap[myNpc.NpcY, myNpc.NpcX] = myNpc.NpcMark;
        }
        public void DrawMap()
        {

  
            for (int i = 0; i < map_Y; i++)
            {
                for (int j = 0; j < map_X; j++)
                {
                    if (myMap[i, j] == bushTile.Tile)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (myMap[i, j] == "♥")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (myMap[i, j] == "○")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (myMap[i,j] == "■")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    }
                    Console.Write("{0}", myMap[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
                
            }
            
            for (int i = 0; i < bushTileList.Count; i++)
            {
                myMap[bushTileList[i].BushY, bushTileList[i].BushX] = bushTileList[i].Tile;
            }
            myMap[myNpc.NpcY, myNpc.NpcX] = myNpc.NpcMark;
        }       // DrawMap()

        public void DrawQuestLog()
        {
            Console.SetCursorPosition(40, 1);
            Console.WriteLine("┌──────────────────────┐");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("│       퀘스트 목록    │");
            Console.SetCursorPosition(40, 3);
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 4);
            Console.WriteLine("│  1. {0}   {1} / {2}│",myNpc.QuestName,questCount,questMaxCount);
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 6);            
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 8);
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("│                      │");      
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("│                      │");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("└──────────────────────┘");

        }       // DrawQuestLog()
        public void Play()
        {
            Init();

            while (true)
            {
                DrawMap();



                Input();

                if(isQuestLog)
                {
                    DrawQuestLog();
                }


                Console.SetCursorPosition(0, 0);


            }

        }

        
        // 부쉬 좌표인지 체크
        // 부쉬 좌표라면 확률 계산후 배틀 실행
        public void CheckBush()
        {
            for(int i = 0; i < bushTileList.Count;i++)
            {
                if(player_Y == bushTileList[i].BushY && player_X == bushTileList[i].BushX)
                {
                    isBush = true;
                    if (bushTile.Check_Encount() < bushTileList[i].MaxPer)
                    {
                        monsterBattle.Play();
                        if(monsterBattle.IsPlayerWin && !isFirstQuest)
                        {
                            questCount += 1;
                      
                        }

                    }
                }
              
            }


        }

        public void CheckNpc()
        {
            if (player_Y == myNpc.NpcY && player_X == myNpc.NpcX)
            {
                if (isFirstQuest)
                {
                    questMaxCount = myNpc.NpcQuestNum;
                    isFirstQuest = false;
                    isQuestLog = true;
                }
                if (questCount >= questMaxCount && myNpc.DialogIndex >= 1)
                {
                    Console.Clear();
                    myNpc.PrintDiaglog2();
                    Thread.Sleep(1000);

                }
                else if (questCount < questMaxCount)
                {
                    isQuestLog = false;
                    Console.Clear();
                    myNpc.PrintDialog1();
                    isQuestLog = true;
                    myNpc.DialogIndex += 1;

                }


            }
        }





        public void Input()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (myMap[player_Y - 1, player_X] == "♥")
                    {
                        player_Y -= 1;
                        CheckNpc();
                        player_Y += 1;
                    }
                    else if (player_Y > 1 && !isBush)
                    {
                        myMap[player_Y, player_X] = "□";
                        player_Y -= 1;
                        CheckBush();
                        CheckNpc();
                    }
                    else if (isBush && myMap[player_Y - 1, player_X] == "□")
                    {
                        isBush = false;
                        player_Y -= 1;
                    }
                    else if (isBush)
                    {
                        CheckBush();
                        player_Y -= 1;
                    }

                    myMap[player_Y, player_X] = "○";



                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (myMap[player_Y + 1, player_X] == "♥")
                    {
                        player_Y += 1;
                        CheckNpc();
                        player_Y -= 1;
                    }
                    else if (player_Y < myMap.GetLength(0) - 1 && !isBush)
                    {
                        myMap[player_Y, player_X] = "□";
                        player_Y += 1;
                        CheckBush();
                        CheckNpc();
                    }
                    else if (isBush && myMap[player_Y + 1, player_X] == "□")
                    {
                        isBush = false;
                        player_Y += 1;
                    }
                    else if(isBush)
                    {
                        CheckBush();
                        player_Y += 1;
                    }
                    else if (myMap[player_Y + 1,player_X] == "♥")
                    {
                        break;
                    }

                    myMap[player_Y, player_X] = "○";

                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (myMap[player_Y, player_X - 1] == "♥")
                    {
                        player_X -= 1;
                        CheckNpc();
                        player_X += 1;
                    }
                    else if (player_X > 1 && !isBush)
                    {
                        myMap[player_Y, player_X] = "□";
                        player_X -= 1;
                        CheckBush();
                        CheckNpc();
                    }
                    else if (isBush && myMap[player_Y , player_X - 1] == "□")
                    {
                        isBush = false;
                        player_X -= 1;
                    }
                    else if(isBush)
                    {
                        CheckBush();
                        player_X -= 1;
                    }
                    else if (myMap[player_Y , player_X - 1] == "♥")
                    {
                        break;
                    }
                    myMap[player_Y, player_X] = "○";

                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (myMap[player_Y, player_X + 1] == "♥")
                    {
                        player_X += 1;
                        CheckNpc();
                        player_X -= 1;
                    }
                    else if (player_X < myMap.GetLength(1) - 1 && !isBush )
                    {
                        myMap[player_Y, player_X] = "□";
                        player_X += 1;
                        CheckBush();
                        CheckNpc();
                    }
                    else if (isBush && myMap[player_Y, player_X + 1] == "□")
                    {
                        isBush = false;
                        player_X += 1;
                    }
                    else if(isBush)
                    {
                        CheckBush();
                        player_X += 1;

                    }
                    else if (player_Y == myNpc.NpcY && player_X + 1 == myNpc.NpcX )
                    {
                        break;
                    }
                    myMap[player_Y, player_X] = "○";
                    break;


            }
        }       // Input()
    }
}
