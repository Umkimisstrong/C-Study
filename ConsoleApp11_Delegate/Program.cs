using System;

namespace ConsoleApp11_Delegate
{
    class Program
    {
        delegate int Compare<T>(T a, T b);

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            Console.WriteLine("no Sorting ▼▼");
            int[] array = { 3, 7, 4, 2, 10 };
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }


            Console.WriteLine("\nSorting ascending▼▼");
            BubbleSort<int>(array, new Compare<int>(AscendCompare));
            for (int j = 0; j < array.Length; j++)
            {
                Console.WriteLine(array[j]);

            }

            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };
            Console.WriteLine();
            Console.WriteLine("Sorting descending ▼▼");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine($"{array2[i]} ");
            }

            /*
            no Sorting ▼▼
            3
            7
            4
            2
            10

            Sorting ascending▼▼
            2
            3
            4
            7
            10

            Sorting descending ▼▼
            mno
            jkl
            ghi
            def
            abc
            */


        }

        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }

        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1;
        }

        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            int i = 0;
            int j = 0;
            T temp;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        // 자리바꾸기
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;

                    }
                }
            }
        }
    }
}
