
namespace SelectionSort_Algorithm
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 8, 5, 6, 2, 7, 9, 3, 1 };
            SelectionSort(list);
            Console.WriteLine(string.Join(" ",list));
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
    }
}
