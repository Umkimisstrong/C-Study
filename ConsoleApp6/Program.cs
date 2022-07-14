using System;

namespace ConsoleApp6
{
    class Program
    {

        public static void Swap(int a, int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        public static void Swaped(ref int a, ref  int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // 참조에 의한 매개변수 전달.. 
            // 참조는 원래의 값이 바뀌지 않음

            int x = 3;
            int y = 4;
            Console.WriteLine($"x:{x}, y:{y}");

            Swap(x, y);

            Console.WriteLine($"x:{x}, y:{y}");

            /*
            x:3, y:4
            x:3, y:4
            */

            Swaped(ref x, ref y);
            Console.WriteLine($"x:{x}, y:{y}");
            /*
            x:3, y:4
            x:3, y:4
            x:4, y:3 
            */


            // Divide 메소드 실행
            int k = 20;
            int j = 3;
            int quotient = 0;
            int remainder = 0;
            Divide(k, j, ref quotient, ref remainder);

            Console.WriteLine("Quotient : {0}, Remainder : {1}", quotient, remainder);
            // Quotient : 6, Remainder : 2


            // Sum 메소드 실행
            int sumResult = Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Console.WriteLine(sumResult);
            //55





            // 소문자로 변경해주는 메소드
            Console.WriteLine(ToLowerString("SELECT ~FROM ~"));
            // select ~from ~
        }

        // 나눗셈을 하여 몫과 나머지를 반환하는 메소드 구현(출력용, 결과값을 참조로 반환)
        public static void Divide(int a, int b, ref int quotient, ref int remainder)
        {
            // 몫
            quotient = a / b;
            remainder = a % b;
        }

        // 매개변수가 여러개인 메소드
        public static int Sum(params int[] args)
        {
            int sum = 0;

            for (int i = 0; i < args.Length; i++)
            {
                sum += args[i];
            }

            return sum;
        }

        // 입력된 문자를 소문자로 변경시켜주는 메소드
        public static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = ToLowerChar(i);

            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)  // A~Z 의 ASCII 코드 값 : 65 ~ 90 즉, 입력된 문자가  소문자라면
                    return arr[i];
                else // 그렇지 않다면, 즉 입력된 문자가 대문자라면
                    return (char)(arr[i] + 32);
            }
            return new string(arr);
        }


    }
}
