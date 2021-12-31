namespace _02.VehiclesExtension.Models
{
    using System;
    using Common;

    public class Bus : Vehicle
    {
        private const double Increase_Fuel = 1.4;

        public Bus(double fuelQuantity, double fuelConsumtpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtpion, tankCapacity)
        {

        }
        public Bus(double fuelQuantity, double fuelConsumtpion,
            double tankCapacity, int countOfPassagers)
            : this(fuelQuantity, fuelConsumtpion, tankCapacity)
        {
            this.CountOfPassagers = countOfPassagers;
        }

        public int CountOfPassagers { get; private set; }

        public override string Drive(double distance)
        {
            if (this.CountOfPassagers > 0)
            {
                this.FuelConsumption += Increase_Fuel;
                return base.Drive(distance);
            }
            else
            {
                return base.Drive(distance);
            }
        }

    }
}
