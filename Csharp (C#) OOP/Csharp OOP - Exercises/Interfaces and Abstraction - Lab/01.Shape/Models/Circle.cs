namespace _01.Shape.Models
{
    using System;
    using Constrains;

    public class Circle : IDrawable
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double rin = radius - 0.4;
            double rOut = radius + 0.4;
            for (double i = radius; i >= -radius; --i)
            {
                for (double j = radius; j < rOut; j += 0.5)
                {
                    double value = i * i + j * j;
                    if (value >= rin * rin && value <= rOut * rOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
