using System;
using System.Linq;

namespace ConsoleApp22_LINQ
{
    // LINQ
    // 데이터 집합에서 
    // 쿼리문을 통해
    // 결과를 추출할 수 있다.

    // 실행 순서 ▶ from where orderby select
    // ▼
    // from 절에서 데이터를 얻어올 수 있는 집합은
    // IEnumerable<T> 인터페이스를 상속하는 데이터 집합이다.
    // 대부분의 Collection 들은 가능하다.

    // foreach 와 연계하여 데이터를 추출한다.

    // var 로 꺼내는 데이터는
    // select 절에서 반환하는 형식에 맞게 설정되는데,
    // 기본적으로 데이터(엔티티)를 기반으로 모두 추출하는 경우,
    // IEnumerable<엔티티> 형식으로 반환된다.

    // 그러나 데이터(엔티티) 중 하나의 데이터(string)만 추출하는 경우
    // IEnumerable<string> 형식으로 반환된다.



    
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

            var result = from       n in numbers
                         where      n % 2 == 0
                         orderby    n
                         select     n;

            foreach (int n in result)
            {
                Console.WriteLine($"짝수 : {n}");
            }
        }
    }
}
/*
짝수 : 2
짝수 : 4
짝수 : 6
짝수 : 8
짝수 : 10
 */
