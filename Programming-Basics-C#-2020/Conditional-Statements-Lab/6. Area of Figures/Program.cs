using System;

namespace _100do200
{
    class Program
    {
        static void Main(string[] args)
        {

            string figures = Console.ReadLine();

            if (figures == "square")
            {
                double length = double.Parse(Console.ReadLine());
                double area = length * length;
                Console.WriteLine($"{area:f3}");
            }
            else if (figures == "rectangle")
            {
                double lenghtA = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double area = lenghtA * width;
                Console.WriteLine($"{area:f3}");
            }
            else if (figures == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = radius * radius * Math.PI;
                Console.WriteLine($"{area:f3}");
            }
            else if (figures == "triangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = (lenght * height) / 2;
                Console.WriteLine($"{area:f3}");
            }


        }

    }
}