namespace AquaShop.Core
{
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using Contracts;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }
            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            if (fishType==nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType==nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            bool fishAndAquariumAreSuitable = false;
            if ((fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium") ||
               (fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium"))
            {
                fishAndAquariumAreSuitable = true;
            }

            if (fishAndAquariumAreSuitable == false)
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            decimal aquariumValue = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration= this.decorations.Models.FirstOrDefault(x => x.GetType().Name == decorationType);
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (decoration==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .InexistentDecoration, decorationType));
            }
            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                result.AppendLine(aquarium.GetInfo());
            }

            return result.ToString().TrimEnd();
        }
    }
}
