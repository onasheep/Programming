using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230615_practice
{
    public class Field
    {
        public int[,] Map { get; private set; }
        public int MapSize { get; private set; }

        public void InitMap(int size)
        {
            Map = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Map[i, j] = 0;
                }
            }
        }

        public void DrawMap(int[,] mapArr)
        {
            // 정방형 맵이기 때문에 한쪽길이만 받아옴
            MapSize = Map.GetLength(0);
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {

                    Console.Write("{0}", Map[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }


        }

        public void DrawStone()
        {
            int numCount = 1;

            MapSize = Map.GetLength(0);
            Random rand = new Random();


            while (true)
            {
                if (numCount > 3)
                {
                    break;
                }

                int numCol = rand.Next(0, MapSize - 1);
                int numRow = rand.Next(0, MapSize - 1);
                if (Map[numCol, numRow] == 0)
                {
                    Map[numCol, numRow] = 1;
                    numCount += 1;
                }

            }


        }

    }
}
