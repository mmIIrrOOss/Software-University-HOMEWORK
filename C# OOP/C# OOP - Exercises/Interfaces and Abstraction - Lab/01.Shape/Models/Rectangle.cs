namespace _01.Shape.Models
{
    using System;
    using Constrains;

    public class Rectangle : IDrawable
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine(width, '*', '*');
            for (int i = 1; i < height - 1; ++i)
            {
                DrawLine(width, '*', ' ');
            }
            DrawLine(width, '*', '*');
        }
        private void DrawLine(double with, char end, char mid)
        {
            Console.WriteLine(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
