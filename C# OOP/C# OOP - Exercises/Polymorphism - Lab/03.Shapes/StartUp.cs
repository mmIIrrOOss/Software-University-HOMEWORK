using System;

namespace Shapes
{
	public class StartUp
	{
		static void Main()
		{
			Circle circle = new Circle(2);
			double circleArea = circle.CalculateArea();
			double circlePerimeter = circle.CalculatePerimeter();

			Rectangle rectangle = new Rectangle(5, 6);
			double rectArea = rectangle.CalculateArea();
			double rectPerimeter = rectangle.CalculatePerimeter();

			Console.WriteLine(circle.Draw());
			Console.WriteLine($"Circle area: {circleArea:f2}");
			Console.WriteLine($"Circle perimeter: {circlePerimeter:f2}");
			
			Console.WriteLine(rectangle.Draw());
			Console.WriteLine($"Rectangle area: {rectArea:f2}");
			Console.WriteLine($"Rectangle primeter: {rectPerimeter:f2}");
		}
	}
}
