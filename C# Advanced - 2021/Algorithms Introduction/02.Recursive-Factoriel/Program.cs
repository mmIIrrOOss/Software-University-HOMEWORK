
namespace _02.Recursive_Factoriel
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Factoriel(num));
        }

        private static int Factoriel(int num)
        {
            if (num == 1)
            {
                return 1;
            }
            int result = num * Factoriel(num - 1);
            return result;
        }
    }
}
