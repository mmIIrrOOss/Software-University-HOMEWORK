using System;
using System.Linq;

namespace fibonacci_recursive
{
    class Program
    {
        static void Main()
        {
            int nFibonacci = int.Parse(Console.ReadLine());

            if (nFibonacci <= 1)
            {
                Console.WriteLine(1);
            }

            else
            {

                double plusPhi = (1 + Math.Sqrt(5)) / 2;
                double minusPhi = (1 - Math.Sqrt(5)) / 2;


                double fibonacci = (Math.Pow(plusPhi, nFibonacci) - Math.Pow((-minusPhi), nFibonacci))
                    / Math.Sqrt(5);

                long roundedFib = (long)Math.Round(fibonacci);

                Console.WriteLine(roundedFib);

            }
        }
    }
}