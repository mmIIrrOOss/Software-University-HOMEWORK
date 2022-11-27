using RealEstases.Data;
using RealEstases.Models;
using System;
using System.Linq;

namespace RealEstates.Services
{
    public class TagService : BaseService, ITagService
    {
        private readonly ApplicationDbContext dbContext;

        private readonly IPropertiesService propertiesService;

        public TagService(ApplicationDbContext dbContext, IPropertiesService propertiesService)
        {
            this.dbContext = dbContext;
            this.propertiesService = propertiesService;
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

        public void BulkTagToPropertiesRelation()
        {
            var allProperties = dbContext.Properties.ToList();

            foreach (var property in allProperties)
            {
                var averagePriceForDistrict = this.propertiesService
                    .AveragePerSquareMeter(property.DistrictId);

                if (property.Price >= averagePriceForDistrict)
                {
                    var tag = GetTag("скъп-имот");
                    property.Tags.Add(tag);
                }
                else if (property.Price < averagePriceForDistrict)
                {
                    var tag = GetTag("евтин-имот");
                    property.Tags.Add(tag);
                }


                var currentData = DateTime.Now.AddYears(-15);
                if (property.Year.HasValue && property.Year <= currentData.Year)
                {
                    var tag = GetTag("стар-имот");
                    property.Tags.Add(tag);
                }
                else if (property.Year.HasValue && property.Year > currentData.Year)
                {
                    var tag = GetTag("нов-имот");
                    property.Tags.Add(tag); 
                }


                var averagePropertySize = this.propertiesService
                    .AverageSize(property.DistrictId);

                if (property.Size >= averagePropertySize)
                {
                    var tag = GetTag("голям-имот");
                    property.Tags.Add(tag);
                }
                else if (property.Size < averagePropertySize)
                {
                    var tag = GetTag("малък-имот");
                    property.Tags.Add(tag);
                }



                if (property.Floor.HasValue && property.Floor.Value  == 1)
                {
                    var tag = GetTag("първи-етаж");
                    property.Tags.Add(tag);
                }

                //else if (property.Floor.HasValue && property.Floor.Value >= 7)
                //{
                //    var tag = GetTag("последен-етаж");
                //    property.Tags.Add(tag);
                //}

                else if (property.Floor.HasValue && property.TotalFloors.HasValue 
                    && property.Floor.Value == property.TotalFloors.Value)
                {
                    var tag = GetTag("последен-етаж");
                    property.Tags.Add(tag);
                }
            }

            dbContext.SaveChanges();
        }

        private Tag GetTag(string tagName)
        {
            var tag = dbContext.Tags.FirstOrDefault(x => x.Name == tagName);
            return tag;
        }
    }
}
