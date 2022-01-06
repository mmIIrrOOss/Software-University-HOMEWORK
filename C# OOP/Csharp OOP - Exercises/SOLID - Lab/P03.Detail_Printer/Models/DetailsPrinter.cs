namespace P03.Detail_Printer.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public string PrintDetails()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Employee employee in employees)
            {
                sb.AppendLine(employees.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
