using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230615_practice
{
    public class GamePlay
    {

        void Init(Field field)
        {
            field.InitMap(InputManager.Input_MapSize());
        }


        public void Play(Field field)
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

                    Init(mapSize, ref curPlayerCol, ref curPlayerRow);



                    //DrawMap();



                    while (true)
                    {
                
                        
                        MovePlayer();
                        Console.Clear();

                        //DrawMap();




                    }

                }

            }
           
        }       // Play()


        public void Init(int size, ref int curPCol, ref int curPRow)
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

            curPCol = Pcolumn;
            curPRow = Prow;

            // Stone 생성 및 초기화
            Stone stone = new Stone();
            
            stone.InitStone();

            stone.Set_StonePos(size);

            for(int i = 0; i < 3;i++)
            {
                int col = rand.Next(0, size);
                int row = rand.Next(0, size);

                mapArr[col, row] = stone.StoneIcon;
                
            }


            Console.Clear();

        }       // Init()






        // 메뉴 화면 그리기
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

        }       // DrawMenu()



        public void MovePlayer()
        {


            ConsoleKeyInfo inputKey;
            inputKey = Console.ReadKey(true);
            if (inputKey.Key == ConsoleKey.W && curPlayerCol != 0)
            {
                if (mapArr[curPlayerCol - 1, curPlayerRow] == 'o')
                {
                    for (int i = curPlayerCol - 1; i >= 0; i--)
                    {
                        if (mapArr[i, curPlayerRow] == 'o')
                        {
                            mapArr[i + 1, curPlayerRow] = 'o';
                            break;
                        }
                        mapArr[0, curPlayerRow] = 'o';
                    }
                }



                mapArr[curPlayerCol, curPlayerRow] = '*';
                curPlayerCol -= 1;
                mapArr[curPlayerCol, curPlayerRow] = 'P';
            }
            else if (inputKey.Key == ConsoleKey.S && curPlayerCol != mapArr.GetLength(0) - 1)
            {
                if (mapArr[curPlayerCol + 1, curPlayerRow] == 'o')
                {
                    mapArr[mapArr.GetLength(0) - 1, curPlayerRow] = 'o';
                }

                mapArr[curPlayerCol, curPlayerRow] = '*';
                curPlayerCol += 1;
                mapArr[curPlayerCol, curPlayerRow] = 'P';

            }
            else if (inputKey.Key == ConsoleKey.A && curPlayerRow != 0)
            {
                if (mapArr[curPlayerCol, curPlayerRow-1] == 'o')
                {
                    mapArr[curPlayerCol, 0] = 'o';
                }

                mapArr[curPlayerCol, curPlayerRow] = '*';
                curPlayerRow -= 1;
                mapArr[curPlayerCol, curPlayerRow] = 'P';

            }
            else if (inputKey.Key == ConsoleKey.D && curPlayerRow != mapArr.GetLength(1) - 1)
            {
                if (mapArr[curPlayerCol, curPlayerRow+1] == 'o')
                {
                    mapArr[curPlayerCol, mapArr.GetLength(1) - 1] = 'o';
                }

                mapArr[curPlayerCol, curPlayerRow] = '*';
                curPlayerRow += 1;
                mapArr[curPlayerCol, curPlayerRow] = 'P';
            }

        }


        public void Swap()
        {

        }
    
    }

}
