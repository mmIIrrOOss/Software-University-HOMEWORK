using System;

namespace WorkingHours
{
	class Program
	{
		static void Main(string[] args)
		{


			int hours = int.Parse(Console.ReadLine());
			string dayOfWeek = Console.ReadLine();
			bool hoursWork = hours >= 10 && hours <= 18;

			if (hoursWork)
			{
				if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday" || dayOfWeek
					== "Saturday")
				{
					Console.WriteLine("open");
				}
				else
				{
					Console.WriteLine("closed");
				}


			}
			else
			{
				Console.WriteLine("closed");
			}







			//if (dayOfWeek=="monday"||dayOfWeek=="tuesday"||dayOfWeek=="wednesday"||dayOfWeek=="thursday"||dayOfWeek
			//    =="friday"||dayOfWeek=="saturday")
			//{
			//    if (hours>=10&&hours<=18)
			//    {
			//        Console.WriteLine("open");
			//    }
			//    else
			//    {
			//        Console.WriteLine("closed");
			//    }
			//}
			//else if (dayOfWeek=="sunday")
			//{
			//    if (hours>=10&&hours<=18)
			//    {
			//        Console.WriteLine("closed");
			//    }

			//}
		}
	}
}