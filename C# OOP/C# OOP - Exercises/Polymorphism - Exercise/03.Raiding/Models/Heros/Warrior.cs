namespace _03.Raiding.Models.Heros
{
    public class Warrior : BaseHero
    {
        private const int Power_Warrior = 100;

        public Warrior(string name)
            : base(name)
        {

        }

        public override int Power => Power_Warrior;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} – {this.Name} hit for {this.Power} damage";
        }
    }
}
