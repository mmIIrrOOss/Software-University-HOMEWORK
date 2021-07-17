using System;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{

			long lines = int.Parse(Console.ReadLine());
			long leftSum = 0;
			long rightSum = 0;
			long sumElement = 0;
			for (int i = 0; i < lines; i++)
			{
				string[] numbers = Console.ReadLine().Split();
				string leftElement = numbers[0].ToString();
				string rightElement = numbers[1].ToString();
				leftSum = long.Parse(leftElement);
				rightSum = long.Parse(rightElement);
				long leftNum = Math.Abs(leftSum);
				string leftN = leftNum.ToString();
				long rightNum = Math.Abs(rightSum);
				string rightN = rightNum.ToString();
				if (leftSum > rightSum)
				{
					for (int j = 0; j < leftN.Length; j++)
					{
						string getElement = leftN[j].ToString();
						long parseElement = long.Parse(getElement);
						sumElement += parseElement;
					}
					Console.WriteLine(sumElement);
					sumElement = 0;
				}
				else
				{
					for (int j = 0; j < rightN.Length; j++)
					{
						string getElement = rightN[j].ToString();
						long parseElement = long.Parse(getElement);
						sumElement += parseElement;
					}
					Console.WriteLine(sumElement);
					sumElement = 0;
				}

			}


		}


	}
}
