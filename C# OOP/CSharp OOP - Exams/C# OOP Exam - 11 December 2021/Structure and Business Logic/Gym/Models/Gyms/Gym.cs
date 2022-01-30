namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Utilities.Messages;
    using Equipment.Contracts;
    using global::Gym.Models.Athletes.Contracts;

    public abstract class Gym : IGym
    {
        private string name;
        private double equipmentWeight;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;


        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidGymName));
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get=>this.equipmentWeight;
            private set
            {
                foreach (var item in this.Equipment)
                {
                    if (item.Weight != 0 && item != null)
                    {
                        value += item.Weight;
                    }
                }
                this.equipmentWeight = value;
            }
        }

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughSize));
            }
            this.athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            foreach (var athlete in this.Athletes)
            {
                sb.AppendLine(athlete.FullName);
            }
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }
    }
}
