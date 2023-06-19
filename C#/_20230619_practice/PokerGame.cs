using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20230619_practice
{
    public class PokerGame
    {

        int myMoney;
        int myBet;
        Queue<int> q;
        // List 순서 변경 필요 X
        List<CardInfo> cardDeck;
        // List 순서 변경 필요 o        
        CardInfo[] myDeck;
        List<CardInfo> comDeck;

        public void Play()
        {
            CardDeck deck = new CardDeck();
            
            cardDeck = new List<CardInfo>();
            // 배열로 생성(순서가 중요)
            myDeck = new CardInfo[5];
            comDeck = new List<CardInfo>();

            deck.InitCardDeck(cardDeck);

            // 돈 초기화
            myMoney = 1000;
            myBet = default;

          

            Get_ComCard();
            Get_PlayerCard(5);
            
            
          


            //List<CardInfo> sortList = comDeck.OrderBy(x => x.mark).ToList();
            //sortList = comDeck.OrderBy(x => x.cardNum).ToList(); 




            //foreach (CardInfo card in sortList.Distinct().ToList())
            //{
            //    Console.WriteLine("{0}{1}", card.mark, card.cardNum);
            //}

            ////private char[] cardMark = { '♠', '♥', '♣', '◆' };

            while (true)
            {
                DrawUI();
        

                PrintCard(comDeck, myDeck);

                Console.WriteLine("===============");

          
                Bet();

                Change_PlayerCard();
           
                Console.Clear();
            }


          
        }


     

        public void Get_ComCard()
        {
            Random rand = new Random();


            for (int i = 0; i < 7;i++)
            {
                int randCardIndex = rand.Next(0, cardDeck.Count - 1);

                comDeck.Add(cardDeck[randCardIndex]);
                // 카드덱에서 뽑힌 카드 지우기
                cardDeck.Remove(cardDeck[randCardIndex]);
            }

        }

        public void Get_PlayerCard(int count)
        {
            Random rand = new Random();


            for (int i = 0; i < count; i++)
            {

                int randCardIndex = rand.Next(0, cardDeck.Count - 1);

                myDeck[i] = cardDeck[randCardIndex];
                // 카드덱에서 뽑힌 카드 지우기

                cardDeck.Remove(cardDeck[randCardIndex]);
            }

        }

        public void Change_PlayerCard()
        {
            Console.WriteLine("변경하고 싶은 카드의 순서를 입력하세요");

            // 큐 생성

            q = new Queue<int>();

            // 바꾸고 싶은 카드 숫자 입력
            while (q.Count < 2)
            {
                string s = Console.ReadLine();
                int.TryParse(s, out int num);
                if (num <= myDeck.Length && num > 0)
                {
                    q.Enqueue(num);                    
                }
            }

            // 큐에 입력받은 숫자를 넣고 입력받은 숫자대로, 새로 덱에서 카드를 뽑아서 
            // 플레이어 패에 넣고 덱에서 삭제해줌
            while (q.Count > 0)
            {

                Random rand = new Random();
                int randCardIndex = rand.Next(0, cardDeck.Count - 1);

                Console.WriteLine("{0}{1}을 내고 {2}{3}를 받았습니다.", myDeck[q.First() - 1].mark, myDeck[q.First() - 1].cardNum,
                      cardDeck[randCardIndex].mark, cardDeck[randCardIndex].cardNum);

                cardDeck.Add(myDeck[q.First() - 1]);           
                myDeck[q.First() - 1] = cardDeck[randCardIndex];

               
                Thread.Sleep(1500);

                cardDeck.Remove(cardDeck[randCardIndex]);


                
                q.Dequeue();

            }
            q.Clear();
        }
        public void Bet()
        {
            while (true)
            {
                Console.WriteLine("배팅할 금액을 입력하세요 (1 ~ {0})", myMoney);
                int.TryParse(Console.ReadLine(), out int bet);
                if (bet > 0 && bet < myMoney)
                {
                    myBet = bet;
                    myMoney -= myBet;
                    break;
                }
                Console.WriteLine("잘못된 입력입니다.");
            }


        }
        public void DrawUI()
        {
            Console.WriteLine("소지금 : {0}", myMoney);
            Console.WriteLine("====================");
        }

        public void PrintCard(List<CardInfo> comDeck, CardInfo[] myDeck)
        {
            Console.WriteLine("[컴퓨터]");
            for (int i = 0; i < comDeck.Count; i++)
            {
                Console.WriteLine("{0}{1}     ", comDeck[i].mark, comDeck[i].cardNum);
            }

            Console.WriteLine("=======================================");
            Console.WriteLine("[플레이어]");
            for (int i = 0; i < myDeck.Length; i++)
            {
                Console.WriteLine("{0}{1}     ", myDeck[i].mark, myDeck[i].cardNum);

            }

        }


      
    }
}
