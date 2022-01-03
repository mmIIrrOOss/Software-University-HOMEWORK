namespace _01.Logger.IOMenagment
{
    using System;

    using _01.Logger.IOMenagment.Coonstrains;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
