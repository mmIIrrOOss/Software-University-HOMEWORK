namespace _01.Vehicles.Core
{
    using System;
    using Models;
    using Contracts;
    using Factories;
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                string type = args[0];
                string vehicleType = args[1];
                double distanceKm = double.Parse(args[2]);
                try
                {
                    if (type == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, distanceKm);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, distanceKm);
                        }
                    }
                    else if (type == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, distanceKm);
                        }
                        if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, distanceKm);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
               
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
        private void Refuel(Vehicle vehicle,double fuelQuantity)
        {
            vehicle.Refuel(fuelQuantity);
        }
        private void Drive(Vehicle vehicle,double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }
        private Vehicle ProcessVehicleInfo()
        {
            string[] args = Console.ReadLine().Split();
            string vehicleType = args[0];
            double fuelQyantity = double.Parse(args[1]);
            double fuelConspumption = double.Parse(args[2]);
            Vehicle currentVehicle = this.vehicleFactory.
                CreateVehicle(vehicleType, fuelQyantity, fuelConspumption);
            return currentVehicle;
        }
       
    }
}
