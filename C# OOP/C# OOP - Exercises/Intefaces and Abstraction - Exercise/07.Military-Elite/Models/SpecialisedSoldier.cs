
namespace _07.Military_Elite.Models
{
    using _07.Military_Elite.Contracts;
    using _07.Military_Elite.Enumerations;
    using _07.Military_Elite.Exceptions;
    using System;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,
            string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string strCorps)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(strCorps, out corps);
            if (!parsed)
            {
                throw new InvalidCorpsException();
            }
            return corps;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
