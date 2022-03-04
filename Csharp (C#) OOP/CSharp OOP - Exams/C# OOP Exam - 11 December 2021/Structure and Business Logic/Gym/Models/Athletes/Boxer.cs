namespace Gym.Models.Athletes
{
    using Gym.Utilities.Messages;

    using System;

    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;
        private const int IncreaseStamina = 15;
        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            if (this.Stamina > 100)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStamina));
            }
            this.Stamina += IncreaseStamina;
        }
    }
}
