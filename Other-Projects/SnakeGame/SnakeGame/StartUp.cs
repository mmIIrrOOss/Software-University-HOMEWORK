using System;

namespace SnakeGame
{
    class StartUp
    {
        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight;
            var engine = new GameEngine();
            engine.Start();
        }
    }
}
