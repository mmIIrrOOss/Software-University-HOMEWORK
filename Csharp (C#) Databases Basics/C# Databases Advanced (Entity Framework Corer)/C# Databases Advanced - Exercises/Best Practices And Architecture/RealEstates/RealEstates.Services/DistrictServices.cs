using RealEstases.Data;
using RealEstates.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{
    public class DistrictServices : IDistrictService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districts = dbContext.Districts
                              .Select(x => new DistrictInfoDto()
                              {
                                  Name = x.Name,
                                  PropertiesCount = x.Properties.Count(),
                                  AveragePricePerSquareMeter = 
                                             x.Properties
                                             .Where(x => x.Price.HasValue)
                                             .Average(p => p.Price / (decimal)p.Size) ?? 0
                              })
                              .OrderByDescending(x => x.AveragePricePerSquareMeter)
                              .Take(count)
                              .ToList();

            return districts;
        }
    }
}
