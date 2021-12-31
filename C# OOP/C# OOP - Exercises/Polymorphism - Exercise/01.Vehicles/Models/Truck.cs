namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelIncrement = 1.6;
        private const double RefuelLoose = 0.95;
        public Truck(double fuelQuantity, double fuelConsumtpion)
            : base(fuelQuantity, fuelConsumtpion)
        {

        }
        public override double FuelConsumption => base.FuelConsumption + FuelIncrement;

        public override void Refuel(double fuelQuantity)
        {
            base.Refuel(fuelQuantity * RefuelLoose);
        }
    }
}
