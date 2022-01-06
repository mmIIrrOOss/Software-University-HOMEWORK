namespace _02.Vehicles_Extension
{
    using Core;
    using Core.Contracts;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
