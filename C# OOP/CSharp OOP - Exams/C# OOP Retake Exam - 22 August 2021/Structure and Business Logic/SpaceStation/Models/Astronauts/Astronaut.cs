namespace SpaceStation.Models.Astronauts
{
    using Contracts;
    using Utilities.Messages;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Models.Bags;

    using System;

    public abstract class Astronaut : IAstronaut
    {
        private const double DecreaseOxygen = 10;

        private string name;
        private double oxygen;

        public Astronaut(string name,double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidAstronautName));
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOxygen));
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath { get; private set; }

        public IBag Bag { get;  private set; }

        public virtual void Breath()
        {
            this.Oxygen -= DecreaseOxygen;
        }
    }
}
