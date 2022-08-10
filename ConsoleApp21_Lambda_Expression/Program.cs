using System;
using System.Linq.Expressions;

namespace ConsoleApp21_Lambda_Expression
{
    class Program
    {

        // Expression
        // System.Linq.Expression 네임스페이스
        // 파생
        /*
        
        BinaryExpression
        BlockExpression
        ConditionExpression
        ConstantExpression
        DefaultExpression
        DynamicExpression
        GotoExpression
        IndexExpression
        InvocationExpression
        LabelExpression
        LambdaExpression
        ListInitExpression
        LoopExpression
        MemberExpression
        MemberInitExpression
        MethodCallExpression
        NewArrayExpression
        NewExpression
        ParameterExpression
        RuntimeVariablesExpression
        SwithExpression
        TryExpression
        TypeBinaryExpression
        UnaryExpression


        */

        // --==>> Expression 은
        //        식 트리를 구성하는 노드를 표현합니다.
        //        그래서 Expression 을 상속받는 이 파생 클래스들이
        //        식 트리의 각 노드를 표현할 수 있게 됩니다.

        //        식 트리를 구성하는 노드를 표현하는 것 외에도

        //        클래스들의 객체를 생성하는 역할도 담당합니다.
        //        Expression 자체는 추상클래스로 선언되어 객체 생성이 불가하지만,
        //        파생 클래스의 인스턴스를 생성하는 정적 팩토리 메소드를 제공합니다.

        static void Main(string[] args)
        {

            Expression<Func<int, int, int>> expression =
                (a, b) => 1 * 2 + (a - b);
            Func<int, int, int> func = expression.Compile();

            // a = 7, b = 8
            Console.WriteLine($"1*2+(7-8) = {func(7, 8)}");
            // 1*2+(7-8) = 1
        }
    }
}
