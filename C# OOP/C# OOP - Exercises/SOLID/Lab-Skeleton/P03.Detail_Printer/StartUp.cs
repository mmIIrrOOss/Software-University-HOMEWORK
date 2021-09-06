
namespace P03.Detail_Printer
{
	using System;
	using System.Collections.Generic;

	class StartUp
	{
		static void Main(string[] args)
		{
			var employee = new Employee("Employee");
			var manager = new Manager("Manager", new[] { "Doc 1", "Doc 2", "Doc 3" });
			var detailsPrinter = new DetailsPrinter(new List<Employee>(new[] { employee, manager }));
			Console.WriteLine(detailsPrinter.PrintDetails());
		}
	}
}
