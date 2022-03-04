namespace _01.Square_Root
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                SquareRoot squareRoot = new SquareRoot(number);
                Console.WriteLine(Math.Sqrt(squareRoot.Number));
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid number!");
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
