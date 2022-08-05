using AutoMapper;

namespace CarDealer
{

    using CarDealer.DTO;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDto, Supplier>();

            this.CreateMap<PartDto, Part>();

            this.CreateMap<CarDto, Car>();

            this.CreateMap<CustomerDto, Customer>();

            this.CreateMap<SaleDto, Sale>();
        
        }
    }
}
