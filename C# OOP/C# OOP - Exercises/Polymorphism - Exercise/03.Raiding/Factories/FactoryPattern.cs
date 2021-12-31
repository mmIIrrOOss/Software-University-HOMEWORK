namespace _03.Raiding.Factories
{
    using Models;
    using Models.Heros;
    using ExceptionMessages;
    using System;

    public class FactoryPattern
    {

        public BaseHero ProduceHero(string heroName,string heroType)
        {
            BaseHero hero = null;
            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }
            else
            {
                Console.WriteLine(ExceptionMessages.InvalidHero);
            }
            return hero;
        }
    }
}
