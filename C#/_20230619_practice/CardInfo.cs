using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619_practice
{
    public class CardInfo
    {


        public int mark = default;
        public int num = default;

        public void Init( int markIndex,int cardNum)
        {
            this.num = cardNum;
            this.mark = markIndex;
        }
    }
}
