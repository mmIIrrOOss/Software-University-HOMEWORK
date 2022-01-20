namespace EasterRaces.Models.Cars.Entities
{
    using Contracts;
    using Utilities.Messages;

    using System;

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int maxHorsePower;
        private int minHorsePower;

        public Car(string model,int horsePower,double cubicCentimeters,
            int minHorsePower,int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                this.model = value;
            }
        }

        public  int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (!(value >= this.minHorsePower && value <= this.maxHorsePower))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public  double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            double result = this.CubicCentimeters / this.HorsePower * laps;
            return result;
        }
    }
}
