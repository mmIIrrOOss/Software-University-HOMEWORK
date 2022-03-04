namespace SnakeGame.IO
{
    using System;

    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
