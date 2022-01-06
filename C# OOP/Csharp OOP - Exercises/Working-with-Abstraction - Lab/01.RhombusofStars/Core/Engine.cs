namespace _01.RhombusofStars.Core
{
    using IO;
    using Models;
    using Contracts;

    public class Engine : IEngine
    {
        public void Run()
        {
            ConsoleReader reader = new ConsoleReader();
            int countOfStars = int.Parse(reader.ReadLine());
            RhombusAsString rhombusAsString = new RhombusAsString();
            ConsoleWriter writer = new ConsoleWriter();
            writer.WriteLine(rhombusAsString.Draw(countOfStars));
        }
    }
}
