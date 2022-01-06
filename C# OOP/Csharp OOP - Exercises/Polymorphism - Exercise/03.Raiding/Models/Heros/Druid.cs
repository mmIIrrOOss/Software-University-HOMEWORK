namespace _03.Raiding.Models.Heros
{
    public class Druid : BaseHero
    {
        private const int Power_Druid = 80;
        public Druid(string name)
            : base(name)
        {

        }

        public override int Power => Power_Druid;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} – {this.Name} healed for {this.Power}";
        }
    }
}
