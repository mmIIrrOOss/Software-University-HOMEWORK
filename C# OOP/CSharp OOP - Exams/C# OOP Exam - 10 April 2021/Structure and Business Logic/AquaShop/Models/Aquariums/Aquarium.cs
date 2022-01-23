namespace AquaShop.Models.Aquariums
{
    using Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        public Aquarium(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get;  }

        public ICollection<IFish> Fish { get;  }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == Capacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughCapacity));
            }
            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            foreach (var fishh in this.Fish)
            {
                if (fishh == null)
                {
                    sb.AppendLine("Fish: none");
                    sb.AppendLine("Decorations: 0");
                    sb.AppendLine("Comfort: 0");
                }
                else
                {
                    sb.AppendLine($"Fish: {fishh.Name}");
                    sb.AppendLine($"Decorations: {this.Decorations.Count}");
                    sb.AppendLine($"Comfort: {this.Comfort}");
                }
            }
            return sb.ToString().TrimEnd();
        }


    }
}
