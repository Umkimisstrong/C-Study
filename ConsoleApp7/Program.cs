using System;

namespace ConsoleApp7
{
    public class Mammal
    {
        public Mammal()
        {

        }

        public void Nurse()
        {
            Console.WriteLine("수유중");
        }

    }
    class Cat : Mammal
    {
        public Cat()
        { 

        }

        public void Meow()
        {
            Console.WriteLine("고양이의 울음은 미우");
        }
    }

    class Dog : Mammal
    {
        public Dog()
        {
        }

        public void Bark()
        {
            Console.WriteLine("강아지의 울음은 Bark");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //형식변환 연산자
            Mammal mammal = new Dog();
            Mammal mammal2 = new Cat();

            Dog dog;
            if (mammal is Dog)
            {
                dog = (Dog)mammal;
                dog.Bark();
            }

            Cat cat = mammal2 as Cat;
            if (cat != null)
            {
                cat.Meow();
            }


        }
    }
}
