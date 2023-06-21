using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230621
{
    // 무언가 클릭이 가능한 오브젝트를 만들고 싶을 떄 사용할 클래스 임
    public  abstract class  Clickable
    {
        bool isClickOk = false;

        public  virtual void ClickThisObject(bool isClick_)
        {
            isClickOk = isClick_;

            Console.WriteLine("당신은 이 오브젝트를 클릭했습니다.");
        }

    }
}
