using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
	public class Car
	{
		public string Model { get; set; }
		public Engine Engine { get; set; }
		public Cargo Cargo { get; set; }
		public Tire[] Tires { get; set; }

		public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, string[] tiresData)
		{
			this.Model = model;
			this.Engine = new Engine(engineSpeed,enginePower);
			this.Cargo = new Cargo(cargoWeight,cargoType);
			this.Tires = new Tire[4]
			{
				new Tire(double.Parse(tiresData[0]), int.Parse(tiresData[1])),
				new Tire(double.Parse(tiresData[2]), int.Parse(tiresData[3])),
				new Tire(double.Parse(tiresData[4]), int.Parse(tiresData[5])),
				new Tire(double.Parse(tiresData[6]), int.Parse(tiresData[7]))
			};
		}
		public override string ToString()
		{
			return $"{this.Model}";
		}
	}
}
