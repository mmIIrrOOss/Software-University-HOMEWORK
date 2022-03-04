namespace WarCroft.Core.IO
{
    using System;
    using WarCroft.Core.IO.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}