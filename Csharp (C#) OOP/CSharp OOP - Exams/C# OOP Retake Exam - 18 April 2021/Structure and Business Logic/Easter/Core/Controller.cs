namespace Easter.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops;
    using Easter.Models.Workshops.Contracts;
    using Easter.Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidBunnyType));
            }
            this.bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentBunny));
            }
            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded,eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg currentEgg = eggs.FindByName(eggName);
            IWorkshop workshop = new Workshop();

            var selectBunnyies = this.bunnies.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy).ToList();

            if (selectBunnyies.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.BunniesNotReady));
            }
            while (selectBunnyies.Count > 0)
            {
                IBunny currentBunny = selectBunnyies.First();
                while (true)
                {
                    if (currentBunny.Energy == 0 || currentBunny.Dyes.All(x => x.IsFinished()))
                    {
                        selectBunnyies.Remove(currentBunny);
                        break;
                    }

                    workshop.Color(currentEgg, currentBunny);

                    if (currentEgg.IsDone())
                    {
                        break;
                    }
                }

                if (currentEgg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(currentEgg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{eggs.Models.Count(e => e.IsDone())} eggs are done!");
            result.AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");
                result.AppendLine($"Dyes: {bunny.Dyes.Count(d => d.IsFinished() == false)} not finished");
            }

            return result.ToString().TrimEnd();
        }
    }
}
