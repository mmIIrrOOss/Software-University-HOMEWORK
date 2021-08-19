using System;

namespace OldestFamilyMember
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			Family family = new Family();
			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				string[] members = Console.ReadLine().Split();
				string name = members[0];
				int age = int.Parse(members[1]);
				family.AddMember(new Person(name, age));
			}
			Console.WriteLine(family.GetOldestMember());
		}
	}
}
