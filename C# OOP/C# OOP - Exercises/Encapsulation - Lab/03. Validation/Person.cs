

namespace PersonsInfo
{
	using System;
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
		public string FirstName
		{
			get => firstName;
			set
			{
				if (value.Length <= 2)
				{
					throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
				}
				this.firstName = value;
			}
		}
		public string LastName
		{
			get => lastName;
			set
			{
				if (value.Length <= 2)
				{
					throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
				}
				this.lastName = value;
			}
		}
		public int Age
		{
			get => this.age;
			set
			{
				if (value <= 0 || value == null)
				{
					throw new ArgumentException("Age cannot be zero or a negative integer!");
				}
				this.age = value;
			}
		}
		public decimal Salary
		{
			get => salary;
			set
			{
				if (value <= 459)
				{
					throw new ArgumentException("Salary cannot be less than 460 leva!");
				}
				this.salary = value;
			}

		}
		private int age;
		private string firstName;
		private string lastName;
		private decimal salary;

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
