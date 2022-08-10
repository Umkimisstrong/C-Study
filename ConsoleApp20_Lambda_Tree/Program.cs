using System;
// Expression 을 사용하기 위한 using 구문
using System.Linq.Expressions;

namespace ConsoleApp20_Lambda_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1*2 + (x-y) ▶ 이 식을 구현하기 위해서 Expression 을 활용

            // ① Constant 
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            // ② Multiply
            Expression leftExp = Expression.Multiply(const1, const2); // 1 * 2


            // ③ Parameter
            Expression param1 = Expression.Parameter(typeof(int)); // x를 위한 변수
            Expression param2 = Expression.Parameter(typeof(int)); // y를 위한 변수

            // ④ Subtract
            Expression rightExp = Expression.Subtract(param1, param2);    // x-y

            // ⑤ Add
            Expression exp = Expression.Add(leftExp, rightExp);

            // ⑥ Lambda
            Expression<Func<int, int, int>> expression
                = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>
                  (exp, new ParameterExpression[] {
                        (ParameterExpression)param1
                      , (ParameterExpression)param2
                  });

            Func<int, int, int> func = expression.Compile();

            // x = 7, y = 8;
            Console.WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");
            // 1*2+(7-8) = 1


        }
    }
}
