using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                bool integerChek = int.TryParse(input, out int integer);
                bool doubleChek = double.TryParse(input, out double floating);
                bool charChek = char.TryParse(input, out char mychar);
                bool boolChek = bool.TryParse(input, out bool boolean);

                if (integerChek)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (doubleChek)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (charChek)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (boolChek)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

            }

        }
    }
}

