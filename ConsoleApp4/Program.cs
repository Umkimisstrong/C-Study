using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("여러분, 안녕하세요?");
            Console.WriteLine("반갑습니다!");

            sbyte a = -10;
            byte b = 40;
            Console.WriteLine($"a={a}, b={b}");

            short c = -30000;
            ushort d = 60000;

            Console.WriteLine($"c={c}, d={d}");
        }
    }
}
