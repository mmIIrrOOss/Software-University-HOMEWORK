namespace P02.Graphic_Editor.Models
{
    using Contracts;
    using System;

    public class Rectangle : IShape
    {
        public Rectangle(double lenght, double width)
        {
            Lenght = lenght;
            Width = width;
        }

        public double Lenght { get; set; }

        public double Width { get; set; }

        public double Area => Lenght * Width;

        public string Draw()
        {
            return $"I am {GetType().Name}";
        }
    }
}
