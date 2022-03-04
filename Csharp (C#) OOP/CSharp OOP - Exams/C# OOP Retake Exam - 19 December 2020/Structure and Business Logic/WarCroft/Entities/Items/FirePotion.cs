namespace WarCroft.Entities.Items
{
    using Constants;
    using WarCroft.Entities.Characters.Contracts;

    public class FirePotion : Item
    {
        private const int FirePotionPotionWight = 5;

        public FirePotion()
            : base(FirePotionPotionWight)
        {
        }

        public double HealthPoint { get; private set; }

        public override void AffectCharacter(Character character)
        {
            character.IsAlive = true;
            if (this.HealthPoint <= 0)
            {
                character.IsAlive = false;
            }
            this.HealthPoint -= 20;
        }
    }
}
