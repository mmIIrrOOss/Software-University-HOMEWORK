using System;

namespace AgeandGender
{
	class Program
	{
		static void Main(string[] args)
		{
			double age = double.Parse(Console.ReadLine());
			string genfer = Console.ReadLine();
			if (genfer == "f")
			{
				if (age < 16)
				{
					Console.WriteLine("Miss");
				}
				else
				{
					Console.WriteLine("Ms.");
				}
			}
			else
			{
				if (age < 16)
				{
					Console.WriteLine("Master");
				}
				else
				{
					Console.WriteLine("Mr.");
				}

			}
		}
	}
}
