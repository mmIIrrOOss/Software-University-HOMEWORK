namespace _01.RhombusofStars.IO
{
    using _01.RhombusofStars.IO.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
