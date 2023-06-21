using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _20230621_practice
{
    public class Enemy
    {
        public string Mark { get; private set; }
        public int Enemy_Y { get; private set; }
        public int Enemy_X { get; private set; }

        public void Init(string mark,int enemyY_, int enemyX_ )
        {
            this.Mark = mark;
            this.Enemy_Y = enemyY_;
            this.Enemy_X = enemyX_;

        }
        


        public void ComparePos(string[,] myMap, int player_Y, int player_X)
        {
            Random rand = new Random();

            int yDiff = player_Y - this.Enemy_Y;
            int xDiff = player_X - this.Enemy_X;
            if (yDiff > 0)
            {
                if ( myMap[this.Enemy_Y + 1, this.Enemy_X] != "▣" )
                {
                    myMap[this.Enemy_Y, this.Enemy_X] = "□";                   
                    this.Enemy_Y += 1;
                }
                else if(myMap[this.Enemy_Y + 1, this.Enemy_X] == "▣" )
                {
                    int dir = rand.Next(0, 1);
                    switch(dir)
                    {
                        case 0:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_X += 1;
                            break;
                        case 1:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_X -= 1;
                            break;
                    }
                }
                else if (myMap[this.Enemy_Y - 1, this.Enemy_X] == "◎")
                {

                }
                myMap[this.Enemy_Y, this.Enemy_X] = this.Mark;

            }
            else if (yDiff < 0)
            {
                if ( myMap[this.Enemy_Y - 1, this.Enemy_X] != "▣" )
                {
                    myMap[this.Enemy_Y, this.Enemy_X] = "□";

                    this.Enemy_Y -= 1;
                }
                else if(myMap[this.Enemy_Y - 1, this.Enemy_X] == "▣")
                {
                    int dir = rand.Next(0, 1);
                    switch (dir)
                    {
                        case 0:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_X += 1;
                            break;
                        case 1:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_X -= 1;
                            break;
                    }
                }
                else if(myMap[this.Enemy_Y - 1, this.Enemy_X] == "◎")
                {

                }
                myMap[this.Enemy_Y, this.Enemy_X] = this.Mark;

            }
            else if (xDiff > 0)
            {
                if (myMap[this.Enemy_Y , this.Enemy_X + 1] != "▣")
                {

                    myMap[this.Enemy_Y, this.Enemy_X] = "□";
                    this.Enemy_X += 1;
                }
                else if (myMap[this.Enemy_Y , this.Enemy_X + 1] == "▣")
                {
                    int dir = rand.Next(0, 1);
                    switch (dir)
                    {
                        case 0:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_Y += 1;
                            break;
                        case 1:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_Y -= 1;
                            break;
                    }
                }
                else if (myMap[this.Enemy_Y, this.Enemy_X + 1] == "◎")
                {

                }



                myMap[this.Enemy_Y, this.Enemy_X] = this.Mark;

            }
            else if (xDiff < 0)
            {

                if (myMap[this.Enemy_Y, this.Enemy_X - 1] != "▣")
                {

                    myMap[this.Enemy_Y, this.Enemy_X] = "□";
                    this.Enemy_X -= 1;
                }
                else if (myMap[this.Enemy_Y, this.Enemy_X - 1] == "▣")
                {
                    int dir = rand.Next(0, 1);
                    switch (dir)
                    {
                        case 0:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_Y += 1;
                            break;
                        case 1:
                            myMap[this.Enemy_Y, this.Enemy_X] = "□";
                            this.Enemy_Y -= 1;
                            break;
                    }
                }
                else if (myMap[this.Enemy_Y, this.Enemy_X - 1] == "◎")
                {

                }
                

                myMap[this.Enemy_Y, this.Enemy_X] = this.Mark;

            }
         
           

        } // ComparePos()

        public int [,] ScanMovableTile(string[,] myMap, int player_Y, int player_X)
        {
            int[,] movablePos = new int[4, 2];
            int[,] bestPos = new int[1, 2];
            int dir = 1;
            if (myMap[Enemy_Y + dir, Enemy_X] == " ")
            {
                movablePos[0, 0] = Enemy_Y + dir;
                movablePos[0, 1] = Enemy_X;
            }
            else if (myMap[Enemy_Y - dir, Enemy_X] == " ")
            {
                movablePos[1, 0] = Enemy_Y - dir;
                movablePos[1, 1] = Enemy_X;
            }
            else if (myMap[Enemy_Y , Enemy_X + dir] == " ")
            {
                movablePos[2, 0] = Enemy_Y;
                movablePos[2, 1] = Enemy_X + dir;
            }
            else if (myMap[Enemy_Y , Enemy_X - dir] == " ")
            {
                movablePos[3, 0] = Enemy_Y;
                movablePos[3, 1] = Enemy_X - dir;
            }

            int sumPos = player_Y + player_X;
            int bestNum = 0;          

            for (int i = 0; i < movablePos.GetLength(0); i++)
            {
                int tempnum = 0;
                for (int j = 0; j < movablePos.GetLength(1); j++)
                {
                    tempnum += movablePos[i, j];
                    

                }

            }



            return movablePos;
            
        }

    }
}
