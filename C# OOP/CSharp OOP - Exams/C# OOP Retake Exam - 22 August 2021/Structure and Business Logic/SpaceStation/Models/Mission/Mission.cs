namespace SpaceStation.Models.Mission
{
    using Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets.Contracts;

    using System.Collections.Generic;

    public class Mission : IMission
    {
        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> items = new List<string>();

            foreach (var astronaut in astronauts)
            {
                foreach (var item in planet.Items)
                {
                    if (astronaut.Oxygen <= 0)
                    {
                        break;
                    }
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    items.Add(item);
                }
                foreach (var item in items)
                {
                    planet.Items.Remove(item);
                }
            }
        }
    }
}
