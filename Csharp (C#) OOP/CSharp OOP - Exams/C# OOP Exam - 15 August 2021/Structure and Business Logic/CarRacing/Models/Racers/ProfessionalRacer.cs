namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const int DrivingExperience = 30;
        private const string RacingBehaivior = "strict";

        public ProfessionalRacer(string username, ICar car)
            : base(username, RacingBehaivior, DrivingExperience, car)
        {
        }

    }
}
