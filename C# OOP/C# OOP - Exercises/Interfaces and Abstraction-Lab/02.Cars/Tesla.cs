

namespace Cars
{
	using System;
	public class Tesla : ICar, IElectircCar
	{
		public Tesla(string model, string color, int batery)
		{
			Model = model;
			Color = color;
			Batery = batery;
		}

		public string Model { get; set; }
		public string Color { get; set; }
		public int Batery { get; set; }

		public void Start()
		{
			Console.WriteLine("Engine start Breaaak!");
		}

		public void Stop()
		{
			
		}
		public override string ToString()
		{
			return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Batery} Batteries";
		}
	}
}
