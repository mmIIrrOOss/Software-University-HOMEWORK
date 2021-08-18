
using System;
using System.Text;


namespace CarManufacturer
{
	public class Car
	{

		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public double FuelQuantity { get; set; }
		public double FuelConsumption { get; set; }
		public void Drive(double distance)
		{
			var neededFuel = distance - this.FuelConsumption;
			bool canContiniue = this.FuelQuantity - (distance * this.FuelConsumption) >= 0;
			if (canContiniue)
			{
				this.FuelQuantity -= distance * this.FuelConsumption;
			}
			else
			{
				Console.WriteLine("Not enough fuel to perform this trip!");
			}
		}
		public string GetSpecifications()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Make: {this.Make}");
			sb.AppendLine($"Model: {this.Model}");
			sb.AppendLine($"Year: {this.Year}");
			sb.Append($"Fuel: {this.FuelQuantity:F2}L");
			return sb.ToString();
		}


	}
}
