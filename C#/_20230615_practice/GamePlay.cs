using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230615_practice
{
    public class GamePlay
    {
        // 위치변경
        char[,] mapArr = new char[,] { };
        int playerCol;
        int playerRow;
        int score = 0;

        public void Play()
        {     
            while(true)
            {
                DrawMenu();

                while (true)
                {
                    Console.WriteLine("맵 사이즈를 입력해주세요.");

                    string s = Console.ReadLine();

                    if (!int.TryParse(s, out int inputNum))
                    {
                        Console.WriteLine("숫자를 입력해주십시오.");
                        continue;
                    }

                    int mapSize = inputNum;

                    Init(mapSize, ref playerCol, ref playerRow);



                    DrawMap();



                    while (true)
                    {
                
                        
                        MovePlayer();
                        Console.Clear();

                        DrawMap();




                    }

                }

            }
            



        }



        public void Init(int size, ref int randPCol, ref int randPRow)
        {

            mapArr = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mapArr[i, j] = '*';

                }
            }


            Random rand = new Random();
            
            int Pcolumn = rand.Next(0, size);
            int Prow = rand.Next(0, size);

            mapArr[Pcolumn, Prow] = 'P';

            randPCol = Pcolumn;
            randPRow = Prow;


            Stone stone = new Stone();

            stone.InitStone();
            for(int i = 0; i < 3;i++)
            {
                int col = rand.Next(0, size);
                int row = rand.Next(0, size);

                mapArr[col, row] = stone.StoneIcon;
            }

            Console.Clear();

        }


        public void DrawMap()
        {


            for (int i = 0; i < mapArr.GetLength(1); i++)
            {
                for (int j = 0; j < mapArr.GetLength(0); j++)
                {
                    Console.Write(mapArr[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("현재 점수: {0}", score);

        }
        public void DrawMenu()
        {
            while (true)
            {
                Console.WriteLine("게임을 시작하려면 G 키를 누르세요.");

                ConsoleKeyInfo startButton;
                startButton = Console.ReadKey();

                if (startButton.Key != ConsoleKey.G)
                {
                    Console.Clear();
                    Console.WriteLine("G 키가 아닙니다. 다시 입력하세요. ");
                    continue;

                }
                Console.Clear();

                return;
            }

        }



        public void MovePlayer()
        {


            ConsoleKeyInfo inputKey;
            inputKey = Console.ReadKey(true);
            if (inputKey.Key == ConsoleKey.W && playerCol != 0)
            {
                if (mapArr[playerCol - 1, playerRow] == 'o')
                {
                    for (int i = playerCol - 1; i >= 0; i--)
                    {
                        if (mapArr[i, playerRow] == 'o')
                        {
                            mapArr[i + 1, playerRow] = 'o';
                            break;
                        }
                        mapArr[0, playerRow] = 'o';
                    }
                }



                mapArr[playerCol, playerRow] = '*';
                playerCol -= 1;
                mapArr[playerCol, playerRow] = 'P';
            }
            else if (inputKey.Key == ConsoleKey.S && playerCol != mapArr.GetLength(0) - 1)
            {
                if (mapArr[playerCol + 1, playerRow] == 'o')
                {
                    mapArr[mapArr.GetLength(0) - 1, playerRow] = 'o';
                }

                mapArr[playerCol, playerRow] = '*';
                playerCol += 1;
                mapArr[playerCol, playerRow] = 'P';

            }
            else if (inputKey.Key == ConsoleKey.A && playerRow != 0)
            {
                if (mapArr[playerCol, playerRow-1] == 'o')
                {
                    mapArr[playerCol, 0] = 'o';
                }

                mapArr[playerCol, playerRow] = '*';
                playerRow -= 1;
                mapArr[playerCol, playerRow] = 'P';

            }
            else if (inputKey.Key == ConsoleKey.D && playerRow != mapArr.GetLength(1) - 1)
            {
                if (mapArr[playerCol, playerRow+1] == 'o')
                {
                    mapArr[playerCol, mapArr.GetLength(1) - 1] = 'o';
                }

                mapArr[playerCol, playerRow] = '*';
                playerRow += 1;
                mapArr[playerCol, playerRow] = 'P';
            }

        }

    
    }

}
