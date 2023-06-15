using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614_practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            Shop itemShop = new Shop();
            GamePlay gamePlay = new GamePlay();
            List<Item> itemList = new List<Item>();
            Player player = new Player();
            List<Item> inventory = new List<Item>();

            gamePlay.Play(itemShop, itemList, inventory, player);

        }
    }
}
