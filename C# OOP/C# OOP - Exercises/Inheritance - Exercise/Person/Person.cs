

namespace Person
{
	
	using System.Text;
	public class Person
	{
		public Person(string name, int age)
		{
			this.Name = name;
			this.Age = age;
		}
		public string Name { get { return this.name; } set { this.name = value; } }
		public int Age
		{
			get
			{
				return this.age;
			}
			set
			{
				if (value > 0)
				{
					this.age = value;
				}
			}
		}

		private string name;
		private int age;
		public override string ToString()
		{
			StringBuilder str = new StringBuilder();
			str.Append(string.Format($"Name: {this.name}, Age: {this.age}"));
			return str.ToString().TrimEnd();
		}




	}
}
