
using System;

namespace ConsoleApp18_Lambda_Action
{
    // Action 대리자
    // Func 대리자와 유사
    // 반환 형식이 없음
    // Action 대리자도 Func 대리자처럼 17개 버전이 선언되어 있다.
    class Program
    {
        static void Main(string[] args)
        {
            Action act1 = () => Console.WriteLine("Action()");

            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;
            act2(3);
            Console.WriteLine("result : {0}", result);
        }
    }
}
