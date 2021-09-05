namespace VehiclesExtension
{
	using System;
	public class Car : Vehicle
	{
		private const double aditionalConsuptionPerKM = 0.9;

		

		public Car(double fuelQuantity, double fuelConsuption, double tankCapacity) 
			: base(fuelQuantity, fuelConsuption, tankCapacity)
		{
		}

		
		protected override double AdditionalConsumption => aditionalConsuptionPerKM;

		
		
	}
}
