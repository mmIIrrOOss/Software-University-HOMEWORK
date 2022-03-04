namespace P02.Graphic_Editor
{
    using System;
    using Models;
    using Models.Contracts;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {

            IShape shape = new Circle(5.5);
            IShape square = new Square(5.5);
            IShape rectangle = new Rectangle(5.5, 6.6);

            List<IShape> shapes = new List<IShape>();
            shapes.Add(shape);
            shapes.Add(square);
            shapes.Add(rectangle);

            foreach (IShape currentShape in shapes)
            {
               Console.WriteLine(currentShape.Draw());
            }
        }
    }
}
