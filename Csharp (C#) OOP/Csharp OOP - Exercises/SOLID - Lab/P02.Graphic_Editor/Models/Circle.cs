namespace P02.Graphic_Editor.Models
{
    using Contracts;
    using System;

    public class Circle : IShape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }

        public double Area => Math.PI * (Radius * Radius);

        public string Draw()
        {
            return $"I am {GetType().Name}";
        }
    }
}
