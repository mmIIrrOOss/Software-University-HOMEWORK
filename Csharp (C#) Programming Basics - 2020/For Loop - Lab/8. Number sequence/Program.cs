using System;


namespace brum
{
	class Program
	{
		static void Main(string[] args)
		{
			int smallTest = int.MinValue;
			int bigTest = int.MaxValue;
			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				int num = int.Parse(Console.ReadLine());
				if (num > smallTest)
				{
					smallTest = num;
				}
				if (num <= bigTest)
				{
					bigTest = num;
				}
			}
			Console.WriteLine($"Max number: {smallTest}");
			Console.WriteLine($"Min number: {bigTest}");
		}
	}
}