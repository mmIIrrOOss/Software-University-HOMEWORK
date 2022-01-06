namespace _07.Custom_Exception
{
    using System;

    using Models;
    using Exceptions;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Mir0", "mmiirrooss@gmail.com");
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine($"Exception throw: {ipne.Message}");
            }
        }
    }
}
