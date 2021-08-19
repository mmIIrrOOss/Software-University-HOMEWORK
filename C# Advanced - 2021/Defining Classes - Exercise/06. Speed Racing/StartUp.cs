using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Speed_Racing
{
	public class StartUp
	{
		public static void Main(string[] args)
		{

			Dictionary<string, Car> cars = new Dictionary<string, Car>();
			int numCar = int.Parse(Console.ReadLine());
			for (int i = 0; i < numCar; i++)
			{
				string[] currentCar = Console.ReadLine().Split();
				string model = currentCar[0];
				int fuelAmmount = int.Parse(currentCar[1]);
				double fuelConsumptionFor1km = double.Parse(currentCar[2]);
				if (!cars.ContainsKey(model))
				{
					Car car = new Car(model, fuelAmmount, fuelConsumptionFor1km);
					cars[car.Model] = car;
				}
			}
			string command;
			while ((command = Console.ReadLine())!="End")
			{
				string[] split = command.Split();
				string model = split[1];
				double ammountOfKm = double.Parse(split[2]);
				KeyValuePair<string, Car> car = cars.FirstOrDefault(x => x.Key == model);
				if (car.Key!=null)
				{
					cars[model].Drive(ammountOfKm);
				}
			}
			Console.WriteLine(string.Join(Environment.NewLine,cars.Values));
		}
	}
}
