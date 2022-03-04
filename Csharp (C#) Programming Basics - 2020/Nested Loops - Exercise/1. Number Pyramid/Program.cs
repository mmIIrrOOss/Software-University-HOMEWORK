using System;


namespace NestedLoopsLab
{
	class Program
	{
		static void Main(string[] args)
		{

			int num = int.Parse(Console.ReadLine());
			int current = 1;
			bool isBigger = false;
			for (int rows = 1; rows <= num; rows++)
			{
				for (int coloumns = 1; coloumns <= rows; coloumns++)
				{

					if (current > num)
					{
						isBigger = true;
						break;
					}
					Console.Write(current + " ");
					current++;
				}
				if (isBigger)
				{
					break;
				}
				Console.WriteLine();
			}



		}
	}
}


