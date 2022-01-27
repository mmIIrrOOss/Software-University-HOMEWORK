namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Repositories;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Utilities.Messages;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Mission;

    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int countExploredPlanet;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }
            this.astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronauts = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }
            IPlanet planet = this.planets.Models.FirstOrDefault(x => x.Name == planetName);
            IMission mission = new Mission();
            mission.Explore(planet, astronauts);
            this.countExploredPlanet++;
            return string.Format(OutputMessages.PlanetExplored, planetName, astronauts.Count);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.countExploredPlanet} planets were explored!");
            foreach (var astronaut in this.astronauts.Models)
            {
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Name: {astronaut.Name}");
                    sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Name: {astronaut.Name}");
                    sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            this.astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
