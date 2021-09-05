namespace Raiding
{
	using System;
	public class Druid : BaseHero
	{
		private const int druidPower = 80;
		public Druid(string name)
		{
			this.Name = name;
		}
		public override string Name { get; set; }
		public override int Power 
		{
			get => druidPower;
			set
			{
				this.Power = value;
			}
		}

		public override string CastAbility()
		{
			return $"Druid - {this.Name} healed for {this.Power}";
		}
	}
}
