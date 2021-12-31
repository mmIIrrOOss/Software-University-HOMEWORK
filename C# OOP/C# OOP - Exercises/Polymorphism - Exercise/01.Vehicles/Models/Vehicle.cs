namespace _01.Vehicles.Models
{
    using System;
    using Common;
    using Contracts;

    public class Vehicle : IDrive, IRefuel
    {
        private const string SUccessfulyDrivenMESG = "{0} travelled {1} km";

        protected Vehicle(double fuelQuantity, double fuelConsumtpion)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtpion;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (this.FuelQuantity <= fuelNeeded)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
            return string.Format(SUccessfulyDrivenMESG, this.GetType().Name, distance);
        }

        public virtual void Refuel(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new InvalidCastException(ExceptionMessages.NegativeFuel);
            }
            this.FuelQuantity += fuelQuantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
