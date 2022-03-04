namespace SimpleSnake
{
    using System;
    using System.IO;
    using System.Linq;
    using GameObjects;
    using SimpleSnake.Core;
    using SimpleSnake.Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall, 1, 1);
            Engine engine = new Engine(snake,wall);
            Console.SetCursorPosition(0, wall.TopY + 2);
            var result = File.ReadAllLines("../../../Databases/Score.txt")
                .OrderByDescending(x=>int.Parse(x.Split(" - ",StringSplitOptions.RemoveEmptyEntries)[1])).Take(5);
            Console.WriteLine(string.Join(Environment.NewLine,result));
            engine.Run();
        }
    }
}
