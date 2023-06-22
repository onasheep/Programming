using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20230622_practice
{
    public class MonsterBattle
    {

        private string monsterName;
        private int monsterMaxHp;
        private int monsterHp;
        private int monsterAtk;
        private int monsterHeal;
        private int monsterCrit;


        private string playerName;
        private int playerHp;
        private int playerAtk;
        private int playerHeal;
        private int playerCrit;

        public bool IsPlayerWin { get; private set; }
        public bool IsMonWin { get; private set; }

        public void Init()
        {
            monsterName = "토끼";
            monsterMaxHp = 30;
            monsterHp = 30;
            monsterAtk = 5;
            monsterHeal = 20;
            monsterCrit = 10;

            playerName = "플레이어";
            playerHp = 100;
            playerAtk = 15;
            playerHeal = 0;
            playerCrit = 2;

            IsPlayerWin = false;
            IsMonWin = false;
        }

        public void Play()
        {
            Init();


            DrawMenu();


            Console.WriteLine("{0}와 전투를 시작합니다.",monsterName);

            while (true)
            {

                DrawField();

                AutoBattle();

                Console.Clear();




                if (playerHp <= 0)
                {
                    Console.WriteLine("플레이어가 쓰러졌습니다.");
                    IsMonWin = true;
                    Thread.Sleep(1000);
                    break;
                }

                if (monsterHp <= 0)
                {
                    Console.WriteLine("몬스터가 쓰러졌습니다.");
                    IsPlayerWin = true;
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

            int turn = rand.Next(1, 4);

            switch (turn)
            {
                // 플레이어 턴
                case 1:
                    int playerChance = rand.Next(1, 11);
                    if (playerChance > 4)
                    {
                        monsterHp -= playerAtk;
                        Console.WriteLine("{0}가 공격했습니다. {1}에게 {2}의 데미지를 입혔습니다.", playerName, monsterName, playerAtk);
                    }
                    else
                    {
                        monsterHp -= playerAtk * playerCrit;
                        Console.WriteLine("크리티컬!");
                        Console.WriteLine("{0}가 공격했습니다. {1}에게 {2}의 데미지를 입혔습니다.", playerName,monsterName, playerAtk * playerCrit);
                    }
                    Console.WriteLine("===================================================================");
                    Thread.Sleep(1100);
                    break;
                // 몬스터 턴
                case 2:
                case 3:
                    int monsterChance = rand.Next(1, 11);
                    if (monsterChance > 3)
                    {
                        playerHp -= monsterAtk;
                        Console.WriteLine("{0}가 공격했습니다. {1}에게 {2}의 데미지를 입혔습니다.", monsterName, playerName, monsterAtk);
                    }
                    else if(monsterChance > 2 && monsterChance <= 3)
                    {
                        monsterHp += monsterHeal;
                        if (monsterHp >= monsterMaxHp)
                        {
                            monsterHp = monsterMaxHp;
                        }
                       
                        Console.WriteLine("{0}가 당근을 먹습니다. {0}가 {1}의 체력을 회복합니다", monsterName, monsterHeal);

                    }
                    else
                    {
                        playerHp -= monsterAtk * monsterCrit;
                        Console.WriteLine("크리티컬!");
                        Console.WriteLine("{0}가 공격했습니다. {1}에게 {2}의 데미지를 입혔습니다.", monsterName, playerName, monsterAtk * monsterCrit);

                    }
                    Console.WriteLine("===================================================================");
                    Thread.Sleep(1100);
                    break;
            }





        }       // AutoBattle()



        public void DrawMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("몬스터를 만났습니다.");
                Console.WriteLine("싸우려면 B키를 누르세요..");
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
