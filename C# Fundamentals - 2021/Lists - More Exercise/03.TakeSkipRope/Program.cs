using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkipRope
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			List<int> numbers = new List<int>();
			List<string> noonNumbers = new List<string>();

			List<int> take = new List<int>();
			List<int> skip = new List<int>();

			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsDigit(text[i]))
				{
					string num = text[i].ToString();
					numbers.Add(int.Parse(num));
				}
				else
				{
					noonNumbers.Add(text[i].ToString());
				}

			}
			for (int i = 0; i < numbers.Count; i++)
			{
				if (i % 2 == 0)
				{
					take.Add(numbers[i]);
				}
				else
				{
					skip.Add(numbers[i]);
				}
			}
			int indexSkip = 0;
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < take.Count; i++)
			{
				List<string> temp = new List<string>(noonNumbers);
				temp = temp.Skip(indexSkip).Take(take[i]).ToList();
				result.Append(string.Join("", temp));
				indexSkip+=take[i]+skip[i];
			}
			Console.WriteLine(result.ToString());

		}
	}
}
