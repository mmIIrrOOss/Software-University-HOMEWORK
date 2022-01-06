namespace P02_CarsSalesman.IO
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

