using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230617_weekend_hw
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 게임 실행
            GameManager gm = new GameManager();
            GamePlay gamePlay = new GamePlay();

            gamePlay.Play(gm);
        }
    }
}
