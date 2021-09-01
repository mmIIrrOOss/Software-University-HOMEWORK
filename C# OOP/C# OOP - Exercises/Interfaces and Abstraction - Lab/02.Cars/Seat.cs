

namespace Cars
{
	using System;
	public class Seat : ICar
	{
		public Seat(string model, string color)
		{
			this.Model = model;
			this.Color = color;
		}
		public string Model { get ; set ; }
		public string Color { get ; set ; }

		public void Start()
		{
			Console.WriteLine("Engine start Breaaak!");
		}

		public void Stop()
		{

		}
		public override string ToString()
		{
			return $"{this.Color} {this.GetType().Name} {this.Model}";
		}
	}
}
