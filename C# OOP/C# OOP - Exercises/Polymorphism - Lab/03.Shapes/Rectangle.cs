namespace Shapes
{
	public class Rectangle : Shape
	{

		public Rectangle(double height, double width)
		{
			this.Height = height;
			this.Width = width;
		}
		public double Height { get => this.height; private set => this.height = value; }
		public double Width { get => this.width; private set => this.width = value; }

		private double height;
		private double width;
		public override double CalculateArea()
		{
			return this.Height * this.Width;
		}

		public override double CalculatePerimeter()
		{
			return 2 * (this.Height * this.Width);
		}
		public override string Draw()
		{
			return $"{base.Draw() + this.GetType().Name}";
		}
	}
}
