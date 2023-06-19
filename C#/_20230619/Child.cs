using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230619
{
    public class Child : Parent
    {
        string strChild = default;

        public override void PrintInfos()
        {
            //base.PrintInfos();
            number = 10;
            strValue = "This is Child";
            strChild = "Sentences of child added";

            Console.WriteLine("Child class -> number: {0},str value: {1}, strChild: {2}", this.number, this.strValue, this.strChild);

        }
    }
}
