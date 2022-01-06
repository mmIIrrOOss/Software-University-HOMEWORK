namespace P01_RawData
{
    using System;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new ProgramEngine();
            engine.Run();
        }
    }
}
