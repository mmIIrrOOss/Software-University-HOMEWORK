using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal number = decimal.Parse(Console.ReadLine());
            string unit = Console.ReadLine();
            string convertUnit = Console.ReadLine();

            if (unit =="m"&&convertUnit=="mm")
            {
                decimal meter = number * 1000;
                Console.WriteLine($"{meter:f3}");
            }
            else if (unit =="cm"&&convertUnit== "m")
            {
                decimal santimeters = number * 0.01m;
                Console.WriteLine($"{santimeters:f3}");
            }
            else if (unit =="mm"&&convertUnit=="cm")
            {
                decimal milimeters = number * 0.1m;
                Console.WriteLine($"{milimeters:f3}");
			}
			else if (unit=="mm"&&convertUnit=="m")
			{
                decimal meters = number * 0.001m;
				Console.WriteLine($"{meters:f3}");
			}
			else if (unit=="m"&&convertUnit=="cm")
			{
                decimal sm = number * 100;
				Console.WriteLine($"{sm:f3}");
			}
			else if (unit=="cm"&&convertUnit=="mm")
			{
                decimal mm = number * 10;
				Console.WriteLine($"{mm:f3}");
			}
        }
    }
}
