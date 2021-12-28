namespace _07.Military_Elite.Engine.IO
{
    using _07.Military_Elite.Engine.IO.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine(); 
        }
    }
}
