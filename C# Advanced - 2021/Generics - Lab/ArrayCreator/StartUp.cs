using System;

namespace GenericArrayCreator
{
	public class StartUp
	{
		static void Main(string[] args)
		{

			Console.WriteLine(string.Join(", ",ArrayCreator.Create(10,"pesho")));
		}
	}
}
