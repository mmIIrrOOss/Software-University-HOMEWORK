using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Cards_Game
{
	class Program
	{
		static void Main()
		{
			List<int> oneCards = Console.ReadLine().Split().Select(int.Parse).ToList();
			List<int> twoCards = Console.ReadLine().Split().Select(int.Parse).ToList();
			
			while (true)
			{
				int one = oneCards[0];
				int two = twoCards[0];
				if (one>two)
				{
					
					oneCards.Add(one);
					oneCards.Add(two);
					oneCards.Remove(oneCards[0]);
					twoCards.Remove(twoCards[0]);
				}
				else if (two>one)
				{
					
					twoCards.Add(twoCards[0]);
					twoCards.Add(oneCards[0]);
					oneCards.Remove(oneCards[0]);
					twoCards.Remove(twoCards[0]);
				}
				else if (one==two)
				{
					oneCards.Remove(oneCards[0]);
					twoCards.Remove(twoCards[0]);
				}
				if (oneCards.Count==0||twoCards.Count==0)
				{
					break;
				}
			}
			int sumOne = oneCards.Sum();
			int sumTwo = twoCards.Sum();
			if (oneCards.Count>twoCards.Count)
			{
				Console.WriteLine($"First player wins! Sum: {sumOne}");
			}
			else
			{
				Console.WriteLine($"Second player wins! Sum: {sumTwo}");

			}
		}
	}
}
