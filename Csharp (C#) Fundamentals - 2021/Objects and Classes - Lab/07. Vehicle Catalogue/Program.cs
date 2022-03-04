using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
	class Trucks
	{
		public string BrandsTrucks { get; set; }
		public string ModelTruck { get; set; }
		public double Weight { get; set; }
	}
	class Cars
	{
		public string BrandsCar { get; set; }
		public string ModelCar { get; set; }
		public double HP { get; set; }
	}
	class CatalogForTruckAndCars
	{


	}
	class Program
	{
		static void Main(string[] args)
		{
			List<string> typess = new List<string>();
			List<Cars> carsCatalog = new List<Cars>();
			List<Trucks> trucksCatalog = new List<Trucks>();
			while (true)
			{
				string[] type = Console.ReadLine().Split("/");
				if (type[0] == "end")
				{
					break;
				}
				if (type[0] == "Car")
				{

					Cars car = new Cars();
					{
						car.BrandsCar = type[1];
						car.ModelCar = type[2];
						car.HP = int.Parse(type[3]);
					}
					CatalogForTruckAndCars carsCat = new CatalogForTruckAndCars();
					{
						typess.Add(type[0]);
						carsCatalog.Add(car);
					}

				}
				else if (type[0] == "Truck")
				{
					Trucks truck = new Trucks();
					{
						truck.BrandsTrucks = type[1];
						truck.ModelTruck = type[2];
						truck.Weight = int.Parse(type[3]);
					}
					CatalogForTruckAndCars truckCat = new CatalogForTruckAndCars();
					typess.Add(type[0]);
					trucksCatalog.Add(truck);
				}
			}
			List<Cars> sortedCar = carsCatalog.OrderBy(car => car.BrandsCar).ToList();
			List<Trucks> sortedTrucks = trucksCatalog.OrderBy(truck => truck.BrandsTrucks).ToList();
			if (sortedCar.Count > 0)
			{
				Console.WriteLine($"Cars:");
				foreach (var car in sortedCar)
				{
					Console.WriteLine($"{car.BrandsCar}: {car.ModelCar} - {car.HP}hp");
				}
			}
			if (sortedTrucks.Count > 0)
			{
				Console.WriteLine($"Trucks:");
				foreach (var trucks in sortedTrucks)
				{
					Console.WriteLine($"{trucks.BrandsTrucks}: {trucks.ModelTruck} - {trucks.Weight}kg");
				}
			}
		}
	}
}
