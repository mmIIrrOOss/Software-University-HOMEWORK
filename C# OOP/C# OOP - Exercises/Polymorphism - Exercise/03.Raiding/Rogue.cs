namespace Raiding
{
	public class Rogue : BaseHero
	{
		private const int roguePower = 80;
		public Rogue(string name)
		{
			this.Name = name;
		}
		public override string Name { get; set; }
		public override int Power { get => roguePower; set => this.Power = value; }

		public override string CastAbility()
		{
			return $"Rogue - {this.Name} hit for {this.Power} damage";
		}
	}
}
