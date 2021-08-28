
namespace ClassBoxData
{
	using System;
	public class StartUp
	{
		public static void Main()
		{

			double length = double.Parse(Console.ReadLine());
			double width = double.Parse(Console.ReadLine());
			double heigth = double.Parse(Console.ReadLine());
			try
			{
				Box box = new Box(length, width, heigth);
				double surfaceArea = box.GetSurfaceArea(length, width, heigth);
				double literalSurfaceArea = box.GetLateralSurfaceArea(length, width, heigth);
				double volume = box.GetVolume(length, width, heigth);
				Console.WriteLine($"Surface Area - {surfaceArea:f2}");
				Console.WriteLine($"Lateral Surface Area - {literalSurfaceArea:f2}");
				Console.WriteLine($"Volume - {volume:f2}");
			}
			catch (ArgumentException argsexc)
			{
				Console.WriteLine(argsexc.Message);
				return;
			}
		}
	}
}
