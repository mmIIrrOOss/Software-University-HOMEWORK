using AutoMapper;

namespace CarDealer
{

    using CarDealer.Models;
    using CarDealer.DTO.Export;
    using CarDealer.DTO.Import;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierImportDto, Supplier>();

            this.CreateMap<PartImportDto, Part>();

            this.CreateMap<CarImportDto, Car>();

            this.CreateMap<CustomerImportDto, Customer>();

            this.CreateMap<SaleImportDto, Sale>();

            this.CreateMap<Car, CarExportDto>();
        }
    }
}
