using System;
using System.Linq;


namespace AddandSubtract
{

	class Program
	{

		private static void Main()
		{
			string command = string.Empty;
			while ((command = Console.ReadLine()) != "END")
			{
				bool isIsPalindrom = ReturnIsPalindrom(command);
				if (isIsPalindrom)
				{
					Console.WriteLine("true");
				}
				else
				{
					Console.WriteLine("false");
				}
			}
		}

		static bool ReturnIsPalindrom(string commmand)
		{
			int number = int.Parse(commmand);
			bool result = false;
			if (number >= 0 && number <= 9)
			{
				result = true;
			}
			else
			{
				for (int i = 0; i < commmand.Length / 2; i++)
				{
					if (commmand[i] == commmand[commmand.Length - 1])
					{
						result = true;
					}
					else
					{
						break;
					}
				}
			}
			return result;
		}
	}
}








