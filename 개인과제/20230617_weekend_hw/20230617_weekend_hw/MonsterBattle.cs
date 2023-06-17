using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230617_weekend_hw
{
    public class MonsterBattle
    {
        public static int mbPosCol = 5;
        public static int mbPosRow = 20;


        private string monsterName;
        private int monsterHp;
        private int monsterAtk;
        private int monsterDef;


        private string playerName;
        private int playerHp;
        private int playerAtk;
        private int playerDef;

        public void Init()
        {
            monsterName = "훈련용 허수아비";
            monsterHp = 100;
            monsterAtk = 20;
            monsterDef = 5;

            playerName = "플레이어";
            playerHp = 200;
            playerAtk = 15;
            playerDef = 10;
        }

        public void Play()
        {
            Init();

            while(true)
            {
                DrawMenu();


            }
    



        }

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
