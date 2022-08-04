using AutoMapper;
using ProductShop.Datasets.JSONClassConverter;
using ProductShop.DataTransferObject;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();

            this.CreateMap<ProductInputModel, Models.Product>();

            this.CreateMap<CategoryInputModel, Category>();

            this.CreateMap<CategoryProductInputModel, CategoryProduct>();

            this.CreateMap<Product, Product>();
        }
    }
}
