namespace Vehicles
{
	using System;
	public class Car : Vehicle
	{
		private const double aditionalConsuptionPerKM = 0.9;

		public Car(double fuelQuantity, double fuelConsuption)
			: base(fuelQuantity, fuelConsuption)
		{
		}

		protected override double AditionalConsumption => aditionalConsuptionPerKM;
	}
}
