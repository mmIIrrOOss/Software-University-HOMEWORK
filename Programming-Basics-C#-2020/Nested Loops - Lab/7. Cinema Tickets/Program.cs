using System;


namespace NestedLoopsLab
{
	class Program
	{
		static void Main(string[] args)
		{

			double sumTickets = 0;
			double studentsTicket = 0;
			double standrardsTicket = 0;
			double kidsTicket = 0;
			double allTickets = 0;
			while (true)
			{
				string filmName = Console.ReadLine();
				if (filmName == "Finish")
				{
					break;
				}
				double freeSpace = int.Parse(Console.ReadLine());
				int counter = 0;
				while (true)
				{
					string typeTickets = Console.ReadLine();
					if (typeTickets == "End")
					{
						break;
					}
					else if (typeTickets == "standard")
					{
						standrardsTicket++;

					}
					else if (typeTickets == "student")
					{
						studentsTicket++;

					}
					else if (typeTickets == "kid")
					{
						kidsTicket++;

					}
					counter++;
					if (counter == freeSpace)
					{
						break;
					}
				}
				double filmPercent = counter * 1.0 / freeSpace * 100;
				Console.WriteLine($"{filmName} - {filmPercent:f2}% full.");
			}
			double allSumTicket = standrardsTicket + studentsTicket + kidsTicket;
			double studentPercent = studentsTicket * 1.0 / allSumTicket * 100;
			double standardPercent = standrardsTicket * 1.0 / allSumTicket * 100;
			double kidsPercent = kidsTicket * 1.0 / allSumTicket * 100;
			Console.WriteLine($"Total tickets: {allSumTicket}");
			Console.WriteLine($"{studentPercent:f2}% student tickets.");
			Console.WriteLine($"{standardPercent:f2}% standard tickets.");
			Console.WriteLine($"{kidsPercent:f2}% kids tickets.");



		}
	}
}


