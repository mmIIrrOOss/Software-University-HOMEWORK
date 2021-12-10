namespace NeedForSpeed.Models
{
    public class Vehicle
    {

        private int horsePower;
        private double fuel;
        private const double defaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower
        {
            get => horsePower;
            private set => horsePower = value;
        }
        public double Fuel
        {
            get => fuel;
            set => fuel = value;
        }
        public virtual double DefaultFuelConsumption => defaultFuelConsumption;


        public virtual void Drive(double kilometers)
        {
            Fuel -= DefaultFuelConsumption * kilometers;
        }
    }
}
