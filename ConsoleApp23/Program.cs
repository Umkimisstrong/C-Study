using System;
using System.Collections.Generic;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = 0;

            List<Members> memberList = new List<Members>();
            while ( temp < 3)
            {
                
                Console.WriteLine("이름을 입력하세요");
                string inputName = Console.ReadLine();
            
                Console.WriteLine("나이를 입력하세요");
                int inputAge = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Members member = new Members()
                {
                      name =  inputName
                    , age  =  inputAge
                };

                memberList.Add(member);

                temp++;
            }

            Console.WriteLine();

            foreach (Members oneMember in memberList)
            {
                Console.WriteLine($"이름 : {oneMember.name}");
                Console.WriteLine($"나이 : {oneMember.age.ToString()}");
            }

        }

      

    }

    public class Members
    {
        public string name { get; set; }
        public int age { get; set; } 

        
    }

    

    

}
