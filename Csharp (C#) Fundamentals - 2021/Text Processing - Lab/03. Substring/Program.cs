using System;
using System.Linq;
namespace _03._Substring
{
	class Program
	{
		static void Main(string[] args)
		{

			string [] word = Console.ReadLine().Split(", ");
			string text = Console.ReadLine();
			foreach (var item in word)
			{
				if (text.Contains(item))
				{
					text = text.Replace(item, new string('*', item.Length));
				}
			}
			Console.WriteLine(text);
		}
	}
}
