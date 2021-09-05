namespace Vehicles
{
	public abstract class Vehicle
	{

		public Vehicle(double fuelQuantity,double fuelConsuption)
		{
			this.FuelQuantity = fuelQuantity;
			this.FuelConsumption = fuelConsuption;
		}
		public virtual double FuelQuantity { get; set; }
		public virtual double FuelConsumption { get; set; }

		protected abstract double AditionalConsumption { get;  }

		public string Drive(double distance)
		{
			double riquriedFuel = (this.FuelConsumption + this.AditionalConsumption) * distance;
			if (riquriedFuel <= this.FuelQuantity)
			{
				this.FuelQuantity -= riquriedFuel;
				return $"{this.GetType().Name} travelled {distance} km";
			}
			return $"{this.GetType().Name} needs refueling";
		}
		public virtual void Refuel(double fuel)
		{
			this.FuelQuantity += fuel;
		}
		public override string ToString()
		{
			return $"{this.GetType().Name}: {FuelQuantity:F2}";
		}


	}
}
