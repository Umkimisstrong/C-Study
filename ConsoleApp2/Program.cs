/*
    ConsoleApp2
    - C# 변수 / 연산
    - C# 자료형
    - C# 제어문
    - C# 반복문
    - C# 배열
    - C# 컬렉션
*/


using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 변수 / 자료형 및 선언

            int a;
            int b;
            int d;
            double c;

            a = 0;
            b = 1;
            c = 2;
            d = 5;

            Console.WriteLine(a + b);
            // 1
            Console.WriteLine(a + c);
            // 0.5
            Console.WriteLine(b + c);
            // 1.5
            Console.WriteLine(c + c);
            // 1

            Console.WriteLine(a - c);
            // -0.5
            Console.WriteLine(a * c);
            // 0
            Console.WriteLine(d / c);
            // 10
            Console.WriteLine(d % c);
            // 1

            /*
             연산은 자바와 동일
            */

            // 자료형
            String k = "모스티소프트";
            String msg = "모스티소프트모스티소프트mostisoft";
            char j = 'a';
            Console.WriteLine(k); // 모스티소프트
            Console.WriteLine(j); // a
            Console.WriteLine(k.Length); // 6 
            Console.WriteLine(msg.Length); // 21



            if (k == "모스티소프트")
            {
                j = 'x';
            }
            else if (k == "모스티")
            {
                j = 'h';
            }

            Console.WriteLine(j);
            // x


            // 반복문
            int i = 0;
            /*
            do
            {
                Console.Write(i);
                i++;
                
            }
            while (i <= 100);
            */

            // 구구단
            /*
            for (int m = 1; m <= 9; m++)
            {
                for (int n = 1; n <= 9; n++)
                {
                    int result = m * n;
                    Console.WriteLine($"{m} * {n} = {result}");
                }
         
            }
            */

            // ReadLine() 관찰
            /*
            Console.WriteLine("0을 클릭하세요");
            String answer = Console.ReadLine();

            if (answer == "0")
            {
                Console.WriteLine($"{answer} 을 클릭하셨군요, 수고하셨습니다.");
            }
            else
            {
                Console.WriteLine("0이 아니군요, 틀렸습니다.");
            }*/
            // 정상

            /*
            // 배열 
            int[] array1 = new int[6];

            for(int h=0; h<6; h++)
            {
                array1[h] = h;
                Console.WriteLine(array1[h]);
                // 0 1 2 3 4 5 
            }

            int plus = 0;
            while (plus <= 15)
            {
                Console.WriteLine(plus);
                plus += 1;
            }
            Console.WriteLine(plus);
            */

            // 컬렉션 Collection
            // System.Collectios.Generic

            var salmons = new List<String>();

            salmons.Add("연어1");
            salmons.Add("연어2");
            salmons.Add("연어3");
            salmons.Add("연어4");
            salmons.Add("연어5");
            salmons.Add("연어6");


            String salmonString = "";
            // 향상된 반복문 (foreach) 사용
            foreach (var salmon in salmons)
            {
                salmonString += salmon + " 과 ";
            }

            String newSalmon = salmonString.Substring(0, salmonString.LastIndexOf("과")-1);
            Console.WriteLine(newSalmon);
            // 연어1 과 연어2 과 연어3 과 연어4 과 연어5 과 연어6

            

            string numString = "1287543"; //"1287543.0" will return false for a long
            long number1 = 0;
            bool canConvert = long.TryParse(numString, out number1);
            if (canConvert == true)
                Console.WriteLine("number1 now = {0}", number1);
            else
                Console.WriteLine("numString is not a valid long");

            byte number2 = 0;
            numString = "255"; // A value of 256 will return false
            canConvert = byte.TryParse(numString, out number2);
            if (canConvert == true)
                Console.WriteLine("number2 now = {0}", number2);
            else
                Console.WriteLine("numString is not a valid byte");

            decimal number3 = 0;
            numString = "27.3"; //"27" is also a valid decimal
            canConvert = decimal.TryParse(numString, out number3);
            if (canConvert == true)
                Console.WriteLine("number3 now = {0}", number3);
            else
                Console.WriteLine("number3 is not a valid decimal");

            int number4 = 0;
            numString = "123482";
            canConvert = int.TryParse(numString, out number4);
            if (canConvert == true)
            {
                Console.WriteLine("newber4 now = {0}", number4);
            }
            else
                Console.WriteLine("number4 is not a valid int");

        }
    }

}
