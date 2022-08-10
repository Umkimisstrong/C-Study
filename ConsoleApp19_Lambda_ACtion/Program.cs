using System;

namespace ConsoleApp19_Lambda_ACtion
{
    // Action 대리자 실습
    class Program
    {
        static void Main(string[] args)
        {
            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine("Action<T1, T2>({0}, {1}) : {2}", x, y, pi);
            };

            act3(22.0, 7.0);
            // Action<T1, T2>(22, 7) : 3.142857142857143


        }
    }
}
