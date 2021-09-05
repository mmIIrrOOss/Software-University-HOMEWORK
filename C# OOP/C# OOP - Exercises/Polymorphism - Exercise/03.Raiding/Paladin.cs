namespace Raiding
{
	public class Paladin : BaseHero
	{
		private const int paladinPower = 100;
		public Paladin(string name)
		{
			this.Name = name;
		}
		public override string Name  { get; set; }
		public override int Power { get => paladinPower; set => this.Power = value; }

		public override string CastAbility()
		{
			return $"Paladin - {this.Name} healed for {this.Power}";
		}

		
	}
}
