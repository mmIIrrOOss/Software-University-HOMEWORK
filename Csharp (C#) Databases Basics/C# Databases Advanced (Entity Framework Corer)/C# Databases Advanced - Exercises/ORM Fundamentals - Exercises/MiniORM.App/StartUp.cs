namespace MiniORM.App
{
    using System.Linq;

    using Data;
    using Data.Entities;

    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=MiniORM;Integrated Security=true";
            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add
            (
                new Employee
                {
                    FirstName = "Gosho",
                    LastName = "Inserted",
                    DepartmentId = context.Departments.First().Id,
                    IsEmployeed = true
                }
            );

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
