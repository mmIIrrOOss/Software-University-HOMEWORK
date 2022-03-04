namespace WarCroft.Entities.Characters
{
    using System;

    using Contracts;
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;

    public class Warrior : Character, IAttacker
    {

        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double abilityPoint = 40;

        public Warrior(string name) 
            : base(name, baseHealth, baseArmor, abilityPoint,new Satchel())
        {
        }

        public virtual void Attack(Character character)
        {
            if (this.Name == character.Name)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterAttacksSelf));
            }
            this.EnsureAlive();
            if (character.IsAlive == true)
            {
                character.TakeDamage(this.AbilityPoints);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.AffectedCharacterDead));
            }
        }
    }
}
