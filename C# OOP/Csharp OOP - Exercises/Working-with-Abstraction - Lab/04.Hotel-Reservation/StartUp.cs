namespace _04.Hotel_Reservation
{
    using System;
    using Core.Contracts;
    using Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
