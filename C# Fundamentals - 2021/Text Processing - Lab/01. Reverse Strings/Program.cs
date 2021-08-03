using System;
using System.Linq;
using System.Text;

namespace _01._Reverse_Strings
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "end")
				{
					break;
				}
				string save = command;
				char[] reverse = command.Reverse().ToArray();
				Console.WriteLine($"{save} = {string.Join("",reverse)}");
			}

		}
	}
}
