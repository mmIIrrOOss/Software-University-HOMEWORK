using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Store_Boxes
{
	class Box
	{
		public string NameArticul { get; set; }
		public double Price { get; set; }
		public string SerialNumber { get; set; }
		public int Quantity { get; set; }

	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Box> saveBoxInfoArticuls = new List<Box>();
			while (true)
			{
				string[] infoArticul = Console.ReadLine().Split();
				if (infoArticul[0] == "end")
				{
					break;
				}
				string serialNumberArticul = infoArticul[0];
				string nameArticul = infoArticul[1];
				int quantityArticuls = int.Parse(infoArticul[2]);
				double priceArticul = double.Parse(infoArticul[3]);
				Box boxing = new Box();
				{
					boxing.SerialNumber = serialNumberArticul;
					boxing.NameArticul = nameArticul;
					boxing.Quantity = quantityArticuls;
					boxing.Price = priceArticul;
				}
				saveBoxInfoArticuls.Add(boxing);
			}
			List<Box> sortedBox = saveBoxInfoArticuls.OrderBy(boxes => boxes.Price*boxes.Quantity).ToList();
			sortedBox.Reverse();
			foreach (Box boxes in sortedBox)
			{
				Console.WriteLine($"{boxes.SerialNumber}");
				Console.WriteLine($"-- {boxes.NameArticul} - ${boxes.Price:f2}: {boxes.Quantity}");
				Console.WriteLine($"-- ${(boxes.Price * boxes.Quantity):f2}");
			}
		}
	}
}
