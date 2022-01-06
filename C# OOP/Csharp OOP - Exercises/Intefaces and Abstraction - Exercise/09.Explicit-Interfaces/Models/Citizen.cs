namespace _09.Explicit_Interfaces.Models
{
    using Intefaces;

    public class Citizen : IPerson, IResident
    {
        public Citizen(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
