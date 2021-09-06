
namespace P03.Detail_Printer
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	public class Employee
	{
		public Employee(string name)
		{
			this.Name = name;
		}

		public string Name { get; private set; }

		public override string ToString() => this.Name;
	}
}
