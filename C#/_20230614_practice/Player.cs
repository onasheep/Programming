using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230614_practice
{
    public class Player
    {
        public List<Item> inventory;
        public int coin;


        public void InitPlayer(List<Item> inventory, int coin)
        {
            this.inventory = inventory;
            this.coin = coin;
        }
    }
}
