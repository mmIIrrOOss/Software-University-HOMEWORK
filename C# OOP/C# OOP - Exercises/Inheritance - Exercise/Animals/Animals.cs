

namespace Animals
{
	using System;
	using System.Text;

	public abstract class Animals:ISoundProducable
	{

		private string name;
		private int age;
		private string gender;
		public Animals(string name, int age, string gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}
		public virtual string Name
		{
			get => name;
			set
			{
				if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Invalid input!");
				}
				this.name = value;
			}
		}
		public virtual int Age
		{
			get => age;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Invalid input!");
				}
				this.age = value;
			}
		}

		public string Gender
		{
			set
			{
				Gender genders;
				if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || !Enum.TryParse<Gender>(value, out genders))
				{
					throw new ArgumentException("Invalid input!");
				}

				this.gender = value;
			}
		}
		public virtual string ProduceSound()
		{
			return null;
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(this.GetType().Name);
			sb.AppendLine($"{this.name} {this.age} {this.gender}");
			sb.AppendLine(this.ProduceSound());
			return sb.ToString().TrimEnd();
		}

	}
}
