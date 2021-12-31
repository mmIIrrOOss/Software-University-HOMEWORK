namespace _02.VehiclesExtension.Models
{
    using System;
    using Common;
    using Contracts;

    public class Vehicle : IDrive, IRefuel
    {
        private const string SUccessfulyDrivenMESG = "{0} travelled {1} km";
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumtpion, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtpion;
            this.TankCpacity = tankCapacity;
        }

        public virtual double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; set; }

        public virtual double TankCpacity { get; set; }

        public virtual string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (this.FuelQuantity <= fuelNeeded)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.NotEnoughFuel, GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
            return string.Format(SUccessfulyDrivenMESG, GetType().Name, distance);
        }

        public virtual void Refuel(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new InvalidCastException(ExceptionMessages.NegativeFuel);
            }
            if (fuelQuantity > this.TankCpacity)
            {
                throw new Exception(string.Format(ExceptionMessages.CannotFitFuelTheTank, fuelQuantity));
            }
            this.FuelQuantity += fuelQuantity;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
