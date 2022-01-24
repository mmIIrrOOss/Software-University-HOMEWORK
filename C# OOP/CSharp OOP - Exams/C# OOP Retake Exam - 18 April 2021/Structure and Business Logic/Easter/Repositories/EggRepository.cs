namespace Easter.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Easter.Models.Eggs.Contracts;
    using Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.models;

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return this.models.Remove(model);
        }
    }
}
