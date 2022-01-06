using System;

namespace _04.Fixing_Vol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;

            try
            {
                num1 = 30;
                num2 = 60;
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} x {num2} = {result}");
                Console.ReadLine();
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }
}
