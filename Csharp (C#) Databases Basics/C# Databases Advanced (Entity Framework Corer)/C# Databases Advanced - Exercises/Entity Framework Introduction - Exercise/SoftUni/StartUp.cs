namespace Entity_Framework_Introduction___Exercise
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Model;
    using System.Globalization;

    public class StartUp
    {

        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var getEmployeesFullInformation = GetEmployeesFullInformation(context);
            var getEmployeesWithSalaryOver50000 = GetEmployeesWithSalaryOver50000(context);
            var getEmployeesFromResearchAndDevelopment = GetEmployeesFromResearchAndDevelopment(context);
            var addNewAddressToEmployee = AddNewAddressToEmployee(context);
            var getEmployeesInPeriod = GetEmployeesInPeriod(context);
            var getAddressesByTown = GetAddressesByTown(context);
            var getEmployee147 = GetEmployee147(context);
            var getDepartmentsWithMoreThan5Employees = GetDepartmentsWithMoreThan5Employees(context);
            var increaseSalaries = IncreaseSalaries(context);
            var getEmployeesByFirstNameStartingWithSa = GetEmployeesByFirstNameStartingWithSa(context);
            var removeTown = RemoveTown(context);

            Console.WriteLine();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName}" +
                    $" {employee.JobTitle} {employee.Salary:f2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName}  {employee.Salary:f2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;

        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
               .Where(x => x.Department.Name == "Research and Development")
               .Select(x => new
               {
                   x.FirstName,
                   x.LastName,
                   x.Salary,
                   DepartmentName = x.Department.Name
               }
               )
               .OrderBy(x => x.Salary)
               .ThenByDescending(x => x.FirstName)
               .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName}  " +
                    $"{employee.LastName} " +
                    $"from {employee.DepartmentName} - " +
                    $"{employee.Salary:f2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(address);
            context.SaveChanges();

            var nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            nakov.AddressId = address.AddressId;
            context.SaveChanges();

            var employees = context.Employees
                .Select
                (x => new
                {
                    x.Address.AddressText,
                    x.Address.AddressId
                }).OrderByDescending(x => x.AddressId).Take(10).ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

         public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeès = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 &&
                                                              x.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EFirstName = x.FirstName,
                    ELastName = x.LastName,
                    MFirstName = x.Manager.FirstName,
                    MLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employeès)
            {
                sb.AppendLine($"{employee.EFirstName} {employee.ELastName} - " +
                    $"Manager: {employee.MFirstName} {employee.MLastName}");
                foreach (var project in employee.Projects)
                {
                    var endDate = project.EndDate.HasValue
                        ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {endDate}");

                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var employeès = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Select(x => new
                {
                    AddressText = x.AddressText,
                    TownName = x.Town.Name,
                    EmployeesCount = x.Employees.Count
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employeès)
            {
                sb.AppendLine($" {employee.AddressText}, {employee.TownName} - {employee.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Select(x => new Employee()
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    EmployeesProjects = x.EmployeesProjects.Select(p => new EmployeeProject()
                    {
                        Project = p.Project
                    })
                    .OrderBy(x => x.Project.Name)
                    .ToList()
                })
                .FirstOrDefault(x => x.EmployeeId == 147);

            var empFirstName = employee.FirstName;
            var empLastName = employee.LastName;
            var emplJobTitle = employee.JobTitle;
            var employeeProjects = employee.EmployeesProjects;

            var sb = new StringBuilder();
            sb.AppendLine($"{empFirstName} {empLastName} - {emplJobTitle}");

            foreach (var projectName in employeeProjects.OrderBy(x => x.Project.Name))
            {
                sb.AppendLine(projectName.Project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Manager.FirstName,
                    x.Manager.LastName,
                    Count = x.Employees.Count(),
                    Employees = x.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.Name} {dep.FirstName} {dep.LastName}");
                foreach (var employee in dep.Employees)
                {
                    sb.AppendLine($" {employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[]
            {
                "Engineering", "Tool Design",
                "Marketing", "Information Services"
            };

            var employees = context.Employees
                .Where(x => departments.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary *= 0.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => EF.Functions.Like(x.FirstName,"sa%"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x=>x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");
            var allAdressIds = context.Employees
                .Select(x => x.AddressId)
                .ToList();

            var employees = context.Employees
               .Where(x => x.AddressId.HasValue && allAdressIds.Contains(x.AddressId.Value))
               .ToList();

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }

            context.SaveChanges();

            foreach (var addressId in allAdressIds)
            {
                var address = context.Addresses
                    . FirstOrDefault(x => x.AddressId == addressId);

                context.Addresses.Remove(address);
            }
            context.Towns.Remove(town);
            context.SaveChanges();

            var returnMessages = $"{allAdressIds.Count} addresses in Seattle were deleted";
            return returnMessages;
        }
    }
}
