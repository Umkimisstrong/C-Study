using System;

namespace ConsoleApp1
{
    class Program
    {
        // 메인 메소드
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int k;
            k = 12;
            Console.WriteLine(k);

            if (k == 11)
                Console.WriteLine("11이 맞습니다.");
            else
                Console.WriteLine("11이 아닙니다.");

            String msg = Printer001("ksk");

            Console.WriteLine(msg);

            int result = Printer002(k);
            Console.WriteLine(result);


            // DB 연결 시도
            // uid=mosti_ksk pwd=mosti006$
          
        }

        // 메소드 정의 1
        static String Printer001(String msg)
        {
            String result = "";
            result = msg;
            return result;
        }

        // 메소드 정의 2
        static int Printer002(int k)
        {
            int result = 0;

            for (int i = 1; i<= 9; i++)
            {
                result += k;

            }


            return result;
        }
    }
}
/*
 Hello World!
12
11이 아닙니다.
ksk
 */
