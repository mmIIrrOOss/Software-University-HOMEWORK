namespace OnlineShop.IO
{
    using System;

    public class ConsoleReader : IReader
    {
        public string CustomReadLine()
        {
            return Console.ReadLine();
        }
    }
}