
namespace ManufacturingPhones
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	public class StratUp
	{
		public static void Main()
		{
			string[] phoneNumbers = Console.ReadLine().Split();
			string[] webSites = Console.ReadLine().Split();
			StationaryPhone stationary = new StationaryPhone();
			Smartphone smartphone = new Smartphone();
			for (int i = 0; i < phoneNumbers.Length; i++)
			{
				try
				{
					if (phoneNumbers[i].Length == 7)
					{
						Console.WriteLine(stationary.Call(phoneNumbers[i]));
					}
					else if (phoneNumbers[i].Length == 10)
					{
						Console.WriteLine(smartphone.Call(phoneNumbers[i]));
					}
					else
					{
						throw new InvalidPhoneNumberException();
					}
				}
				catch (InvalidPhoneNumberException phoneNumOpe)
				{

					Console.WriteLine(phoneNumOpe.Message);
				}
				
			}
			for (int i = 0; i < webSites.Length; i++)
			{
				try
				{
					Console.WriteLine(smartphone.Browse(webSites[i]));
				}
				catch (InvalidURLEception url)
				{
					Console.WriteLine(url.Message);
				}
			}

		}
	}
}
