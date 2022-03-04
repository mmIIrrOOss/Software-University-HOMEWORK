namespace StudentSystem.Core
{
    using IO.Contracts;
    using System;
    public class ConsoleIoEngine : IIoEngine
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
