namespace _03.Raiding.Models.Heros
{
    public class Rogue : BaseHero
    {
        private const int Power_Rogue = 80;
        public Rogue(string name) 
            : base(name)
        {

        }

        public override int Power => Power_Rogue;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} – {this.Name} hit for {this.Power} damage";
        }
    }
}
