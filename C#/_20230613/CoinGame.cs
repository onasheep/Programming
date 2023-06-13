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
        private char[,] starArr = new char[,] { };
        int move = 0;
        int curPRow = 0;
        int curPColumn = 0;
        int futPRow = 0;
        int futPColumn = 0;
        int score = 0;
        int maxScore = 100;

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

        public void PlayerMove()
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.RightArrow)
            {
                if (starArr[futPColumn,futPRow + 1] == 'C')
                {
                    starArr[futPColumn, futPRow + 1] = '*';
                    starArr[curPColumn, curPRow] = 'P';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                futPRow += 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);

            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                if (starArr[futPColumn, futPRow - 1] == 'C')
                {
                    starArr[futPColumn, futPRow - 1] = '*';
                    starArr[curPColumn, curPRow] = 'P';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                futPRow -= 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);

            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (starArr[futPColumn - 1, futPRow] == 'C')
                {
                    starArr[futPColumn - 1, futPRow] = '*';
                    starArr[curPColumn, curPRow] = 'P';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                futPColumn -= 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (starArr[futPColumn + 1, futPRow] == 'C')
                {
                    starArr[futPColumn + 1, futPRow] = '*';
                    starArr[curPColumn, curPRow] = 'P';
                    score += 10;
                    Console.WriteLine("현재 점수:{0}점!", score);
                }
                futPColumn += 1;
                Swap(ref curPColumn, ref curPRow, ref futPColumn, ref futPRow);
            }


            move += 1;

        }




        public void Play()
        {
            Console.WriteLine("배열의 사이즈를 입력하세요.");

            string s = Console.ReadLine();
            if (int.TryParse(s, out int size))
            {

                if (size >= 5 && size <= 15)
                {
                    Init(size);
                    DrawLine();
                    Console.WriteLine("코인을 모아서 100점을 획득하세요!");

                }

            }


            while (true)
            {
               
               
                futPRow = curPRow;
                futPColumn = curPColumn;
                PlayerMove();


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

        public void Swap(ref int pColumn , ref int pRow, ref int futPColumn, ref int futPRow)
        {
            int tempCol = 0;
            int tempRow = 0;

            char temp = ' ';

            tempCol = futPColumn;
            tempRow = futPRow;

            temp = starArr[futPColumn, futPRow];

            starArr[futPColumn, futPRow] = starArr[pColumn, pRow];
            starArr[pColumn, pRow] = temp;

            futPColumn = pColumn;
            futPRow = pRow;

            pColumn = tempCol;
            pRow = tempRow;

        }
    }
}
