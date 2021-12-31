namespace _03.Raiding.Models
{
    using Constrains;

    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public virtual string Name { get; private set; }

        public virtual int Power { get; private set; }

        public abstract string CastAbility();
    }
}
