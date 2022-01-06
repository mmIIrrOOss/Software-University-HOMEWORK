namespace Shapes.Models.Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            this.width = width;
        }

        public double Height { get => height; private set => height = value; }
        public double Width { get => width; private set => width = value; }

        public override double CalculateArea()
        {
            double area = Width * Height;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (Width + Height);
            return perimeter;
        }

        public override string Draw()
        {
            return this.GetType().Name;
        }
    }
}
