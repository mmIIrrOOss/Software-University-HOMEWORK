using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
	class Messages
	{
		public List<string> Phrase { get; set; }
		public List<string> Event { get; set; }
		public List<string> Author { get; set; }
		public List<string> City { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			Messages phrase = new Messages();
			int numRandoms = int.Parse(Console.ReadLine());
			phrase.Phrase = new List<string>
			{ "Excellent product.",
				"Such a great product.",
				"I always use that product.",
				"Best product of its category.",
				"Exceptional product.",
				"I can’t live without this product"
			};
			Messages @event = new Messages();
			@event.Event = new List<string>
			{
				"Now I feel good.",
				"I have succeeded with this product.",
				"Makes miracles.",
				"I am happy of the results!",
				"I cannot believe but now I feel awesome",
				"Try it yourself",
				"I am very satisfied.",
				"I feel great!"
			};
			Messages author = new Messages();
			author.Author = new List<string>
			{
				"Diana",
				"Petya",
				"Stella",
				"Elena",
				"Katya",
				"Iva",
				"Annie",
				"Eva"
			};
			Messages city = new Messages();
			city.City = new List<string>
			{
				"Burgas",
				"Sofia",
				"Plovdiv",
				"Varna",
				"Ruse"
			};
			for (int i = 0; i < numRandoms; i++)
			{
				Random rnd = new Random(numRandoms);
				var randomSave=rnd.Next(i);
				Console.WriteLine($"{phrase.Phrase[i]} {@event.Event[i]} {author.Author[i]} - {city.City[i]}");
			}
		}
	}
}
