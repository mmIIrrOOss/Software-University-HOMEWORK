namespace P03.Detail_Printer.Models
{
    using Constrains;

    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
