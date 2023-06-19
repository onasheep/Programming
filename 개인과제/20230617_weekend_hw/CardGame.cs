using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230617_weekend_hw
{
    public class CardGame
    {
        public static int cgPosCol = 10;
        public static int cgPosRow = 30;

        private string[] mark = { "♥", "♠", "♣", "◆" };

        private int[] nums = {1,2,3,4,5,6,7,8,9,10,11,12,13};

        private int money;

        private int myBet;

        private int maxCard;
        private int minCard;

        public void Init(int money, int myBet, int maxCard, int minCard)
        {
            this.money = money;
            this.myBet = myBet;
            this.maxCard = maxCard;
            this.minCard = minCard;
        }

        public void Play()
        {
            Init(1000,default,default,15);

            DrawMenu();

            while (true)
            {
                Console.Clear();
                if (money <= 0)
                {
                    Console.WriteLine("당신은 파산하셨습니다.");
                    break;
                }

                PrintMoney();

                #region 컴퓨터가 카드를 뽑고 출력
                Random rand = new Random();

                Console.WriteLine("컴퓨터가 카드를 뽑습니다.");


                int comTurn = 2;
                while (comTurn > 0)
                {
                    int markRandC = rand.Next(0, mark.Length);
                    int numRandC = rand.Next(0, nums.Length);
                    PrintCard(markRandC, numRandC);

                    if(comTurn == 2)
                    {
                        maxCard = numRandC;
                    }
                    else
                    {
                        if(maxCard > numRandC)
                        {
                            minCard = numRandC;
                        }
                        else
                        {
                            minCard = maxCard;
                            maxCard = numRandC;
                        }
                    }



                    comTurn -= 1;
                }


                



                Console.WriteLine("========================================");

                #endregion


                #region 플레이가 카드를 뽑고 출력
                myBet = Input();

                Console.WriteLine("플레이어가 카드를 뽑습니다.");

                int markRandP = rand.Next(0, mark.Length);
                int numRandP = rand.Next(0, nums.Length);
                PrintCard(markRandP, numRandP);
                
                Console.WriteLine("========================================");

                #endregion


                #region 승패 체크 및 출력
                if (numRandP >= maxCard || numRandP <= minCard)
                {
                    money -= myBet;

                    Console.WriteLine("{0}을 잃으셨습니다.", myBet);
                    Console.WriteLine("컴퓨터가 이겼습니다.");


                }
                else
                {
                    money += myBet * 2;

                    Console.WriteLine("{0}을 획득하셨습니다.", myBet * 2);
                    Console.WriteLine("플레이어가 이겼습니다.");
                }

                #endregion


                Console.WriteLine("다시 플레이 하시겠습니까? (Y, N)");
                
                ConsoleKeyInfo input = Console.ReadKey();

                switch(input.Key)
                {
                    case ConsoleKey.Y:                  
                        break;
                    case ConsoleKey.N:
                        return;
                }
              


            }
        }       // Play()

        public int Input()
        {
            int input = default;
            while(true)
            {
                Console.WriteLine("원하는 금액을 배팅하세요 (0 ~ {0})",money);
                Console.WriteLine("이기면 배팅한 금액에 두배를 얻을 수 있습니다.");
                Console.WriteLine("지면 배팅한 금액을 잃습니다.");
                string s = Console.ReadLine();
                
                int.TryParse(s, out input);
                if (input < 0 || input > money)
                {
                    Console.WriteLine("잘못된 입력이거나, 가진 돈보다 큽니다.");
                    continue;
                }

                return input;
            }
            


        }       // Input()

        public void PrintMoney()
        {
            Console.WriteLine("돈 : {0}", money);
            Console.WriteLine("========================================");

        }

        // 카드 그리기
        public void PrintCard(int markRand, int numRand)
        {
            

            Console.WriteLine(" ┌─────────┐");
                if (nums[numRand] <= 9)
                {
                    Console.WriteLine(" │[{0}][{1}]  │", mark[markRand], nums[numRand]);
                }
                else
                {
                    Console.WriteLine(" │[{0}][{1}] │", mark[markRand], nums[numRand]);

                }
                Console.WriteLine(" │         │");
                Console.WriteLine(" │         │");
                Console.WriteLine(" │         │");
                Console.WriteLine(" │         │");
                Console.WriteLine(" └─────────┘");


        }

        // 첫 화면 출력
        public void DrawMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("카드게임에 오신걸 환영합니다.");
                Console.WriteLine("게임을 시작하시려면 C키를 눌러주세요.");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                if (input.Key != ConsoleKey.C)
                {
                    continue;
                }
                return;
            }         
        }
    }
}
