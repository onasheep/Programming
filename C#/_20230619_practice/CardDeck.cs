using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619_practice
{
    public class CardDeck
    {

        public void InitCardDeck(List<CardInfo> cardDeck)
        {


            for(int markIndex = 0; markIndex < 4; markIndex++)
            {
                for (int NumIndex = 2; NumIndex <= 14; NumIndex++)
                {

                    CardInfo card = new CardInfo();
                    card.Init(markIndex, NumIndex);
                    cardDeck.Add(card);

                }
            }
            

        }

    }
}
