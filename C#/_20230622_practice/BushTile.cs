using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230622_practice
{
    public class BushTile
    {
        public string Tile {get; private set;}
        public int RandomNum { get; private set; }

        public int MaxPer { get; private set; }
        public int BushY { get; set; }
        public int BushX { get; set; }

        public void Init(int bushY_, int bushX_)
        {
            this.Tile = "∧";
            this.MaxPer = 20;
            this.BushY = bushY_;
            this.BushX = bushX_;
        }

        public int Check_Encount()
        {
            Random rand = new Random();
            int encountPer = rand.Next(0, 100);


            return encountPer;
        }

    }
}
