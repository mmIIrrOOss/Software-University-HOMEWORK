

namespace DefiningClasses
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Linq;
	public class Family
	{
		public Family()
		{
			this.People = new List<Person>();
		}
		public List<Person> People { get; set; }
		public void AddMember(Person memmber)
		{
			this.People.Add(memmber);
		}
		public Person GetOldestMember()
			=> this.People.OrderByDescending(a => a.Age).First();
		public Person[] GetPeople()
		{
			var currentPeople = People.Where(x => x.Age > 30)
				.OrderBy(x => x.Name).ToArray();
			return currentPeople;
		}

	}
}
