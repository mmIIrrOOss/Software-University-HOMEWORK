namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Utilities.Messages;

    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;
            if (type==nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type==nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarType));
            }
            this.cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar,make,model,VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.Models.FirstOrDefault(x => x.VIN == carVIN);
            if (car==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarCannotBeFound));
            }
            IRacer racer = null;
            if (type==nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type==nameof(StreetRacer))
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerType));
            }
            this.racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = this.racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            IRacer secondRacer = this.racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);
            if (firstRacer==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound,firstRacer));
            }
            else if (secondRacer==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, secondRacer));
            }
            return this.map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in this.racers.Models.OrderByDescending(x=>x.DrivingExperience).ThenBy(x=>x.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
