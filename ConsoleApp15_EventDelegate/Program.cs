using System;

namespace ConsoleApp15_EventDelegate
{
    // 이벤트 : 객체에 일어난 사건 알리기

    // 대리자 선언
    delegate void EventHandler(string message);

    // 클래스 생성
    class MyNotifier
    {
        // event 한정자로 수식해서 선언
        public event EventHandler SomethingHappened;

        // 이벤트 작성
        public void DoSomething(int number)
        {
            int temp = number % 10;

            if (temp != 0 && temp % 3 == 0)
            {
                SomethingHappened(string.Format("{0} : 짝", number));
            }
        }
    }



    class Program
    {
        // 이벤트 핸들러 작성(대리자의 형식과 동일 : 매개변수)
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }


        static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += MyHandler;

            for (int i = 0; i < 30; i++)
            {
                notifier.DoSomething(i);
            }



        }
    }
}
