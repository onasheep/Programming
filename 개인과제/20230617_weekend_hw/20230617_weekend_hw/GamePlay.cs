using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230617_weekend_hw
{
    public class GamePlay
    {

        // 카드게임 체크용
        CardGame cg = new CardGame();
        // 

        private int curPlayCol = default;
        private int curPlayRow = default;

        private int movePlayCol = default;
        private int movePlayRow = default;




        public void Play(GameManager gm)
        {
            gm.InitMap(out curPlayCol, out curPlayRow);
            gm.Draw_ConsoleMap();
      

            while (true)
            {
                
                movePlayCol = curPlayCol;
                movePlayRow = curPlayRow;
                
                MovePlayer(ref curPlayCol, ref curPlayRow);


                // 카드게임 좌표로 이동하면 카드게임 실행
                if (CardGame.cgPosCol == curPlayCol && CardGame.cgPosRow == curPlayRow)
                {
                    
                    cg.Play();
                    gm.InitMap(out curPlayCol, out curPlayRow);

                }

                Console.Clear();


                gm.Draw_ConsoleMap();





            }




        }       // Play()

        public void MovePlayer(ref int curPlayCol, ref int curPlayRow)
        {
            // 움직임 방향
            
            int dir = 1;
            ConsoleKey input = GameManager.InputKey();

            switch (input)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    movePlayRow += dir;
                    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    movePlayRow -= dir;
                    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    movePlayCol -= dir;
                    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    movePlayCol += dir;
                    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
                    break;

            }       // MovePlayer()

            // LEGACY : if문을 활용해서 키 입력을 받았었지만, ConsoleKey가 enum 타입이므로 switch를 사용한다.

            //if (input == ConsoleKey.RightArrow || input == ConsoleKey.D)
            //{
            //    movePlayRow += dir;
            //    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
            //}
            //else if (input == ConsoleKey.LeftArrow || input == ConsoleKey.A)
            //{
            //    movePlayRow -= dir;
            //    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
            //}
            //else if (input == ConsoleKey.UpArrow || input == ConsoleKey.W)
            //{
            //    movePlayCol -= dir;
            //    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
            //}
            //else if (input == ConsoleKey.DownArrow || input == ConsoleKey.S)
            //{
            //    movePlayCol += dir;
            //    SwapPos(ref curPlayCol, ref curPlayRow, ref movePlayCol, ref movePlayRow);
            //}

        }

        public void SwapPos(ref int curPlayCol, ref int curPlayRow, ref int movePlayCol, ref int movePlayRow)
        {

            int tempCol = default;
            int tempRow = default;
            char temp = default;

            tempCol = movePlayCol;
            tempRow = movePlayRow;
            temp = GameManager.map[movePlayCol, movePlayRow];

            GameManager.map[movePlayCol, movePlayRow] = GameManager.map[curPlayCol, curPlayRow];
            GameManager.map[curPlayCol, curPlayRow] = temp;

            curPlayCol = tempCol;
            curPlayRow = tempRow;
            

        }
        


    }
}
