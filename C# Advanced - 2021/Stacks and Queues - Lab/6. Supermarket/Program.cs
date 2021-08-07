using System;
using System.Collections.Generic;
namespace _6._Supermarket
{
	class Program
	{
		static void Main(string[] args)
		{
			Queue<string> client = new Queue<string>();
			while (true)
			{
				string nameClient = Console.ReadLine();
				if (nameClient == "End")
				{
					break;
				}
				else if (nameClient == "Paid")
				{
					while (client.Count > 0)
					{
						Console.WriteLine(client.Dequeue());
					}
				}
				else
				{
					client.Enqueue(nameClient);
				}
			}
			Console.WriteLine(client.Count + " people remaining.");
		}
	}
}
