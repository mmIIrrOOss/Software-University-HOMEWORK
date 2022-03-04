namespace _02.Facade
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
               .Info
               .WithType("BMW")
               .WithColor("Black")
               .WithNumberOfDoors(5)
               .Built
               .InCity("Leipzig")
               .AtAdress("Some adress 254")
               .Build();
            Console.WriteLine(car);
        }
    }
}
