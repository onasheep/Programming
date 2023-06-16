using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230616
{
    public class GamePlay
    {
        
        void Init(Field field)
        {
            field.InitMap(InputManager.Input_Mapsize());
        }

        public void Play(Field field)
        {
            

            Init(field);
            Console.Clear();

            while (true)
            {
                field.DrawNum();
                field.DrawMap(field.Map);
                Console.WriteLine();

                MoveNum(field);

                Console.Clear();
            } 
        }

        // 키 입력과 숫자 움직임
        public void MoveNum(Field field)
        {
            ConsoleKey key = InputManager.InputKey();

            // 숫자 우측으로 밀기, 우측으로 밀기 때문에 마지막 열은 고정
            if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
            {

                // 열 이동, 열 마지막은 고정 되어야 하므로 순회하지 않는다.
                for (int colIndex = 0; colIndex < field.MapSize - 1; colIndex++)
                {
                    int sum = 0;

                    // 행 이동
                    for (int rowIndex = 0; rowIndex < field.MapSize; rowIndex++)
                    {
                        if (field.Map[colIndex, rowIndex] == 0)
                        {
                            continue;
                        }
                        sum += field.Map[colIndex, rowIndex];

                        field.Map[colIndex, rowIndex] = 0;

                    }
                    if (sum != 0)
                    {
                        // 열 마지막을 들리지 않지만 마지막 열에 존재하는 값에 그 전까지 수의 합을 더해준다.
                        field.Map[colIndex, field.MapSize - 1] += sum;
                    }

                }

            }
            // 숫자 아래로 밀기 , 아래로 밀기 때문에 마지막 행은 고정
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                // 행 이동, 행 마지막은 고정 되어야 하므로 순회하지 않는다.
                for (int rowIndex = 0; rowIndex < field.MapSize - 1; rowIndex++)
                {
                    int sum = 0;

                    // 열 이동
                    for (int colIndex = 0; colIndex < field.MapSize; colIndex++)
                    {
                        if (field.Map[colIndex, rowIndex] == 0)
                        {
                            continue;
                        }
                        sum += field.Map[colIndex, rowIndex];
                        field.Map[colIndex, rowIndex] = 0;
                    }
                    if (sum != 0)
                    {
                        // 열 마지막을 들리지 않지만 마지막 행에 존재하는 값에 그 전까지 수의 합을 더해준다.
                        field.Map[field.MapSize - 1, rowIndex] = sum;
                    }
                }

            }
        }


    }
}
