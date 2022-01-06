namespace _02.Enter_Numbers
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    array[i] = ReadNumber(start, end);
                    if (array[i] <= start || array[i] > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Please enter a valid number");
                    i--;
                    continue;
                }
                catch(ArgumentOutOfRangeException are)
                {
                    Console.WriteLine("Number must be bigger than {0} adn smiler than {1}", start,end);
                    i--;
                    continue;
                }

                start = array[i];
            }


            Console.Write("Your numbers are: ");
            foreach (var n in array)
            {
                Console.Write(n + ", ");
            }
            Console.WriteLine();
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            while (!int.TryParse(input, out num))
            {
                throw new FormatException();
            }
            return num;
        }
    }
}
