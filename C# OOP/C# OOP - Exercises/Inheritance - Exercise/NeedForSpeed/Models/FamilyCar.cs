using NeedForSpeed.Models;

namespace NeedForSpeed
{
    public class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption => base.DefaultFuelConsumption;

        
    }
}
