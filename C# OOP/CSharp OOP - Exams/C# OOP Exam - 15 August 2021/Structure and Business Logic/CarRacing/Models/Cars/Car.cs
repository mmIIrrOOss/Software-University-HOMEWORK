namespace CarRacing.Models.Cars
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelConsumptionPerRace;
        private double fuelAvaliable;
        public Car(string make,string model,string vin,int horsePower
            ,double fuelAvaliable,double fuelConsuptionRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvaliable;
            this.FuelConsumptionPerRace = fuelConsuptionRace;
        }

        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarMake));
                }
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarModel));
                }
                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarVIN));
                }
                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarHorsePower));
                }
                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvaliable;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.fuelAvaliable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarFuelConsumption));
                }
                this.fuelConsumptionPerRace = value;
            }
        }

        public abstract void Drive();
    }
}
