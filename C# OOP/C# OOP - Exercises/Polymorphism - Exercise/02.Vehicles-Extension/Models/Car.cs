namespace _02.Vehicles_Extension.Models
{
    public class Car : Vehicle
    {
        private const double FuelInrement = 0.9;

        public Car(double fuelQuantity, double fuelConsumtpion, double tankCapacity) 
            : base(fuelQuantity, fuelConsumtpion, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + FuelInrement;
    }
}
