using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619_practice
{
    public class CardInfo
    {


        private char[] cardMark = { '♠', '◆', '♥',  '♣' };
        public char mark;
        public int cardNum = default;

        public void Init( int markIndex,int cardNum)
        {
            this.cardNum = cardNum;
            this.mark = cardMark[markIndex];
        }
    }
}
