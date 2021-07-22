using System;
using System.Linq;


namespace AddandSubtract
{

	class Program
	{

		private static void Main()
		{
			int number = int.Parse(Console.ReadLine());
			int counter = number;
			for (int i = 1; i <= number; i++)
			{
				if (i < counter)
				{
					Counter(number, counter);
					Console.WriteLine();
				}
				else if (i == counter)
				{
					Counter(number, counter);

				}
			}

		}
		private static void PrintNumber(int number)
		{


			for (int i = 1; i <= number; i++)
			{

				Console.Write(number + " ");

			}
		}
		private static void Counter(int number, int counter)
		{
			for (int i = number; i <= counter; i++)
			{
				PrintNumber(number);
			}
		}



	}
}








