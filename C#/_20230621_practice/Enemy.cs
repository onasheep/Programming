﻿using System;
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
            #region LEGACY :
            Random rand = new Random();

            int yDiff = player_Y - this.Enemy_Y;
            int xDiff = player_X - this.Enemy_X;
            if (yDiff > 0)
            {
                if (myMap[this.Enemy_Y + 1, this.Enemy_X] != "▣")
                {
                    myMap[this.Enemy_Y, this.Enemy_X] = "□";
                    this.Enemy_Y += 1;
                }
                else if (myMap[this.Enemy_Y + 1, this.Enemy_X] == "▣")
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
                else if (myMap[this.Enemy_Y - 1, this.Enemy_X] == "◎")
                {

                }
                myMap[this.Enemy_Y, this.Enemy_X] = this.Mark;

            }
            else if (yDiff < 0)
            {
                if (myMap[this.Enemy_Y - 1, this.Enemy_X] != "▣")
                {
                    myMap[this.Enemy_Y, this.Enemy_X] = "□";

                    this.Enemy_Y -= 1;
                }
                else if (myMap[this.Enemy_Y - 1, this.Enemy_X] == "▣")
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
                else if (myMap[this.Enemy_Y - 1, this.Enemy_X] == "◎")
                {

                }
                myMap[this.Enemy_Y, this.Enemy_X] = this.Mark;

            }
            else if (xDiff > 0)
            {
                if (myMap[this.Enemy_Y, this.Enemy_X + 1] != "▣")
                {

                    myMap[this.Enemy_Y, this.Enemy_X] = "□";
                    this.Enemy_X += 1;
                }
                else if (myMap[this.Enemy_Y, this.Enemy_X + 1] == "▣")
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
            #endregion




            // LEGACY 2:
            //ScanMovableTile(myMap, player_Y, player_X);

            //int movable_Y = ScanMovableTile(myMap, player_Y, player_X)[0, 0];
            //int movable_X = ScanMovableTile(myMap, player_Y, player_X)[0, 1];

            //myMap[this.Enemy_Y, this.Enemy_X] = "□";
            //myMap[movable_Y, movable_X] = "◎";
            //this.Enemy_Y = movable_Y;
            //this.Enemy_X = movable_X;



        } // ComparePos()

        public int [,] ScanMovableTile(string[,] myMap, int player_Y, int player_X)
        {
            List<int[,]> movableList = new List<int[,]>();
            int dir = 1;

            int[,] bestPos1 = new int[1, 2];
            int[,] bestPos2 = new int[1, 2];
            int[,] bestPos3 = new int[1, 2];
            int[,] bestPos4 = new int[1, 2];



            if (myMap[Enemy_Y + dir, this.Enemy_X] == "□")
            {

                bestPos1[0, 0] = this.Enemy_Y + dir;
                bestPos1[0, 1] = this.Enemy_X;
                movableList.Add(bestPos1);

            }
            else if (myMap[Enemy_Y - dir, this.Enemy_X] == "□")
            {

                bestPos2[0, 0] = this.Enemy_Y - dir;
                bestPos2[0, 1] = this.Enemy_X;
                movableList.Add(bestPos2);

            }
            else if (myMap[Enemy_Y, this.Enemy_X + dir] == "□")
            {

                bestPos3[0, 0] = this.Enemy_Y;
                bestPos3[0, 1] = this.Enemy_X + dir;
                movableList.Add(bestPos3);

            }
            else if (myMap[Enemy_Y, this.Enemy_X - dir] == "□")
            {

                bestPos4[0, 0] = this.Enemy_Y;
                bestPos4[0, 1] = this.Enemy_X - dir;
                movableList.Add(bestPos4);

            }

            //// movableList 수 체크
            //for (int i = 0; i < movableList.Count; i++)
            //{
            //    Console.WriteLine("{0}{1}", movableList[i][0,0], movableList[i][0, 1]);

            //}


            List<int> BestPos = new List<int>();
            int player_PosSum = player_Y + player_X;

            for (int i = 0; i < movableList.Count; i++)
            {
                int tempNum = player_PosSum;
                tempNum = player_PosSum - (movableList[i][0, 0] + movableList[i][0, 1]);

                // ???
                BestPos.Add(Math.Abs(tempNum));
            }

            //BestPos 값 체크
            //for (int i = 0; i < BestPos.Count; i++)
            //{
            //    Console.WriteLine("{0}", BestPos[i]);

            //}


            int minNum = 1000;

            for (int i = 0; i < BestPos.Count; i++)
            {
                if (BestPos[i] < minNum)
                {
                    Console.WriteLine("{0}", BestPos[i]);
                    minNum = BestPos[i];
                }
            }

            int minIndex = 0;

            for(int i = 0; i < BestPos.Count; i++)
            {
                if (BestPos[i] == minNum)
                {
                    minIndex = i;
                    break;
                }
            }

            //int bestIndex = BestPos[BestPos.Count - 1];
            
            //Console.WriteLine("{0}", maxIndex);
            
            return movableList[minIndex];
            
        }

    }
}
