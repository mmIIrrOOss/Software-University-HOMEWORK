namespace WarCroft.Entities.Items
{
    using Entities.Characters.Contracts;

    public class HealthPotion : Item
    {
        private const int HealthPotionWight = 5;
        

        public HealthPotion()
            : base(HealthPotionWight)
        {
        }

        public double HealthPoint { get; private set; }

        public override void AffectCharacter(Character character)
        {
            character.IsAlive = true;
            this.HealthPoint += 20;
        }
    }
}
