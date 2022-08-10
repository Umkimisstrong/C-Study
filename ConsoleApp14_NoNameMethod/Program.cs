using System;

namespace ConsoleApp14_NoNameMethod
{
    // 익명메소드를 통한 버블 정렬 구현

    delegate int Compare(int a, int b);

    


    class Program
    {
        static void BubbleSort(int[] Dataset, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;


            for (i = 0; i < Dataset.Length; i++)
            {
                for (j = 0; j < Dataset.Length - 1; j++)
                {
                    if (Comparer(Dataset[j], Dataset[j + 1]) > 0)
                    {
                        temp = Dataset[j + 1];
                        Dataset[j + 1] = Dataset[j];
                        Dataset[j] = temp;
                    }
                }


            }
        }



        static void Main(string[] args)
        {
            int[] testArray = { 3, 6, 1, 10, 2, 7 };

            Console.WriteLine("Sorting Ascending...");
            BubbleSort(testArray, delegate (int a, int b) {
                if (a > b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });


            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine($"{testArray[i]}");
            }


            // 2번째 테스트
            int[] testArray2 = { 7, 2, 8, 10, 11 };
            Console.WriteLine("\n Sorting Dscending..");
            BubbleSort(testArray2, delegate (int a, int b) {
                if (a > b)
                    return -1;
                else if (a == b)
                    return 0;
                else
                    return 1;
            });

            for (int i = 0; i < testArray2.Length; i++)
            {
                Console.WriteLine($"{testArray2[i]} ");
            }

            Console.WriteLine();

        }
    }
}
/*
 Sorting Ascending...
1
2
3
6
7
10

 Sorting Dscending..
11
10
8
7
2

 */
