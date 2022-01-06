namespace Shapes.Models.Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;


        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get => radius; private set => radius = value; }

        public override double CalculateArea()
        {
            double area = Math.PI * (Radius * Radius);
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * Radius;
            return perimeter;
        }
        public override string Draw()
        {
            return this.GetType().Name;
        }
    }
}
