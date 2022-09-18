using System.Collections.Generic;

using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IDistrictService
    {
        IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count);
    }
}
