namespace _07.Military_Elite.Models
{
    using _07.Military_Elite.Contracts;
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id,string firstName,string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Id { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
