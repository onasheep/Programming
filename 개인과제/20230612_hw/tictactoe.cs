using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _20230612_hw
{
    public class Tictactoe
    {
        private char[] nums = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private bool isMyTurn = false;


        public void Start()
        {
            Console.WriteLine(" 게임을 시작하려면 아무 키나 누르세요.");
            Console.ReadKey(true);
            Console.Clear();

            DrawLine();
            Console.WriteLine();
            Console.WriteLine("1부터 9까지의 수 중 하나를 선택하면 해당 숫자를 마킹합니다.");
            Console.WriteLine("플레이어의 마커는 O 이고 컴퓨터의 마커는 X 입니다.");
            Console.WriteLine("컴퓨터가 먼저 시작합니다.");
            Console.WriteLine("화면을 넘기시려면 아무 키나 누르세요");
            Console.ReadKey(true);
        }
        

        public void DrawLine()
        {
            Console.WriteLine("  {0}  {1}  {2}", nums[0], nums[1], nums[2]);
            Console.WriteLine();
            Console.WriteLine("  {0}  {1}  {2}", nums[3], nums[4], nums[5]);
            Console.WriteLine();
            Console.WriteLine("  {0}  {1}  {2}", nums[6], nums[7], nums[8]);
        }


        public void ComChooseNum()
        {

            Random rand = new Random();
            int randNum = rand.Next(48, 58);
            for (int i = 0; i < nums.Length; i++)
            {
                if (randNum == nums[i])
                {
                    nums[i] = 'X';
                    isMyTurn = true;
                }
            }

        }

        public void PlayerChooseNum()
        {

            string s = Console.ReadLine();
            char selectedNum = Convert.ToChar(s);

            if (selectedNum >= 49 && selectedNum <= 57)     // 아스키 코드 1부터 9까지
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (selectedNum == nums[i] )
                    {
                        nums[i] = 'O';
                        isMyTurn = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 1부터 9까지 수 중 입력해주세요.");
                Console.WriteLine();
            }


        }


        public void WinLogPrint(string str)
        {
            Console.WriteLine(str);
        }

        public void Play()
        {
            Start();

            while (true)
            {
                if(isMyTurn)
                {
                    Console.WriteLine("숫자를 고르세요.");
                    Console.WriteLine();

                    PlayerChooseNum();
                }
                else
                {
                    ComChooseNum();
                }


                Console.Clear();

                DrawLine();
                

            }
        }
    }
}
