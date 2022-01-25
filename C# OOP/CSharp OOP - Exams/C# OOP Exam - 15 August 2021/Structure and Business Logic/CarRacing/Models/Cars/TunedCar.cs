namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double FuelAvaliable = 65;
        private const double FuelConsuptionPerRace = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, FuelAvaliable, FuelConsuptionPerRace)
        {
        }

        public override void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
            int result =(int)Math.Round(this.HorsePower * 0.3);
            this.HorsePower -= result;
        }
    }
}
