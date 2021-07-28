using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
	class Song
	{
		public string TypeList { get; set; }
		public string Name { get; set; }
		public string Time { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("asasd");
			int numSongs = int.Parse(Console.ReadLine());
			List<string> songs = new List<string>();
			for (int i = 0; i < numSongs; i++)
			{
				string[] data = Console.ReadLine().Split("_");
				string type = data[0];
				string name = data[1];
				string time = data[2];
				Song song = new Song
				{ 
					TypeList=type,
					Name=name,
					Time=time
				} ;
				Console.WriteLine(string.Join('\n',song));

			}
		}
	}
}
