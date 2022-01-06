namespace StudentSystem.IO
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
