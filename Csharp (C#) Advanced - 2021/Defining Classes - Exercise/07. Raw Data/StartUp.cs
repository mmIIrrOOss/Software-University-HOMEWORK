using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Raw_Data
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			List<Car> saveCar = new List<Car>();
			int n = int.Parse(Console.ReadLine());
			while (n-- > 0)
			{
				string[] carInfo = Console.ReadLine().Split();
				string model = carInfo[0];
				int engineSpeed = int.Parse(carInfo[1]);
				int enginePower = int.Parse(carInfo[2]);
				int cargoWeight = int.Parse(carInfo[3]);
				string cargoType = carInfo[4];
				string[] tiresData = new string[8]
			    {
					carInfo[5],  carInfo[6],
					carInfo[7],  carInfo[8],
					carInfo[9],  carInfo[10],
				 	carInfo[11], carInfo[12]
			    };
				Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tiresData);
				saveCar.Add(car);
			}
			string command = Console.ReadLine();
			switch (command)
			{
				case "fragile":
					Console.WriteLine(String.Join(Environment.NewLine, saveCar.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))));
					break;

				case "flamable":
					Console.WriteLine(String.Join(Environment.NewLine, saveCar.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)));
					break;

				default:
					break;
			}
		}
	}
}

