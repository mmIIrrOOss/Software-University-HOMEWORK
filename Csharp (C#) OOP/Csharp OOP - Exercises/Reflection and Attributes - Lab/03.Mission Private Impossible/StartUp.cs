namespace Stealer
{
    using System;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods(typeof(Hacker).FullName);
            Console.WriteLine(result);
        }
    }
}
