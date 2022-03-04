using System;
using System.Collections.Generic;
namespace _06._Parking_Lot
{
	class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> saveCarNum = new HashSet<string>();
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "END")
				{
					break;
				}
				string[] split = command.Split(", ");
				string inOut = split[0];
				if (inOut == "IN")
				{
					string carNumber = split[1];
					saveCarNum.Add(carNumber);
				}
				else
				{
					saveCarNum.Remove(split[1]);
				}
			}
			if (saveCarNum.Count > 0)
			{
				foreach (var item in saveCarNum)
				{
					Console.WriteLine(item);
				}
			}
			else
			{
				Console.WriteLine("Parking Lot is Empty");
			}
		}
	}
}
