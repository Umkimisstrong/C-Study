using System;

namespace ConsoleApp10_Delegate
{
    class Program
    {
        delegate int Compare(int a, int b);

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");



            int [] array = { 3, 7, 4, 2, 10};
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            

            BubbleSort(array, new Compare(AscendCompare));
            for (int j = 0; j < array.Length; j++)
            {
                Console.WriteLine(array[j]);

            }



        }

        static int AscendCompare(int a, int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;
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
