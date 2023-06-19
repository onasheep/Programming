using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _20230617_weekend_hw
{
    public class MonsterBattle
    {
        public static int mbPosCol = 5;
        public static int mbPosRow = 20;


        private string monsterName;
        private int monsterHp;
        private int monsterAtk;


        private string playerName;
        private int playerHp;
        private int playerAtk;
        private int playerHeal;

        public void Init()
        {
            monsterName = "훈련용 골렘";
            monsterHp = 100;
            monsterAtk = 45;

            playerName = "플레이어";
            playerHp = 200;
            playerAtk = 15;
            playerHeal = 20;
        }

        public  void Play()
        {
            Init();


            DrawMenu();


            Console.WriteLine("훈련용 골렘과 전투를 시작합니다.");


            while (true)
            {

                DrawField();

                AutoBattle();

                Console.Clear();




                if (playerHp <= 0)
                {
                    Console.WriteLine("플레이어가 쓰러졌습니다.");
                    Console.WriteLine("게임을 종료합니다.");
                    Thread.Sleep(1000);
                    break;
                }

                if (monsterHp <= 0)
                {
                    Console.WriteLine("몬스터가 쓰러졌습니다.");
                    Console.WriteLine("게임을 종료합니다.");
                    Thread.Sleep(1000);
                    break;
                    
                }


            }



        }       // Play()



        public void DrawField()
        {
            Console.WriteLine("──────────────────────────────────────────────────────────────────");

            Console.WriteLine("\t\t\t\t 이름: {0}", monsterName);
            Console.WriteLine("\t\t\t\t 체력: {0}", monsterHp);
            Console.WriteLine("\t\t\t\t 공격력: {0}", monsterAtk);

            Console.WriteLine("이름: {0}", playerName);
            Console.WriteLine("체력: {0}", playerHp);
            Console.WriteLine("공격력: {0}", playerAtk);

            Console.WriteLine("──────────────────────────────────────────────────────────────────");

        }       // DrawField()


        public void AutoBattle()
        {

            Thread.Sleep(1000);

            Console.WriteLine("===================================================================");

            Random rand = new Random();

            int turn = rand.Next(1, 3);

            switch (turn)
            {
                // 플레이어 턴
                case 1:
                    int playerChance = rand.Next(1, 11);
                    if(playerChance > 4 )
                    {
                        monsterHp -= playerAtk;
                        Console.WriteLine("{0}가 공격했습니다. {1}에게 {2}의 데미지를 입혔습니다.", playerName,monsterName,playerAtk);
                    }
                    else
                    {
                        playerHp += playerHeal;
                        Console.WriteLine("{0}가 회복했습니다. {1}의 체력을 회복 했습니다.", playerName,playerHeal);                       
                    }
                    Console.WriteLine("===================================================================");
                    Thread.Sleep(2000);
                    break;
                // 몬스터 턴
                case 2:
                    int monsterChance = rand.Next(1, 11);
                    if( monsterChance > 4)
                    {
                        playerHp -= monsterAtk;
                        Console.WriteLine("{0}이 공격했습니다. {1}에게 {2}의 데미지를 입혔습니다.", monsterName,playerName,monsterAtk);
                    }
                    else
                    {
                        Console.WriteLine("{0}이 아무런 행동도 하지 않습니다.", monsterName);
                    }
                    Console.WriteLine("===================================================================");
                    Thread.Sleep(2000);
                    break;
            }





        }       // AutoBattle()



        public void DrawMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("훈련소에 오신 것을 환영합니다.");
                Console.WriteLine("게임을 시작하시려면 B키를 눌러주세요.");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                if (input.Key != ConsoleKey.B)
                {
                    continue;
                }
                return;
            }
        }




    }
}
