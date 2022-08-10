using System;

namespace ConsoleApp13_NoNameMethod
{
    // 익명 메소드 구현하기
    // 대리자의 메소드
    class Program
    {
        delegate int Calculate(int a, int b);

        static void Main(string[] args)
        {
            Calculate Calc;
            Calc = delegate (int a, int b)
                    {
                        return a + b;
                    };

            Console.WriteLine(Calc(1, 3));
        }
    }
}
