using System;
using System.Linq;


namespace PasswordValidator
{

	class Program
	{

		private static void Main(string[] args)
		{
			string password = Console.ReadLine();
			char[] savePass = new char[password.Length];
			int count = 0;
			ChekNumsDigit(password);
			CheckingCharacters(password, savePass);
			CheckNumbers(savePass, count);

		}
		private static void ChekNumsDigit(string password)
		{
			if (!(password.Length >= 6 && password.Length <= 10))
			{

				Console.WriteLine("Password must be between 6 and 10 characters");
			}
		}
		private static void CheckingCharacters(string password, char[] savePass)
		{

			for (int i = 0; i < password.Length; i++)
			{
				int intSymbolValue = Convert.ToInt32(password[i]);
				if ((intSymbolValue >= 48 && intSymbolValue <= 57) || (intSymbolValue >= 65
					&& intSymbolValue <= 90) || (intSymbolValue >= 97 && intSymbolValue <= 122))
				{
					savePass[i] = password[i];
				}
				else
				{
					Console.WriteLine("Password must consist only of letters and digits");
					break;
				}

			}
		}
		private static void CheckNumbers(char[] savePass, int count)
		{
			for (int i = 0; i < savePass.Length; i++)
			{
				char[] numsZeroToNine = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
				foreach (var characters in numsZeroToNine)
				{
					if (savePass[i] == characters)
					{
						count++;

					}
				}
			}

			PassValidator(count);
		}
		private static void PassValidator(int count)
		{
			if (count >= 2)
			{
				Console.WriteLine("Password is valid");

			}
			else
			{
				Console.WriteLine("Password must have at least 2 digits");
			}
		}
	}
}

