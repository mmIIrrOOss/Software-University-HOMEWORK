using RealEstases.Data;
using RealEstases.Models;
using System;

namespace RealEstates.Services
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext dbContext;

        public TagService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(string name, int? importance = null)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };

            this.dbContext.Tags.Add(tag);
            this.dbContext.SaveChanges();
        }

        public void BulkTagProperties()
        {
            throw new NotImplementedException();
        }
    }
}
