namespace EasterRaces.Core.Entities
{
    using Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.drivers.GetByName(driverName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (this.cars.GetByName(carModel) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            ICar car = this.cars.GetByName(carModel);
            IDriver driver = this.drivers.GetByName(driverName);
            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded,driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.races.GetByName(raceName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (this.drivers.GetByName(driverName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            IRace race = this.races.GetByName(raceName);
            race.AddDriver(this.drivers.GetByName(driverName));
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            ICar car = type == "Sports" ? car = new SportsCar(model, horsePower)
                : car = new MuscleCar(model, horsePower);
            this.cars.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            IDriver driver = new Driver(driverName);
            this.drivers.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            IRace race = new Race(name, laps);
            this.races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (this.races.GetByName(raceName) is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            IRace race = this.races.GetByName(raceName);
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }
            List<IDriver> currentDrivers = race.Drivers.OrderByDescending(x =>
            x.Car.CalculateRacePoints(race.Laps)).ToList();
            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {currentDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {currentDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {currentDrivers[2].Name} is third in {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
