namespace _03.Raiding.Core
{
    using System;
    using Models;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;

    public class Engine : IEngine
    {
        private FactoryPattern factoryPattern;
        public Engine()
        {
            this.factoryPattern = new FactoryPattern();
        }

        public void Run()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());

            while (heroes.Count != numberOfHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = this.factoryPattern.ProduceHero(heroName, heroType);
                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPowerSum = 0;

            if (heroes.Any())
            {
                foreach (var hero in heroes)
                {
                    Console.WriteLine(hero.CastAbility());
                    heroesPowerSum += hero.Power;
                }
                if (heroesPowerSum > bossPower)
                {
                    Console.WriteLine("Victory!");
                }
                else
                {
                    Console.WriteLine("Defeat...");
                }
            }
        }
    }
}
