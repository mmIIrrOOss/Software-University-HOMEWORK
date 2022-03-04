namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Races.Contracts;

    using System.Linq;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Name == name);
        }
    }
}
