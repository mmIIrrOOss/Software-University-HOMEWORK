namespace _07.Military_Elite.Engine.IO
{
    using _07.Military_Elite.Engine.IO.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
