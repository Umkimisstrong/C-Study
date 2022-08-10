using System;

namespace ConsoleApp16_Lambda
{
    class Program
    {
        // 람다 식 구현을 위한 대리자 선언
        // ------------
        //   └ ▶ 익명 메소드를 만들기 위한

        //delegate int Calculate(int a, int b);

        delegate string Concatenate(string[] args);
        delegate void DoSomething();

        static void Main(string[] args)
        {

            // ▼
            // Calculate calc = delegate (int a, int b)
            //                  {
            //                      return a + b;
            //                  };

            // ★ 위와 동일 구문
            //Calculate calc = (a, b) => a + b;

            //Console.WriteLine($"{3} + {4} : {calc(3, 4)}");  -- 7

            DoSomething DoIt = () =>
                                {
                                    Console.WriteLine("뭔가를");
                                    Console.WriteLine("출력해보자");
                                };
            DoIt();




            Concatenate concat =
                                 (arr) =>
                                 {
                                     string result = "";
                                     foreach (string s in arr)
                                         result += s;
                                     return result;
                                 };

            string[] strArray = { "아버지가", "방에", "들어가신다" };
            Console.WriteLine(concat(strArray));




        }
    }
}

/*
 뭔가를
출력해보자
아버지가방에들어가신다
 */