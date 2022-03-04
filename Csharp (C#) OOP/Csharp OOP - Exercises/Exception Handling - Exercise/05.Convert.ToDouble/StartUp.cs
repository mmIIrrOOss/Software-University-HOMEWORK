namespace _05.Convert.ToDouble
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string input = Console.ReadLine();
                double resultParseInputToDouble = double.Parse(input);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"{fe.InnerException} is not in an appropriate format for a Double type.");
            }
            catch(InvalidCastException ice)
            {
                Console.WriteLine($"{ice.Data} does not implement the IConvertible interface.");
            }
            catch(OverflowException oe)
            {
                Console.WriteLine($"{oe.Data} represents a number that is less than MinValue or greater than");
            }
        }
    }
}
