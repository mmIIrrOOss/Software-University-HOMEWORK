using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserImportDto, User>().ReverseMap();

            this.CreateMap<ProductImportDto, Product>().ReverseMap();

            this.CreateMap<CategoryImportDto, Category>().ReverseMap();

        }
    }
}
