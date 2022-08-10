using System;

namespace ConsoleApp17_Lambda
{
    // Func 와 Action
    // Func 대리자
    // Func 대리자는 결과를 반환하는 메소드를 참조
    //   매개변수의 가장 마지막에 있는 것이 반환 형식
    //   총 17개의 Func 대리자가 있음(.NET)

    class Program
    {
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10;           // 매개변수가 없고 반환값만 있음
            Console.WriteLine(func1());
            // 10

            Func<int, int> func2 = (x) => x * 2;  // 매개변수가 1개 있고, 반환값이 1개 있음
            Console.WriteLine(func2(12));
            // 24      

            Func<int, int, int> func3 = (x, y) => x + y;
            Console.WriteLine(func3(2, 3));
            // 5





        }
    }
}
