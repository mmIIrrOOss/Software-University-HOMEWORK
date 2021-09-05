namespace Raiding
{
	public class Warrior : BaseHero
	{
		private const int warriorPower = 100;
		public Warrior(string name)
		{
			this.Name = name;
		}
		public override string Name { get; set; }
		public override int Power { get => warriorPower; set => this.Power = value; }

		public override string CastAbility()
		{
			return $"Warrior - {this.Name} hit for {this.Power} damage";
		}
	}
}
