namespace _08.Collection_Hierarchy.Core.IO
{
    using System;
    using Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
