using System;
using System.Collections.Generic;

namespace Methods_Dictinary
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Add Methods to Dictionary - Airplanes!");
			Console.WriteLine("Ädded airplanes ....");
			var airplane = new Dictionary<string, int>();
			airplane.Add("Boeing 737", 130);
			airplane.Add("Aribus 320", 150);
			Console.WriteLine("Complete added aiplanes!");
			foreach (var item in airplane.Keys)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
			Console.WriteLine("Remove methods to Dictionay -Airplanes!");
			Console.WriteLine("Removed aiplane........ ");
			airplane.Remove("Boeing 737");
			Console.WriteLine("Removed Boeing 737! ....");
			Console.WriteLine($"Complete remove to Boeing 737 ");
			Console.WriteLine();
			foreach (var item in airplane)
			{
				Console.WriteLine(item.Value);
			}
			Console.WriteLine("Contains methods Dictionary");
			if (airplane.ContainsKey("Airbus A320"))
			{
				Console.WriteLine($"Airbus A320 key exists");
			}
			Console.WriteLine(airplane.ContainsValue(150)); //true
			Console.WriteLine(airplane.ContainsValue(100));
		}
	}
}
