namespace SnakeGame.DI
{
    using Dependency_Injection.Modules;
    using SnakeGame.IO;
    using SnakeGame.IO.Contracts;

    public class CongigureDI : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();

        }
    }
}
