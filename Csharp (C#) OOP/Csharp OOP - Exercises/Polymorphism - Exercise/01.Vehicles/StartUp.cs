namespace _01.Vehicles
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
