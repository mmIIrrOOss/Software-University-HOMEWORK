
namespace Raiding
{
	public abstract class BaseHero
	{
		public virtual string Name { get; set; }
		public virtual int Power { get; set; }
		public abstract string CastAbility();
	}
}
