using System;
namespace Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {


            int container1 = int.MinValue;
            int container2 = int.MinValue;
            int container3 = int.MinValue;

            for (int i = 0; i < 3; i++)
            {
                int numberToCheck = int.Parse(Console.ReadLine());
                if (numberToCheck > container1)
                {
                    container3 = container2;
                    container2 = container1;
                    container1 = numberToCheck;
                }
                else if (numberToCheck > container2)
                {
                    container3 = container2;
                    container2 = numberToCheck;
                }
                else if (numberToCheck > container3)
                {
                    container3 = numberToCheck;
                }

            }
            Console.WriteLine(container1);
            Console.WriteLine(container2);
            Console.WriteLine(container3);
        }
    }
}