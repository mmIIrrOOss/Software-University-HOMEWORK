
namespace _07.Military_Elite.Models
{
    using _07.Military_Elite.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission>  missions;


        public Commando(int id, string firstName, string lastName,
            decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Missions:");
            foreach (var missio in this.missions)
            {
                sb.AppendLine($"  {missio.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
