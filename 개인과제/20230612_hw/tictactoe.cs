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
        private bool isMyTurn = false;
        private bool isPlay = true;
        private bool isWin = true;
        Dictionary<int, char> map = new Dictionary<int, char>();


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

        // map 초기화
        public void Init()
        {
            for(int i = 1; i <= 9; i ++)
            {
                map.Add(i, ' ');
            }
        }
  
        // 그림 그리기
        public void DrawLine()
        {
            Console.WriteLine("  [{0}]  [{1}]  [{2}]", map[1], map[2], map[3]);
            Console.WriteLine();
            Console.WriteLine("  [{0}]  [{1}]  [{2}]", map[4], map[5], map[6]);
            Console.WriteLine();
            Console.WriteLine("  [{0}]  [{1}]  [{2}]", map[7], map[8], map[9]);


            
        }

        // 컴퓨터 번호 고르기
        public void ComChooseNum()
        {

            Random rand = new Random();
            int randNum = rand.Next(0, 10);
 
            // key 값 이외의 randNum 들어왔을때 예외처리
            if(map.ContainsKey(randNum))
            {
                if (map[randNum] == ' ')
                {
                    Console.Clear();
                    map[randNum] = 'X';
                    isMyTurn = true;
                }
            }

        }


        

        // 플레이어 번호 고르기
        public void PlayerChooseNum()
        {

            int selectedNum = 0;
            string s = Console.ReadLine();
            if (int.TryParse(s, out selectedNum)) // 숫자 두개 이상 입력 방지 예외 처리
            {
                if (selectedNum >= 1 && selectedNum <= 9)     
                {

                    if (map[selectedNum] == ' ' && map.ContainsKey(selectedNum))
                    {
                        Console.Clear();
                        map[selectedNum] = 'O';
                        isMyTurn = false;
                    }

                }
             
            }



        }       

        // 모든 경우의 수를 비교하여 승패 확인
        public void WinCheck()
        {
            if ((map[1]  == 'O' &&  map[2] == 'O' && map[3] == 'O') || (map[1] == 'O' && map[5] == 'O' && map[9] == 'O')
               ||(map[1] == 'O' && map[4] == 'O' && map[7] == 'O') || (map[2] == 'O' && map[5] == 'O' && map[8] == 'O')
               ||(map[4] == 'O' && map[5] == 'O' && map[6] == 'O') || (map[3] == 'O' && map[5] == 'O' && map[7] == 'O')
               ||(map[3] == 'O' && map[6] == 'O' && map[9] == 'O') || (map[7] == 'O' && map[8] == 'O' && map[9] == 'O'))
            {
                isPlay = false;
                isWin = true;
            }
            if ((map[1] == 'X' && map[2] == 'X' && map[3] == 'X') || (map[1] == 'X' && map[5] == 'X' && map[9] == 'X')
               || (map[1] == 'X' && map[4] == 'X' && map[7] == 'X') || (map[2] == 'X' && map[5] == 'X' && map[8] == 'X')
               || (map[4] == 'X' && map[5] == 'X' && map[6] == 'X') || (map[3] == 'X' && map[5] == 'X' && map[7] == 'X')
               || (map[3] == 'X' && map[6] == 'X' && map[9] == 'X') || (map[7] == 'X' && map[8] == 'X' && map[9] == 'X'))
            {
                isPlay = false;
                isWin = false;
            }


        }


        public void Play()
        {
            Init();
            Start();


            while (true)
            {
                if (!isPlay)
                {
                    break;
                }
                if (isMyTurn)
                {
                    Console.WriteLine();
                    Console.WriteLine("숫자를 고르세요.(1~9)");
                    Console.WriteLine();

                    PlayerChooseNum();

                }
                else
                {
                    ComChooseNum();
                }

                WinCheck();

                Console.Clear();
               
                DrawLine();
                
               
            }

            // 변경된 isWin 값에 따라 승리 메세지 출력
            if (isWin)
            {
                Console.WriteLine();
                Console.WriteLine("플레이어가 이겼습니다.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("컴퓨터가 이겼습니다.");
            }
        }
    }
}
