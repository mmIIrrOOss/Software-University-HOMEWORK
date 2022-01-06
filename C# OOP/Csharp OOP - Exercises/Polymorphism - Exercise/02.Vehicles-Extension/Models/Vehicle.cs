namespace _02.Vehicles_Extension.Models
{
    using System;
    using Common;
    using Models.Contracts;
    public class Vehicle : IDriveEmpty, IRefuel
    {
        private const string SuccessfulyDrivenMESG = "{0} travelled {1} km";
        private double fuelConsumption;
        private double tankCapacity;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumtpion,double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtpion;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                this.fuelConsumption = value;
            }
        }

        public virtual double FuelConsumption 
        { 
            get => this.fuelConsumption; 
            set => this.fuelConsumption = value;
        }
        public virtual double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                this.tankCapacity = value;
            }
        }
        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (this.FuelQuantity <= fuelNeeded)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
            return string.Format(SuccessfulyDrivenMESG, GetType().Name, distance);
        }

        public virtual void Refuel(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new InvalidCastException(ExceptionMessages.NegativeFuel);
            }
            if (fuelQuantity >= this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CanNotFuelFullTank,fuelQuantity));
            }
            this.FuelQuantity += fuelQuantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
