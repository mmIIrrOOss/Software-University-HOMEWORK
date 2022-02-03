namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                this.captain = value;
            }
        }

        public  double ArmorThickness { get; set; }

        public  double MainWeaponCaliber { get; set; }

        public  double Speed { get; set; }

        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            this.ArmorThickness -= target.MainWeaponCaliber;
            if (this.ArmorThickness < 0)
            {
                this.ArmorThickness = 0;
            }
            this.Targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" -{this.Name}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"Speed: {this.Speed} knots");
            if (this.Targets.Count == 0)
            {
                sb.AppendLine($"Targets: None");
            }
            else
            {
                sb.AppendLine($"Targets: {string.Join(", ", this.Targets)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
