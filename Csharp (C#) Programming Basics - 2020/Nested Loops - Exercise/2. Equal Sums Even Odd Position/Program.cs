using System;


namespace NestedLoopsLab
{
	class Program
	{
		static void Main(string[] args)
		{

			int firstNumber = int.Parse(Console.ReadLine());
			int secondNumber = int.Parse(Console.ReadLine());
			for (int i = firstNumber; i <= secondNumber; i++)
			{
				string current = i.ToString();
				int oddSum = 0;
				int evenSum = 0;
				for (int j = 0; j < current.Length; j++)
				{

					int currentDigit = int.Parse(current[j].ToString());
					if (j % 2 == 0)
					{
						evenSum += currentDigit;
					}
					else
					{
						oddSum += currentDigit;
					}
				}
				if (evenSum == oddSum)
				{
					Console.Write(i + " ");
				}
			}
		}
	}
}

