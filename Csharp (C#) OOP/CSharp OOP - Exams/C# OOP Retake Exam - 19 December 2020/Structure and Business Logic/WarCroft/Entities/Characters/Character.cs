namespace WarCroft.Entities.Characters.Contracts
{
    using System;

    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;
    using WarCroft.Entities.Items;

    public abstract class Character
    {
        string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor,
            double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }


        public  double BaseHealth { get;  }

        public  double BaseArmor { get; }

        public  double Armor  { get; private set; }

        public  double AbilityPoints { get; private set; }

        public  bool IsAlive { get; set; } = true;

        public  Bag Bag { get; set; }

        public virtual double Health { get;   set; }

        public  string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameInvalid));
                }
                this.name = value;
            }
        }


        //Example: Health: 100, Armor: 30, Hit Points: 40  Health: 90, Armor: 0
        public virtual void TakeDamage(double hitPoints)//40
        {
            EnsureAlive();

            this.Armor -= hitPoints;
            if (this.Armor < 0)
            {
                hitPoints = Math.Abs(this.Armor);
                this.Armor = 0;
                this.Health -= hitPoints;
            }

            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

    }
}