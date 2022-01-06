namespace P02.Graphic_Editor.Models
{
    using Contracts;
    using System;

    public class Square : IShape
    {
        public Square(double side)
        {
            Side = side;
        }

        public double Side { get; private set; }

        public double Area => Side * Side;

        public string Draw()
        {
            return $"I am {GetType().Name}";
        }
    }
}
