namespace _02.Vehicles_Extension.Models
{
    public class Truck : Vehicle
    {
        private const double FuelIncrement = 1.6;
        private const double RefuelLoose = 0.95;

        public Truck(double fuelQuantity, double fuelConsumtpion, double tankCapacity) 
            : base(fuelQuantity, fuelConsumtpion, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + FuelIncrement;

        public override void Refuel(double fuelQuantity)
        {
            base.Refuel(fuelQuantity * RefuelLoose);
        }
    }
}
