namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double FuelAvaliable = 80;
        private const double FuelConsumptionPeeRace = 10;

        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, FuelAvaliable, FuelConsumptionPeeRace)
        {
        }

        public override void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}
