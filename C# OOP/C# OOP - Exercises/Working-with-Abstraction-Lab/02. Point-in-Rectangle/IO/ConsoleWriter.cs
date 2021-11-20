namespace _02._Point_in_Rectangle.IO
{
    using _02._Point_in_Rectangle.IO.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
