using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // ▶ 연산자 ??

            List<int> num = null;
            int? a = null;

            (num ??= new List<int>()).Add(5);

            Console.WriteLine(string.Join("▶", num));   // 5

            num.Add(a ??= 0);
            Console.WriteLine(string.Join("▶", num));   // 5 0

            Console.WriteLine(a);                       // 0
            
        }
    }
}
