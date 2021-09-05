
namespace VehiclesExtension
{
	using System;
	public abstract class Vehicle
	{

		public Vehicle(double fuelQuantity, double fuelConsuption, double tankCapacity)
		{
			this.FuelQuantity = fuelQuantity;
			this.FuelConsumption = fuelConsuption;
			this.TankCapacity = tankCapacity;
		}



		public virtual double FuelQuantity { get; set; }
		public virtual double FuelConsumption { get; set; }

		public virtual double TankCapacity { get; set; }
		protected abstract double AdditionalConsumption { get; }

		public string Drive(double distance)
		{
			double requiredFuel = (FuelConsumption + AdditionalConsumption) * distance;

			if (requiredFuel <= FuelQuantity)
			{
				FuelQuantity -= requiredFuel;
				return $"{this.GetType().Name} travelled {distance} km";
			}

			return $"{this.GetType().Name} needs refueling";
		}

		public virtual void Refuel(double fuel)
		{
			if (fuel <= 0)
			{
				throw new ArgumentException($"Fuel must be a positive number");
			}

			if (fuel + FuelQuantity > TankCapacity)
			{
				throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
			}

			FuelQuantity += fuel;
		}

		public override string ToString()
		{
			return $"{this.GetType().Name}: {FuelQuantity:F2}";
		}

	}
}
