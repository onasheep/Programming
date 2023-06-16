using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _20230615_practice
{
    public class Stone
    {
        public char StoneIcon { get; private set; }
        public List<int[]>StonePos { get; set; }

        public void InitStone()
        {

            StoneIcon = 'o';          

        }
        public void Set_StonePos(int mapSize)
        {
            Random rand = new Random();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    int[,] arr = new int[3,2]; ;
                    int stoneCol = rand.Next(0, mapSize);
                    int stoneRow = rand.Next(0, mapSize);
                    arr[i, j] = stoneCol;
                    arr[i, j] = stoneRow;


                }


            }
        }       // Set_StonePos()


    }
}
