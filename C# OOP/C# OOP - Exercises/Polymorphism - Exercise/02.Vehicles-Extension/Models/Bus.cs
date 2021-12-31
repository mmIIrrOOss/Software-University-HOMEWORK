namespace _02.Vehicles_Extension.Models
{
    using _02.Vehicles_Extension.Models.Contracts;

    public class Bus : Vehicle, IDriveEmpty
    {
        public Bus(double fuelQuantity, double fuelConsumtpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtpion, tankCapacity)
        {
        }
        public override double TankCapacity
        {
            get => base.TankCapacity;
        }
    }
}
