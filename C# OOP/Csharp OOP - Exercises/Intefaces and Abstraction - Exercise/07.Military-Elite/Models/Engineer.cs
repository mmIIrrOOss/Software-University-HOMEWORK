namespace _07.Military_Elite.Models
{
    using _07.Military_Elite.Contracts;
    using _07.Military_Elite.Enumerations;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepeair> repeairs;
        public Engineer(int id, string firstName, string lastName,
            decimal salary, string corps)
          : base(id, firstName, lastName, salary, corps)
        {
            this.repeairs = new List<IRepeair>();
        }

        public IReadOnlyCollection<IRepeair> Ripears => (IReadOnlyCollection<IRepeair>)this.repeairs;

        public void AddRepeair(IRepeair repeair)
        {
            this.repeairs.Add(repeair);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Repairs:");
            foreach (var repair in this.repeairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
