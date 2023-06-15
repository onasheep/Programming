using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20230613
{
    public class CoinGame
    {
        private char[,] starArr;

        int size = 0;

        int curPRow = 0;
        int curPColumn = 0;
        int futPRow = 0;
        int futPColumn = 0;
        
        int move = 0;
        int score = 0;
        int maxScore = 100;


        // 초기화
        // starArr 2차원 배열에  *을 넣어준다.
        // 최초로 지정될  플레이어 위치값을 Random을 이용해서 구하고 배열에 넣어준다.
        // 현재 위치값에 최초 위치값을 대입한다.
        public void Init(int size)
        {

            starArr = new char[size, size];
            for (int i = 0; i < starArr.GetLength(0); i++)
            {
                for (int j = 0; j < starArr.GetLength(1); j++)
                {
                    starArr[i, j] = '*';

                }
            }


            Random rand = new Random();
            int row = rand.Next(0, size);
            int column = rand.Next(0, size);

            starArr[column, row] = 'P';
            curPRow = row;
            curPColumn = column;

            Console.Clear();

        }


        // 게임판을 그려준다.
        public void DrawLine()
        {
            
            for (int i = 0; i < starArr.GetLength(0); i++)
            {
                for (int j = 0; j < starArr.GetLength(1); j++)
                {
                    Console.Write(starArr[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine();

            }


        }

        // move 변수는 PlayerMove() 함수가 실행되면 1씩 증가하고 3이 되면 코인을 생성하고 move 값을 0으로 초기화해준다.
        // coin 위치도 Random 을 사용하여 구하고 배열에 넣어준다. 다만, 같은 코인이나 플레이어에 그려지면 안되므로 if문으로 제어한다.
        public void CoinSpawn(int size)
        {
            if (move >= 3)
            {
                move = 0;

                Random rand = new Random();
                int randCRow = rand.Next(0, size);
                int randCColumn = rand.Next(0, size);

                if (starArr[randCColumn, randCRow] == '*' && starArr[randCColumn, randCRow] != 'P')
                {
                    starArr[randCColumn, randCRow ] = 'C';
                }
            }
        }

        //  키 입력을 받고, 입력받은 키가 키보드 방향키에 해당하는 경우 
        public void MovePlayer()
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.RightArrow)
            {
                // 방향키를 눌렀을 경우 starArr 배열에서 해당 뱡향키 방향으로 +1 만큼 증가하므로, 미리 if()문을 통해서 코인인 C가 존재하는지 체크.
                // 존재한다면, 해당 위치를 *로 그리고 score에 10점을 더해주고, 점수를 출력.
                if (starArr[futPColumn, futPRow + 1] == 'C')
                {
                    starArr[futPColumn, futPRow + 1] = '*';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                // 이후 실제로 Row 값을 늘려서 미래위치를 이동시켜주고, Swap()함수를 실행한다.
                futPRow += 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);
                move += 1;
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                if (starArr[futPColumn, futPRow - 1] == 'C')
                {
                    starArr[futPColumn, futPRow - 1] = '*';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                futPRow -= 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);
                move += 1;
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (starArr[futPColumn - 1, futPRow] == 'C')
                {
                    starArr[futPColumn - 1, futPRow] = '*';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                futPColumn -= 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);
                move += 1;
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (starArr[futPColumn + 1, futPRow] == 'C')
                {
                    starArr[futPColumn + 1, futPRow] = '*';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                futPColumn += 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);
                move += 1;
            }



        }


        // Swap() 함수의 매게변수를 ref 형태로 하여 함수 내에서 변수 스왑이 외부에도 적용될 수 있도록 함.
        // temp 형태에 이동 할 좌표와 해당 좌표의 표시를 담고, starArr 배열의 이동 할 좌표 표시로 변경하고
        // 현재 좌표의 표시를 temp에 담아두었던 이동 할 좌표의 표시로 바꾼다. 
        // 현재 좌표값을 temp에 담아두었던 이동 할 좌표값을 넣어준다. 
        public void Swap(ref int pColumn, ref int pRow, ref int futPColumn, ref int futPRow)
        {
            int tempCol = 0;
            int tempRow = 0;
            char temp = ' ';

            tempCol = futPColumn;
            tempRow = futPRow;
            temp = starArr[futPColumn, futPRow];

            starArr[futPColumn, futPRow] = starArr[pColumn, pRow];
            starArr[pColumn, pRow] = temp;

            pColumn = tempCol;
            pRow = tempRow;

        }


        // 실제 게임 실행 함수
        public void Play()
        {
            Console.WriteLine("배열의 사이즈를 입력하세요.");
            
            // goto 사용하지 말기. 아예 없다고 생각하자

            while(true)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out int num))
                {
                    size = num;

                    if (size >= 5 && size <= 15)
                    {
                        Init(size);
                        DrawLine();
                        Console.WriteLine("코인을 모아서 100점을 획득하세요!");
                        break;

                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력값을 누르셨습니다. 다시 입력해 주세요.");
                    }

                }
            }
            


            while (true)
            {

                // MovePlayer()가 실행되기 전 미래 플레이어 위치값 즉, futPRow와 futPColumn 값에 현재 위치값인 curPRow와 curPColumn을 넣어준다.
                // while문을 실행하면서 플레이어가 이동을 하더라도, 계속해서 현재값을 미래 이동 값에 담을 수 있게 한다.
                futPRow = curPRow;
                futPColumn = curPColumn;

                MovePlayer();

                CoinSpawn(size);

                Console.SetCursorPosition(0, 0);

                DrawLine();

                Console.WriteLine();
                if(score >= maxScore)
                {
                    Console.WriteLine("게임을 클리어 했습니다.");
                    Thread.Sleep(1000);
                    break;
                }
            }


        }
       
    }
}
