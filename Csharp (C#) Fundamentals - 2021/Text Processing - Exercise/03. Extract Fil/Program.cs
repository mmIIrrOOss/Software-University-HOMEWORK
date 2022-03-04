using System;
using System.Linq;
namespace _03._Extract_File
{
	class Program
	{
		static void Main(string[] args)
		{
			string searchFile = Console.ReadLine();
			string[] split = searchFile.Split("\\");
			char point = '.';
			string random = split[split.Length - 1];
			int index = random.IndexOf('.');
			string fileName = random.Substring(0, index);
			string extensions = random.Substring(index+1);
			Console.WriteLine($"File name: {fileName}");
			Console.WriteLine($"File extension: {extensions}");
		}
	}
}
