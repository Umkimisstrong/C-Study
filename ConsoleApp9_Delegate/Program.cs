using System;

namespace ConsoleApp9_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int Plus(int a, int b)
            {
                return a + b;
            }

            int Minus(int a, int b)
            {
                return a - b;
            }

            // DeleGate 실습
            MyDeleGate CallBack;

            CallBack = new MyDeleGate(Plus);
            Console.WriteLine(CallBack(3, 4));  // 7

            CallBack = new MyDeleGate(Minus);   
            Console.WriteLine(CallBack(4, 1));  // 3


            
        }

        delegate int MyDeleGate(int a, int b);

        

        
    }
}
