
namespace QuickSort_Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            if (array == null)
            {
                return;
            }
            var arrayList = array.ToList();
            QuickSortImprove(arrayList, 0, arrayList.Count - 1);
            Console.WriteLine(string.Join(" ", arrayList));
        }
        public static void QuickSortImprove(List<int> array,
            int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            var partitionIndex = Partition(array, left, right);
            QuickSortImprove(array, left, partitionIndex);
            QuickSortImprove(array, partitionIndex + 1, right);

        }
        static int Partition(List<int> array, int left, int right)
        {
            int pivot = array[rand.Next(0, array.Count)];
            int i = left - 1;
            int j = right + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < pivot);
                do
                {
                    j--;
                } while (array[j] > pivot);
                if (i >= j)
                {
                    return j;
                }
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        //static void QuickSort(int[] array, int start, int end)
        //{
        //    int pivot = array[start];
        //    int leftIndex = start;
        //    int rightIndex = end;
        //    for (int i = start; i < end; i++)
        //    {
        //        if (array[i] < pivot)
        //        {
        //            int temp = array[leftIndex];
        //            array[leftIndex] = array[i];
        //            array[i] = temp;
        //            leftIndex++;
        //        }
        //        if (array[i] > pivot)
        //        {
        //            int temp = array[rightIndex];
        //            array[rightIndex] = array[i];
        //            array[i] = temp;
        //            rightIndex--;
        //        }
        //    }
        //    QuickSort(array, start, leftIndex);
        //    QuickSort(array, rightIndex, end);
        //}
        static Random rand = new Random();
        static List<int> QuickSort(List<int> array)
        {
            if (array.Count <= 1)
            {
                return new List<int>();
            }
            int pivot = array[rand.Next(0, array.Count)];
            List<int> leftArray = new List<int>();
            List<int> rightArray = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < pivot)
                {
                    leftArray.Add(array[i]);
                    leftIndex++;
                }
                if (array[i] > pivot)
                {
                    rightArray.Add(array[i]);
                    rightIndex++;
                }
            }
            var leftSorted = QuickSort(leftArray);
            var rightSorted = QuickSort(rightArray);
            return leftSorted.Concat(new int[] { pivot }).Concat(rightSorted).ToList();
        }
    }
}
