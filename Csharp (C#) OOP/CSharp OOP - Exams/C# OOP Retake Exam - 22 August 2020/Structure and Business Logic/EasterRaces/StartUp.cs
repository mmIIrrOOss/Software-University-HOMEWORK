using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            string path = "../../../result.txt";
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new FileWriter(path);

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}
