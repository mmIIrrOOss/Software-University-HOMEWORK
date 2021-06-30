using System;

namespace _7._Projects_Creation
{
	class Program
	{
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			int numProjects = int.Parse(Console.ReadLine());
			int hoursCompleteProjects = numProjects * 3;
			Console.WriteLine($"The architect {name} will need {hoursCompleteProjects} hours to complete { numProjects} project/s.");
		}
	}
}
