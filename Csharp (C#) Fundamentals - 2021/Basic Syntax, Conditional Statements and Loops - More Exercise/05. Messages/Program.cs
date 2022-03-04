using System;
using System.Linq;
class Vacation
{
	static void Main()
	{
		int number = int.Parse(Console.ReadLine());
		string messages = "";
		for (int i = 1; i <= number; i++)
		{
			int num = int.Parse(Console.ReadLine());
			if (num == 2)
			{
				messages += 'a';
			}
			else if (num == 22)
			{
				messages += 'b';
			}
			else if (num == 222)
			{
				messages += 'c';
			}
			if (num == 3)
			{
				messages += 'd';
			}
			else if (num == 33)
			{
				messages += 'e';
			}
			else if (num == 333)
			{
				messages += 'f';
			}
			if (num == 4)
			{
				messages += 'g';
			}
			else if (num == 44)
			{
				messages += 'h';
			}
			else if (num == 444)
			{
				messages += 'i';
			}
			if (num == 5)
			{
				messages += 'j';
			}
			else if (num == 55)
			{
				messages += 'k';
			}
			else if (num == 555)
			{
				messages += 'l';
			}
			if (num == 6)
			{
				messages += 'm';
			}
			else if (num == 66)
			{
				messages += 'n';
			}
			else if (num == 666)
			{
				messages += 'o';
			}
			if (num == 7)
			{
				messages += 'p';
			}
			else if (num == 77)
			{
				messages += 'q';
			}
			else if (num == 777)
			{
				messages += 'r';
			}
			if (num == 7777)
			{
				messages += 's';
			}
			else if (num == 8)
			{
				messages += 't';
			}
			else if (num == 88)
			{
				messages += 'u';
			}
			else if (num == 888)
			{
				messages += 'v';
			}
			else if (num == 9)
			{
				messages += 'w';
			}
			else if (num == 99)
			{
				messages += 'x';
			}
			else if (num == 999)
			{
				messages += 'y';
			}
			else if (num == 9999)
			{
				messages += 'z';
			}
			else if (num == 0)
			{
				messages += " ";
			}
		}
		Console.WriteLine(messages);
	}
}