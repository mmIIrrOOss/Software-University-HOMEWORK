namespace NeedForSpeed.Models
{
    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption => base.DefaultFuelConsumption;


    }
}
