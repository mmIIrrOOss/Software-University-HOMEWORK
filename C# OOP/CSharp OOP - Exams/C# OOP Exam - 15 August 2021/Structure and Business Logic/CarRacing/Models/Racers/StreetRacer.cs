namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int DrivinfExperience = 10;
        private const string RacingBihaivior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, RacingBihaivior, DrivinfExperience, car)
        {

        }
    }
}
