namespace Gym.Models.Athletes
{
    using System;

    using Utilities.Messages;

    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;
        private const int IncreaseStamina = 10;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
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
