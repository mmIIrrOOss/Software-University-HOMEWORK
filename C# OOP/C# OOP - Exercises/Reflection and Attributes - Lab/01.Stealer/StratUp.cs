namespace Stealer
{
    using System;
    using Models;

    public class StratUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo(typeof(Hacker).FullName, "username", "password");
            Console.WriteLine(result);
        }
    }
}
