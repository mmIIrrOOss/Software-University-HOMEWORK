
namespace _01.ClassBoxData
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);
                double surfaceArea = box.GetSurfaceArea();
                double literalSurfaceArea = box.GetLiteralSurfaceArea();
                double volume = box.GetVolume();
                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {literalSurfaceArea:f2}");
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }
    }
}
