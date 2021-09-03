
using System;

namespace Shapes
{
	public class Circle : Shape
	{
		public Circle(double radius)
		{
			this.Radius = radius;
		}
		public double Radius { get => this.radius; private set => this.radius = value; }

		private double radius;
		public override double CalculateArea()
		{
			return Math.PI * this.Radius * this.Radius;
		}
		public override double CalculatePerimeter()
		{
			return 2 * Math.PI * this.Radius;
		}
		public override string Draw()
		{
			return $"{base.Draw() + this.GetType().Name}";
		}

	}
}
