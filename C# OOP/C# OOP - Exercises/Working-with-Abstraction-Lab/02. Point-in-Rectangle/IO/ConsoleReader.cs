namespace _02._Point_in_Rectangle.IO
{
    using System;
    using Contracts;

    public class ConsoleReader : IReader
    {
        public object ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
