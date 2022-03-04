namespace NeedForSpeed.Models
{
    public class Car : Vehicle
    {
        private const double defaultFuelConsuption = 3;
        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }
        public override double DefaultFuelConsumption => defaultFuelConsuption;

    }
}
