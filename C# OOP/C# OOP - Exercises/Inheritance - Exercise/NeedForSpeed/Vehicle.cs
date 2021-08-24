

namespace NeedForSpeed
{
	using System;
	public class Vehicle
	{
		public Vehicle(int horsePower, double fuel)
		{
			this.HorsePower = horsePower;
			this.Fuel = fuel;
		}

		const double DefaultFuelConsumption = 1.25;
		public int HorsePower { get; set; }
		public double Fuel { get; set; }
		public virtual double FuelConsumption => DefaultFuelConsumption;


		public virtual void Drive(double kilometers)
		{
			this.Fuel -= kilometers * this.FuelConsumption;
		}
	}
}
