namespace _03.Raiding.Models.Heros
{
    public class Paladin : BaseHero
    {
        private const int Power_Paladin = 100;
        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power => Power_Paladin;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} – {this.Name} healed for {this.Power}";
        }
    }
}
