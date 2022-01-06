namespace NeedForSpeed.Models
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption => base.DefaultFuelConsumption;


    }
}
