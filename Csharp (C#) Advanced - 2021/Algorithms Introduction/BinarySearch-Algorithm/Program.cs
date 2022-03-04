
namespace BinarySearch_Algorithm
{
    using System;
    using System.Linq;

    class Program
    {
        
        static void Main()
        {
            double[] array = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            double number = double.Parse(Console.ReadLine());
            int count = 0;
            Console.WriteLine(BinarySearch(array, number, 0, array.Length,ref count));
            /*Console.WriteLine($"NUmber operation {count}")*/;
        }
        private static int BinarySearch(double[] array, double number, double start,
            double end, ref int count)
        {
            if (start > end)
            {
                return -1;
            }
            count++;
            double middle = (start + end) / 2;

            if (number < array[(int)middle])
            {
                return BinarySearch(array, number, start, middle - 1,ref count);
            }
            if (number > array[(int)middle])
            {
                return BinarySearch(array, number, middle + 1, end,ref count);
            }
            else
            {
                return (int)middle;
            }
        }
        static int binarySearch(int[] arr, int l,
                            int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                // If the element is present at the
                // middle itself
                if (arr[mid] == x)
                    return mid;

                // If element is smaller than mid, then
                // it can only be present in left subarray
                if (arr[mid] > x)
                    return binarySearch(arr, l, mid - 1, x);

                // Else the element can only be present
                // in right subarray
                return binarySearch(arr, mid + 1, r, x);
            }

            // We reach here when element is not present
            // in array
            return -1;
        }


    }
}
