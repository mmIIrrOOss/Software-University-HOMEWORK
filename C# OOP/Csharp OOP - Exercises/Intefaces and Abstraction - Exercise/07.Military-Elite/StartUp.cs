using _07.Military_Elite.Engine.IO;
using _07.Military_Elite.Engine.IO.Contracts;

namespace _07.Military_Elite.Engine
{
    
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}
