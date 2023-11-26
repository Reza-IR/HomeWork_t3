using System;

namespace Homework_t3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[8];

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    Console.Write($"please enter {i + 1} numbers : ");
                    array[i] = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception err)
                {
                    array[i] = 0;
                    continue;
                }


            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            array = MergeSort(array);
            foreach (var item in array)
                Console.Write(item + ", ");
        }

        static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            int middle = array.Length / 2;
            int[] left = new int[middle];
            int[] right = (array.Length % 2 == 0 ? new int[middle] : new int[middle + 1]);

            for (int i = 0; i < middle; i++)
                left[i] = array[i];
            for (int i = middle; i < array.Length; i++)
                right[i - middle] = array[i];

            return Merge(MergeSort(left), MergeSort(right));
        }

        static int[] Merge(int[] left, int[] right)
        {
            int leftPointer = 0;
            int rightPointer = 0;
            int[] merged = new int[left.Length + right.Length];

            for (int i = 0; i < merged.Length; i++)
            {
                if (rightPointer == right.Length || ((leftPointer < left.Length) && (left[leftPointer] <= right[rightPointer])))
                    merged[i] = left[leftPointer++];
                else
                    merged[i] = right[rightPointer++];
            }
            return merged;
        }
    }
}