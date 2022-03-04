namespace NavalVessels.Models
{
    using Contracts;

    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<IVessel> vessels;

        public Captain(string fullNmae)
        {   
            this.FullName = fullNmae;
            this.vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                this.fullName = value;
            }
        }

        public int CombatExperience
        {
            get => this.combatExperience;
            private set
            {
                this.combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel is null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");
            sb.AppendLine(base.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
