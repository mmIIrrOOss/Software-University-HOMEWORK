using System;

namespace app1
{
	class Program
	{
		static void Main(string[] args)
		{

			double N1 = double.Parse(Console.ReadLine());
			double N2 = double.Parse(Console.ReadLine());
			char operators = char.Parse(Console.ReadLine());
			double sum = 0;
			if (operators == '+')
			{

				sum = N1 + N2;
				if (sum % 2 == 0)
				{
					Console.WriteLine($"{N1} {operators} {N2} = {sum} - even");
				}
				else
				{
					Console.WriteLine($"{N1} {operators} {N2} = {sum} - odd");
				}
			}
			else if (operators == '-')
			{

				sum = N1 - N2;
				if (sum % 2 == 0)
				{
					Console.WriteLine($"{N1} {operators} {N2} = {sum} - even");
				}
				else
				{
					Console.WriteLine($"{N1} {operators} {N2} = {sum} - odd");
				}
			}
			else if (operators == '*')
			{
				sum = N1 * N2;
				if (sum % 2 == 0)
				{
					Console.WriteLine($"{N1} {operators} {N2} = {sum} - even");
				}
				else
				{
					Console.WriteLine($"{N1} {operators} {N2} = {sum} - odd");
				}
			}
			else if (operators == '/')
			{
				if (N1 == 0 || N2 == 0)
				{
					Console.WriteLine($"Cannot divide {N1} by zero");
				}
				else
				{

					sum = N1 * 1.0 / N2;
					Console.WriteLine($"{N1} {operators} {N2} = {sum:f2}");
				}

			}
			else if (operators == '%')
			{
				if (N1 == 0 || N2 == 0)
				{
					Console.WriteLine($"Cannot divide {N1} by zero");
				}
				else
				{

					sum = N1 % N2;
					Console.WriteLine($"{N1} {operators} {N2} = {sum}");
				}
			}


		}
	}
}