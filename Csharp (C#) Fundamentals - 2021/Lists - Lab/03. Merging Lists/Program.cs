using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {

            List<double> first = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            List<double> second = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            InputTwoeList(first, second);
        }

        public static List<double> InputTwoeList(List<double> first, List<double> second)
        {
            List<double> totalConcatenate = new List<double>();

            int forCycleIteration = Math.Max(first.Count, second.Count);

            for (int i = 0; i < forCycleIteration; i++)
            {
                if (first.Count > i)
                {
                    totalConcatenate.Add(first[i]);
                }
                if (second.Count > i)
                {
                    totalConcatenate.Add(second[i]);
                }
            }

            Console.WriteLine(string.Join(" ", totalConcatenate));

            return totalConcatenate;
        }
    }
}
