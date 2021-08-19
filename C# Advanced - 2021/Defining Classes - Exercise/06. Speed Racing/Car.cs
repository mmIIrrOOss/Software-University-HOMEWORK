using System;
namespace _06._Speed_Racing
{
	public class Car
	{
		public string Model { get; set; }
		public double FuelAmmount { get; set; }
		public double FuelConsumptionPerKilometer { get; set; }
		public double TravelledDistance { get; set; }
		
		public Car(string model, double fuelAmmount , double perKilometer)
		{
			this.Model = model;
			this.FuelAmmount = fuelAmmount;
			this.FuelConsumptionPerKilometer = perKilometer;
			this.TravelledDistance = 0;
		}
		public void Drive(double distance)
		{
			if (this.FuelConsumptionPerKilometer*distance<=this.FuelAmmount)
			{
				this.FuelAmmount -= this.FuelConsumptionPerKilometer * distance;
				TravelledDistance += distance;
			}
			else
			{
				Console.WriteLine("Insufficient fuel for the drive");
			}
		}
		public override string ToString()
		{
			return $"{this.Model} {this.FuelAmmount:f2} {this.TravelledDistance}";
		}

	}
}
