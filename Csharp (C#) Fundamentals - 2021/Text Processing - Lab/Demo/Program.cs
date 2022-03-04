using System;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			//string word = "Hello, C#!";
			//string name = Console.ReadLine();
			//string results = word + " " + name;
			//Console.WriteLine(results);


			//string str = new string(new char[] { 'a', 'b', 'c' });
			//Console.WriteLine(str);
			//char []ch = str.ToCharArray();
			//Console.WriteLine(ch);

			//string names = "Miro ";
			//string words = "Hello, C#!";
			//names += words;
			//Console.WriteLine(names)

			//string names = "Miro";
			//string words = "Hello, C#! ";
			//string result = string.Concat(words, names);
			//Console.WriteLine(result);
			string fruits = "banana, apple, orange";
			Console.WriteLine(fruits.LastIndexOf("apple"));
			string id = "10a";
			string power = fruits.Substring(0);
			Console.WriteLine(power);
			bool isValid = fruits.Contains("banana");
			Console.WriteLine(isValid);

		}
	}
}
