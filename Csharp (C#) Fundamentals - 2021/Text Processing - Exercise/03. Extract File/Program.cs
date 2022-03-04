using System;
using System.Linq;
namespace _03._Extract_File
{
	class Program
	{
		static void Main(string[] args)
		{
			string searchFile = Console.ReadLine();
			string[] split = searchFile.Split();
			string extentions = split[split.Length - 1];
			int index = split.Length - 1 - 1;
			string fileName = split[index-1];
			Console.WriteLine(fileName);
		}
	}
}
