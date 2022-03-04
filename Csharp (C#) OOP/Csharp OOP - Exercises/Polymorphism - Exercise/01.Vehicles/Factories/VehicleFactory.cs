namespace _01.Vehicles.Factories
{
    using Models;
    using System;
    using Common;
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }
        public Vehicle CreateVehicle(string vehicleType,double fuelQuantity
            ,double fuelConspumption)
        {
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConspumption);
            }
            else if (vehicleType =="Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConspumption);
            }
            else
            {
               throw new InvalidOperationException(ExceptionMessages.InvalidVehicle);
            }
            return vehicle;
        } 
    }
}
