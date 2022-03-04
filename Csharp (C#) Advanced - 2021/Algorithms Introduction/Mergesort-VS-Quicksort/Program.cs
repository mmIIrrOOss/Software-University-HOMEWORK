
namespace Mergesort_VS_Quicksort
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 10000000;
            Random rand = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(0, n);
            }
            Stopwatch timer = new Stopwatch();
            var arrayList = array.ToList();

            //timer.Start();
            //var quickSort = QuickSort(arrayList);
            //timer.Stop();
            //Console.WriteLine($"Qucksort: {timer.ElapsedMilliseconds}");
            //timer.Reset();

            //timer.Start();
            //var mergeSort = MergeSort(arrayList);
            //timer.Stop();
            //Console.WriteLine($"Mergesort: {timer.ElapsedMilliseconds}");
            //timer.Reset();
            //timer.Start();
            //SelectionSort(arrayList);
            //timer.Stop();
            //Console.WriteLine($"Selectionsort: {timer.ElapsedMilliseconds}");
            timer.Reset();
            var newArrayList = arrayList.ToList();
            timer.Start();
            QuickSortImprove(newArrayList, 0, newArrayList.Count - 1);
            timer.Stop();
            Console.WriteLine($"QuickSort Improved: {timer.ElapsedMilliseconds}");

        }
        static Random rand = new Random();
        public static void QuickSortImprove(List<int> array,
            int left, int right)
        {
            if (left < right)
            {
                return;
            }
            var partitionIndex = Partition(array, left, right);
            QuickSortImprove(array, left, partitionIndex);
            QuickSortImprove(array, partitionIndex + 1, right);

        }
        static int Partition(List<int> array, int left, int right)
        {
            int pivot = array[left + right / 2];
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
        static void SelectionSort(List<int> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                int min = i;
                for (int j = i; j < array.Count; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                var temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
        }
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
        private static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            int middle = list.Count / 2;
            List<int> leftList = MergeSort(list.GetRange(0, middle));
            List<int> rightList = MergeSort(list.GetRange(middle, list.Count - middle));
            return CombineArrays(leftList, rightList);
        }
        private static List<int> CombineArrays(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }
            for (int i = leftIndex; i < left.Count; i++)
            {
                result.Add(left[i]);
            }
            for (int i = rightIndex; i < right.Count; i++)
            {
                result.Add(right[i]);
            }
            return result;
        }
    }
}
