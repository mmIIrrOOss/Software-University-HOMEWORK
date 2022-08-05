using AutoMapper;

namespace ProductShop
{

    using ProductShop.DataTransferObject.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();

            this.CreateMap<ProductInputModel, Product>();

            this.CreateMap<CategoryInputModel, Category>();
        }
    }
}
