namespace CarRacing.Models.Racers
{
    using System;

    using CarRacing.Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private string userName;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get => this.userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerName));
                }
                this.userName = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerBehavior));
                }
                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerDrivingExperience));
                }
                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerCar));
                }
                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            return this.Car.FuelAvailable > 0;
        }

        public void Race()
        {
            if (nameof(ProfessionalRacer) == "ProfessionalRacer")
            {
                this.DrivingExperience += 10;
            }
            else
            {
                this.DrivingExperience += 5;
            }
        }
    }
}
