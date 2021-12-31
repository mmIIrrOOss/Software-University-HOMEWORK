namespace _02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double Increase_Fuel = 0.9;
        public Car(double fuelQuantity, double fuelConsumtpion,double tankCapacity)
            : base(fuelQuantity, fuelConsumtpion,tankCapacity)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + Increase_Fuel;
    }
}
