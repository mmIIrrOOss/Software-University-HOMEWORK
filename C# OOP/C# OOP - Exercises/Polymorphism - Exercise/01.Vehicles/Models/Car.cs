namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FuelInrement = 0.9;
        public Car(double fuelQuantity, double fuelConsumtpion)
            : base(fuelQuantity, fuelConsumtpion)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + FuelInrement;
    }
}
