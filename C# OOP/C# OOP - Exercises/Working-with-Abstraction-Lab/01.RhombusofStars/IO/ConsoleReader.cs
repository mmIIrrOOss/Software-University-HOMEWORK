namespace _01.RhombusofStars.IO
{
    using System;
    using Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
