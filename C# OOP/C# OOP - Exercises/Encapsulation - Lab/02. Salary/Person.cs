

namespace PersonsInfo
{
	using System.Text;
	public class Person
	{
		public Person(string fistName, string lastName, int age, decimal salary)
		{
			this.FirstName = fistName;
			this.LastName = lastName;
			this.Age = age;
			Salary = salary;
		}
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public int Age { get; private set; }
		public decimal Salary { get; private set; }
		public void IncreaseSalary(decimal percentage)
		{
			if (Age > 30)
			{
				this.Salary += this.Salary * percentage / 100;
			}
			else
			{
				this.Salary += this.Salary * percentage / 200;
			}
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.");
			return sb.ToString().TrimEnd();
		}
	}
}
