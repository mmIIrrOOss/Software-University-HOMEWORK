namespace SnakeGame
{
    using System;
    using Dependency_Injection;
    using Dependency_Injection.Injectors;
    using Engines;
    using SnakeGame.DI;
    using SnakeGame.IO;
    using SnakeGame.IO.Contracts;

    class StartUp
    {
        static void Main(string[] args)
        {
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();
            //Snake snake = new Snake(writer);
            Injector injector = DInjector.CreateInjector(new CongigureDI());
            Engine engine = injector.Inject<Engine>();
            Snake snake = injector.Inject<Snake>();
            snake.DrawSnake();
            engine.Start();
        }
    }
}
