namespace _01.Logger.IOMenagment
{
    using System;

    using IOMenagment.Coonstrains;

    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
