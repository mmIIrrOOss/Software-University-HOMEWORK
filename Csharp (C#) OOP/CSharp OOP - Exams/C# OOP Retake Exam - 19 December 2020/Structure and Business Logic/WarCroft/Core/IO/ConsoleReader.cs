namespace WarCroft.Core.IO
{
    using System;
    using WarCroft.Core.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
