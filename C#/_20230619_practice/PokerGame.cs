using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        // 카드 덱에 넣기 현하게 리스트
        List<CardInfo> deck;
        // 손패의 수는 고정 되어 있으므로 배열    
        CardInfo[] myHand;
        CardInfo[] comHand;

        public void Play()
        {
            CardDeck cardDeck = new CardDeck();   
            
            this.deck = new List<CardInfo>();


            // 배열로 생성(순서가 중요)
            myHand = new CardInfo[5];

            // 배열로 생성
            comHand = new CardInfo[7];
        



            cardDeck.InitCardDeck(this.deck);

            // 돈 초기화
            myMoney = 1000;
            myBet = default;


            Get_RandCard(comHand,7);
            Get_RandCard(myHand,5);





            while (true)
            {
                DrawUI();
        

                PrintCard(comHand,myHand);

                Console.WriteLine("===============");

          
                Bet();

                Change_PlayerCard();



                //comHand[0].num = 2;
                //comHand[1].num = 2;
                //comHand[2].num = 2;
                //comHand[3].num = 2;
                //comHand[4].num = 5;
                //comHand[5].num = 1;
                //comHand[6].num = 13;



                Sort(comHand);

                Sort(myHand);





                while (true)

                {
                    if (isFourCard(comHand))
                        break;
                    if (isStraight(comHand))
                        break;
                    if (isTriple(comHand))
                        break;
                    if (isTwoFair(comHand))
                        break;
                    if (isOneFair(comHand))
                        break;
                    
                }







                //Console.Clear();
            }



        }


        
        // LEGACY : 리스트 찾던 코드 
        //public void Get_ComCard()
        //{
        //    Random rand = new Random();


        //    for (int i = 0; i < 7;i++)
        //    {
        //        int randCardIndex = rand.Next(0, deck.Count - 1);

        //        comHand.Add(deck[randCardIndex]);
        //        // 카드덱에서 뽑힌 카드 지우기
        //        deck.Remove(deck[randCardIndex]);
        //    }

        //}


        // 랜덤 카드 찾기
        public void Get_RandCard(CardInfo[] hand,int count)
        {
            Random rand = new Random();


            for (int i = 0; i < count; i++)
            {

                int randCardIndex = rand.Next(0, deck.Count - 1);

                hand[i] = deck[randCardIndex];
                // 카드덱에서 뽑힌 카드 지우기

                deck.Remove(deck[randCardIndex]);
            }

        }

        // 플레이어 카드 변경

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
                if (num <= myHand.Length && num > 0)
                {
                    q.Enqueue(num);                    
                }
            }

            // 큐에 입력받은 숫자를 넣고 입력받은 숫자대로, 새로 덱에서 카드를 뽑아서 
            // 플레이어 패에 넣고 덱에서 삭제해줌
            while (q.Count > 0)
            {

                Random rand = new Random();
                int randCardIndex = rand.Next(0, deck.Count - 1);


                Console.WriteLine("{0} 번째 카드를 바꿨습니다.",q.First());

                deck.Add(myHand[q.First() - 1]);           
                myHand[q.First() - 1] = deck[randCardIndex];

               
                Thread.Sleep(1500);

                deck.Remove(deck[randCardIndex]);


                
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

        public void PrintCard(CardInfo[] comHand, CardInfo[] myHand)
        {
            string printMark = default;

            Console.WriteLine("[컴퓨터]");
            for (int i = 0; i < comHand.Length; i++)
            {
                switch(comHand[i].mark)
                {
                    case 0:
                        printMark = "♣";
                        break;
                    case 1:
                        printMark = "♥";
                        break;
                    case 2:
                        printMark = "◆";
                        break;
                    case 3:
                        printMark = "♠";
                        break;
                }
                Console.WriteLine("{0}{1}     ", printMark, comHand[i].num);
            }

            Console.WriteLine("=======================================");
            Console.WriteLine("[플레이어]");
            for (int i = 0; i < myHand.Length; i++)
            {
                switch (comHand[i].mark)
                {
                    case 0:
                        printMark = "♣";
                        break;
                    case 1:
                        printMark = "♥";
                        break;
                    case 2:
                        printMark = "◆";
                        break;
                    case 3:
                        printMark = "♠";
                        break;
                }
                Console.WriteLine("{0}{1}     ", printMark, myHand[i].num);

            }

        }




        public void Sort(CardInfo[] hand)
        {

            CardInfo card;


            for (int i = 0; i < hand.Length; i++)
            {
                for (int j = i; j < hand.Length; j++)
                {
                    if (hand[i].num > hand[j].num)
                    {
                        card = hand[i];
                        hand[i] = hand[j];
                        hand[j] = card;
                    }
                }
            }

        }



        public bool isOneFair(CardInfo[] hand)
        {   

            int lastIndex = hand.Length - 1;
            int firstIndex = lastIndex - 1;


            while (firstIndex >= 0)
            {

                if (hand[lastIndex].num == hand[firstIndex].num)
                {
                    Console.WriteLine("[원 페어입니다.]");

                    return true;
                }

                lastIndex -= 1;
                firstIndex -= 1;
            }
            return false;



        }

        public bool isTwoFair(CardInfo[] hand)
        {

            int lastIndex = hand.Length - 1;
            int firstIndex = lastIndex - 1;
            int count = default;

            while (firstIndex >= 0)
            {

                if (hand[lastIndex].num == hand[firstIndex].num)
                {
                    count += 1;
                    
                    if (count > 1)
                    {
                        Console.WriteLine("[투 페어입니다.]");
                        return true;
                    }
                }
                lastIndex -= 1;
                firstIndex -= 1;
            }
            return false;
            

        }

        public bool isTriple(CardInfo[] hand)
        {


            int lastIndex = hand.Length - 1;
            int firstIndex = lastIndex - 2;

            while (firstIndex >= 0)
            {
                if (hand[lastIndex].num == hand[firstIndex].num)
                {
                    Console.WriteLine("[트리플 입니다.]");
                    return true;

                }
                lastIndex -= 1;
                firstIndex -= 1;
            }
            return false;
         
        }

        public bool isStraight(CardInfo[] hand)
        {
            int lastIndex = hand.Length - 1;
            int firstIndex = lastIndex - 4;



            while (firstIndex >= 0)
            {
                int last = lastIndex;
                int first = last - 1;
                int straightCount = 0;

                while (first >= firstIndex)
                {

                    if (hand[last].num - 1 == hand[first].num && hand[last].num != hand[first].num)
                    {
                        Console.WriteLine("{0}",straightCount);

                        Console.WriteLine("{0},{1}", hand[last].num, hand[first].num);
                        straightCount += 1;
                       
                        if (straightCount == 4)
                        {
                            Console.WriteLine("[스트레이트 입니다.]");
                            return true;
                        }
                    }
                    last -= 1;
                    first -= 1;
                }

                lastIndex -= 1;
                firstIndex -= 1;
            }
            return false;
        }

        public bool isFourCard(CardInfo[] hand)
        {
            int lastIndex = hand.Length - 1;
            int firstIndex = lastIndex - 3;

            while (firstIndex >= 0)
            {
                if (hand[lastIndex].num == hand[firstIndex].num)
                {
                    Console.WriteLine("[포카드 입니다.]");
                    return true;

                }
                lastIndex -= 1;
                firstIndex -= 1;
            }
            return false;
        }

        public bool isFlush(CardInfo[] hand)
        {
            CardInfo[] sortedHand = hand;
            sortedHand.OrderBy((x) => x.mark);

            for (int i = hand.Length - 1; i >= 0; i--)
            {
                
            }
            

            return false;
        }


        public int ReturnKey(List<CardInfo> Deck, Dictionary<int,char> cardMark)
        {
            



            return 0;
        }
    }
}
