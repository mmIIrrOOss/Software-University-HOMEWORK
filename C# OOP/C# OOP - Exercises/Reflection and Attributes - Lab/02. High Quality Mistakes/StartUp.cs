namespace Stealer
{
    using System;
    using Models;

    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers(typeof(Hacker).FullName);
            Console.WriteLine(result);
        }
    }
}
