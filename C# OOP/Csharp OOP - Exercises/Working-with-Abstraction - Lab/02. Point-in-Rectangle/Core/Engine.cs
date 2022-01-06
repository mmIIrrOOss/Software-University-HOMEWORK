namespace _02._Point_in_Rectangle.Core
{
    using IO;
    using Models;
    using Contracts;
    using Models.Constrains;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        public void Run()
        {
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();
            List<IPointContainable> figures = new List<IPointContainable>();
            figures.Add(new Rectangle(3, 1, 1, 3));
            figures.Add(new Circle(0, 2, 2));


            foreach (var firgure in figures)
            {
                writer.WriteLine(firgure.Contains(new Point(0, 0)));
                writer.WriteLine(firgure.Contains(new Point(0, 2)));
                writer.WriteLine(firgure.Contains(new Point(2, 0)));
                writer.WriteLine(firgure.Contains(new Point(3, 0)));
                writer.WriteLine(new string('-', 10));
            }

        }
    }
}
