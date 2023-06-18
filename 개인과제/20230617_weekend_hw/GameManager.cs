using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230617_weekend_hw
{
    public class GameManager
    {
        public static char[,] map;
        
        public void InitMap(out int playerCol, out int playerRow)
        {
            // 맵초기화
            map = new char[20, 40];
            int maxColIndex = map.GetLength(0);
            int maxRowIndex = map.GetLength(1);

            for (int colIndex = 0; colIndex < maxColIndex; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < maxRowIndex; rowIndex++)
                {
                    if (colIndex == 0 || colIndex == maxColIndex - 1 || rowIndex == 0 || rowIndex == maxRowIndex - 1)
                    {
                        map[colIndex, rowIndex] = '#';
                        continue;
                    }
                    map[colIndex, rowIndex] = ' ';

                }
            }

            // 카드게임 좌표 및 위치 설정
            map[CardGame.cgPosCol, CardGame.cgPosRow] = 'C';

            // 몬스터배틀 좌표 및 위치 설정
            map[MonsterBattle.mbPosCol, MonsterBattle.mbPosRow] = 'M';

            // 상점 좌표 및 위치 설정
            map[Shop.sPosCol, Shop.sPosRow] = 'S';

            // 플레이어 좌표 및 위치 설정
            Player myPlayer = new Player();
            playerCol = myPlayer.PPosCol;
            playerRow = myPlayer.PPosRow;

            map[playerCol, playerRow] = 'P';
        }       // InitMap()


        public void Draw_ConsoleMap()
        {
            int colSize = map.GetLength(0);
            int rowSize = map.GetLength(1);

            for(int colIndex = 0; colIndex < colSize; colIndex++ )
            {
                for(int rowIndex = 0; rowIndex < rowSize; rowIndex++)
                {

                    Console.Write("{0}", map[colIndex,rowIndex]);
                    
                }
                Console.WriteLine();
            }
        }       //Draw_ConsoleMap()

        // 입력 키값 반환
        public static ConsoleKey InputKey()
        {
            ConsoleKeyInfo inputKey = Console.ReadKey();

            return inputKey.Key;
        }       
    }
}
