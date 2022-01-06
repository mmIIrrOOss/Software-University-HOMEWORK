namespace P01_RawData.IO
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}

