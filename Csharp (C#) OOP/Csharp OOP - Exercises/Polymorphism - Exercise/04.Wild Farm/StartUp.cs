namespace _04.Wild_Farm
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
