using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace _20230622_practice
{
    public class Npc
    {
        public string NpcMark { get; private set; }
        public int NpcY { get; private set; }
        public int NpcX { get; private set; }

        public int NpcQuestNum { get; private set; }

        public string[,] Dialog {get; private set;}

        public int DialogIndex { get; private set; }

        public string QuestName { get; private set; }
        public void Init()
        {
            this.NpcY = 2;
            this.NpcX = 16;
            this.NpcMark = "♥";
            this.NpcQuestNum = 5;
            // 대화내용 배열
            Dialog = new string[2, 2]; 

            // 대화 내용
            this.Dialog[0, 0] = "수풀에 들어가서 토끼를 5 마리 잡아주세요.";
            this.Dialog[0, 1] = "대화를 종료하려면 아무키나 누르세요.";
            this.Dialog[1, 0] = "토끼를 다 잡아 오셨군요.";
            this.Dialog[1, 1] = "이제 가세요.";

            this.QuestName = "토끼 잡기";
            this.DialogIndex = 0;
        }

        public void PrintDialog1()
        {
            Console.SetCursorPosition(25, 2);

            Console.WriteLine(Dialog[0, 0]);

            Console.SetCursorPosition(25, 5);

            Console.Write(Dialog[0, 1]);
            Console.ReadKey();
            Console.Clear();
            DialogIndex += 1;


        }
        public void PrintDiaglog2()
        {
            Console.SetCursorPosition(25, 2);

            Console.WriteLine(Dialog[1, 0]);
            Console.SetCursorPosition(25, 5);

            Console.WriteLine(Dialog[1, 1]);
            Console.SetCursorPosition(25, 5);

            Console.WriteLine("퀘스트를 클리어 하셨습니다.");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
