namespace Shapes
{
    using System;
    using Models.Shapes;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2, 3);
            Circle circle = new Circle(6);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());

            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());

        }
    }
}
