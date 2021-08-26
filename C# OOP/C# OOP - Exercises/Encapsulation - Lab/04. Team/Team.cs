

namespace PersonsInfo
{
	using System;
	using System.Collections.Generic;
	public class Team
	{
		public Team(string name)
		{
			this.Name = name;
			this.firstTeam = new List<Person>();
			this.reserveTeam = new List<Person>();
		}
		private string name;
		private List<Person> firstTeam;
		private List<Person> reserveTeam;

		public string Name { get => name; set => name = value; }
		public IReadOnlyCollection<Person> FirstTeam { get => firstTeam.AsReadOnly(); }
		public IReadOnlyCollection<Person> ReserveTeam { get => reserveTeam.AsReadOnly(); }
		public void AddPlayer(Person person)
		{
			if (person.Age < 40)
			{
				this.reserveTeam.Add(person);
			}
			else
			{
				this.firstTeam.Add(person);
			}
		}
	}
}
