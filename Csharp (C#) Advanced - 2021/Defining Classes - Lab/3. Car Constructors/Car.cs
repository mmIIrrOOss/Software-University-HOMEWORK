
namespace CarManufacturer
{
	public class Car
	{
		private string make;
		private string model;
		private int year;
		private double fuelQuantity;
		private double fuelConsumptions; 
		public Car()
		{
			this.Make = "VW";
			this.Model = "Golf";
			this.Year = 2025;
			this.FuelQuantity = 200;
			this.FuelConsumption = 10;
		}
		public Car(string make, string model, int year) : this()
		{
			this.Make = make;
			this.Model = model;
			this.Year = year;
		}
		public Car(string make, string model, int year, double fuelQuantity, double fuelConsumptions)
			: this(make, model, year)
		{
			this.FuelQuantity = fuelQuantity;
			this.FuelConsumption = fuelConsumptions;
		}
		public string Make
		{
			get { return this.make; }
			private set { this.make = value; }
		}

		public string Model
		{
			get { return this.model; }
			private set { this.model = value; }
		}

		public int Year
		{
			get { return this.year; }
			private set { this.year = value; }
		}

		public double FuelQuantity
		{
			get { return this.fuelQuantity; }
			private set { this.fuelQuantity = value; }
		}

		public double FuelConsumption
		{
			get { return this.fuelConsumptions; }
			private set { this.fuelConsumptions = value; }
		}
	}
}
