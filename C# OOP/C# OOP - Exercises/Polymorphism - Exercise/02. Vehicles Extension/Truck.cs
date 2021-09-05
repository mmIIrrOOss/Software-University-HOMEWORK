
namespace VehiclesExtension
{
	using System;
	public class Truck : Vehicle
	{
		private const double additionalConsumptionPerKm = 1.6;
		private const double refuelingCoefficient = 0.95;

		public Truck(double fuelQuantity, double fuelConsuption, double tankCapacity)
			: base(fuelQuantity, fuelConsuption, tankCapacity)
		{
		}

		protected override double AdditionalConsumption => additionalConsumptionPerKm;
		public override void Refuel(double fuel)
		{
			base.Refuel(fuel);
			this.FuelQuantity -= (1 - refuelingCoefficient) * fuel;
		}


	}
}

