using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            sbyte a = -10;
            byte b = 40;

            Console.WriteLine($"a={a}, b={b}");

            short c = -30000;
            ushort d = 60000;

            Console.WriteLine($"c={c}, d={d}");

            int e = -1000_0000; // 0이 7개
            uint f = 3_0000_0000; // 0이 8개

            Console.WriteLine($"e={e}, f={f}");

            long g = -5000_0000_0000; // 0이 11개
            ulong h = 200_0000_0000_0000_0000; // 0이 18개

            Console.WriteLine($"g={g}, h={h}");

            uint ab = uint.MaxValue;

            Console.WriteLine(ab);

            ab = ab + 1;

            Console.WriteLine(ab);
            // OverFlow 되는 변수는 0이된다.





            Console.WriteLine("Total : {0, -7: D}", 123);   // 첨자 : 0, 맞춤 : -7, 서식문자열 : D
            Console.WriteLine("{0, -10}DEF", "ABC");
            // ABC       DEF


            DateTime dt = new DateTime(2018, 11, 3, 23, 18, 22);
            Console.WriteLine("{0}", dt);
            //2018 - 11 - 03 오후 11:18:22
        }
    }
}
