namespace Vehicles
{
	public class Truck : Vehicle
	{
		private const double additionalConsumptionPerKm = 1.6;
		private const double refuelingCoefficient = 0.95;
		public Truck(double fuelQuantity, double fuelConsuption) 
			: base(fuelQuantity, fuelConsuption)
		{
		}

		protected override double AditionalConsumption => additionalConsumptionPerKm;
		public override void Refuel(double fuel)
		{
			base.Refuel(fuel * refuelingCoefficient);
		}
	}

}
