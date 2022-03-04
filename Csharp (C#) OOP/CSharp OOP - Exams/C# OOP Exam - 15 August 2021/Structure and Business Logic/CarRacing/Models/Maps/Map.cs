namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using Contracts;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string result = string.Empty;
            if (racerOne == null && racerTwo == null)
            {
                result = string.Format(OutputMessages.OneRacerIsNotAvailable);
            }
            else if (racerOne == null || racerTwo == null)
            {
                result = string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else
            {
                racerOne.Car.Drive();
                racerTwo.Car.Drive();
                double firstMultiply = racerOne.RacingBehavior == "strict" ? firstMultiply = 1.2 : 1.1;
                double secondMultiply = racerTwo.RacingBehavior == "strict" ? secondMultiply = 1.2 : 1.1;
                double firstChanceOneOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * firstMultiply;
                double secondChanceOneOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * secondMultiply;
                string winner = firstChanceOneOfWinning > secondChanceOneOfWinning ? racerOne.Username : racerTwo.Username;
                result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
            }
            return result;
        }
    }
}
