

namespace OldestFamilyMember
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
		public List<Person> People{ get; set; }
		public void AddMember(Person memmber)
		{
			this.People.Add(memmber);
		}
		public Person GetOldestMember()
		{
			return this.People.OrderByDescending(a => a.Age).FirstOrDefault();
		}
	}
}
