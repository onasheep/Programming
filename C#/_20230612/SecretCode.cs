using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230612
{
    public class SecretCode
    {
        int maxNum = 91;
        int minNum = 64;
        int maxScore = 20;
        string input;


      
        public void Play()
        {

            Console.WriteLine("게임을 시작하려면 아무 키나 누르세요.");
            Console.ReadKey(true);

            Random rand = new Random();
            int pickRanN = rand.Next(minNum, maxNum);

            Console.WriteLine("컴퓨터가 비밀 코드를 선택하였습니다.");
            Console.WriteLine("A ~ Z 사이의 영문 대문자를 입력하세요");
            Console.WriteLine("20번의 기회가 주어집니다.");


            while (true)
            {

                input = Console.ReadLine();
                char alphabet= input[0];
                if ((int)alphabet > minNum && (int)alphabet < maxNum && input.Length <= 1)
                {
                    if (pickRanN > (int)alphabet)
                    {
                        Console.WriteLine("입력한 값보다 뒤에 있습니다.");
                        maxScore -= 1;
                        Console.WriteLine("남은 점수 : {0}", maxScore);
                    }
                    else if (pickRanN < (int)alphabet)
                    {
                        Console.WriteLine("입력한 값보다 앞에 있습니다.");
                        maxScore -= 1;
                        Console.WriteLine("남은 점수 : {0}", maxScore);
                    }
                    else if (pickRanN == (int)alphabet)
                    {
                        Console.WriteLine("정답을 맞추셨습니다.");
                        Console.WriteLine("게임을 종료합니다.");
                        break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("입력 범위에서 벗어났습니다. 다시 입력하세요.");
                }

                if (maxScore <= 0)
                {
                    Console.WriteLine("점수가 0이 되어습니다.");
                    Console.WriteLine("게임을 종료합니다.");
                    break;
                }
                Console.WriteLine();

            }

            Console.WriteLine("{0}점을 획득하셨습니다.",maxScore);

        }
    }
}
