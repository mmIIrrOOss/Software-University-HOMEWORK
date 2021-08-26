

namespace PersonsInfo
{
	using System.Text;
	public class Person
	{
		public Person(string fistName,string lastName,int age)
		{
			this.FirstName = fistName;
			this.LastName = lastName;
			this.Age = age;
		}
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public int Age { get; private set; }
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.FirstName} {this.LastName} is {this.Age} years old.");
			return sb.ToString().TrimEnd();
		}
	}
}
