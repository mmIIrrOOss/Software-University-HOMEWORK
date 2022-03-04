namespace _02.VehiclesExtension.Factories
{
    using Models;
    using System;
    using Common;

    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity
            , double fuelConspumption, double tankCpacity, int countOfPassagers = 0)
        {
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConspumption, tankCpacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConspumption, tankCpacity);
            }
            else if (vehicleType == "Bus")
            {
                if (countOfPassagers == 0)
                {
                    vehicle = new Bus(fuelQuantity, fuelConspumption, tankCpacity);
                }
                else
                {
                    vehicle = new Bus(fuelQuantity, fuelConspumption, tankCpacity, countOfPassagers);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicle);
            }
            return vehicle;
        }
    }
}
