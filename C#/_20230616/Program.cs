using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230616
{
    public class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            GamePlay gamePlay = new GamePlay();
            gamePlay.Play(field);
        }
    }
}
