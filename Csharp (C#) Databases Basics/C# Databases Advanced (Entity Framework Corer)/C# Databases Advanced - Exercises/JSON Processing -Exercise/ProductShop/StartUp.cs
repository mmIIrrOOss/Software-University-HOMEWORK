using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;

namespace ProductShop
{

    using ProductShop.Data;
    using ProductShop.DataTransferObject.Export;
    using ProductShop.DataTransferObject.Import;
    using ProductShop.Models;

    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            productShopContext.Database.EnsureDeleted();
            productShopContext.Database.EnsureCreated();

            string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            string resultUsers = ImportUsers(productShopContext, inputJsonUsers);
            Console.WriteLine(resultUsers);

            string inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            string resultProducts = ImportProducts(productShopContext, inputJsonProducts);
            Console.WriteLine(resultProducts);

            string inputJsonCategory = File.ReadAllText("../../../Datasets/categories.json");
            string resultCategories = ImportCategories(productShopContext, inputJsonCategory);
            Console.WriteLine(resultCategories);

            string inputJsonCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            string resultCategoryProducts = ImportCategoryProducts(productShopContext, inputJsonCategoryProducts);
            Console.WriteLine(resultCategoryProducts);

            string resultGetProducts = GetProductsInRange(productShopContext);
            Console.WriteLine(resultGetProducts);

            string resultSoldProducts = GetSoldProducts(productShopContext);
            Console.WriteLine(resultSoldProducts);

            string resultCategoryInfo = GetCategoriesByProductsCount(productShopContext);
            Console.WriteLine(resultCategoryInfo);

            string resultUsersProducts = GetUsersWithProducts(productShopContext);
            Console.WriteLine(resultUsersProducts);

        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }

        public static string ImportUsers(ProductShopContext context, string inputJsonUser)
        {
            InitializeAutoMapper();

            IEnumerable<UserInputModel> dtoUsers = JsonConvert.
                DeserializeObject<IEnumerable<UserInputModel>>(inputJsonUser);

            IEnumerable<User> users = mapper.Map<IEnumerable<User>>(dtoUsers);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJsonProduct)
        {
            InitializeAutoMapper();

            IEnumerable<ProductInputModel> dtoProducts = JsonConvert.
                DeserializeObject<IEnumerable<ProductInputModel>>(inputJsonProduct);

            IEnumerable<Product> products = mapper.Map<IEnumerable<Product>>(dtoProducts);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJsonCategory)
        {
            InitializeAutoMapper();

            IEnumerable<CategoryInputModel> dtoCategories = JsonConvert.
                DeserializeObject<IEnumerable<CategoryInputModel>>(inputJsonCategory);

            IEnumerable<Category> categories = mapper.Map<IEnumerable<Category>>(dtoCategories);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJsonProductCategory)
        {
            InitializeAutoMapper();

            IEnumerable<CategoryProduct> dtoCategoriesProducts = JsonConvert.
                DeserializeObject<IEnumerable<CategoryProduct>>(inputJsonProductCategory);

            IEnumerable<CategoryProduct> categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            List<ProductExportDto> products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductExportDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Seller.FirstName} {x.Seller.LastName}".Trim()
                })
                .OrderBy(x => x.Price)
                .ToList();
            string jsonProduct = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("../../../Datasets/products-in-range.json", jsonProduct);
            return jsonProduct;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            List<UserExportDto> soldProducts = context.Users
                .Where(x => x.ProductsBought.Count >= 1)
                .Select(x => new UserExportDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select(ps => new SoldProductDto()
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                            BuyerFirstName = ps.Buyer.FirstName,
                            BuyerLastName = ps.Buyer.LastName
                        })
                        .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList();

            string jsonSoldProduct = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
            File.WriteAllText("../../../Datasets/users-sold-products.json", jsonSoldProduct);
            return jsonSoldProduct;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            CategoryExportDto[] categoryInfo = context.Categories
                .OrderBy(x => x.CategoryProducts.Count)
                .Select(x => new CategoryExportDto()
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Select(cp => cp.Product).Count(),
                    AveragePrice = x.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderBy(c => c.Category)
                .ToArray();

            string jsonCategoryInfo = JsonConvert.SerializeObject(categoryInfo, Formatting.Indented);
            File.WriteAllText("../../../Datasets/categories-by-products.json", jsonCategoryInfo);
            return jsonCategoryInfo;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            UserAllDto user = new UserAllDto()
            {
                UserCount = context.Users.Count(us => us.ProductsSold.Count >= 1),
                Users = context
                   .Users
                   .Where(u => u.ProductsSold.Count >= 1)
                   .OrderByDescending(u => u.ProductsSold.Count)
                   .Select(u => new UserProductDto()
                   {
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Age = u.Age,
                       SoldProducts = new ProductSoldDto()
                       {
                           Count = u.ProductsSold.Count,
                           Products = u.ProductsSold
                               .Select(p => new ProductAllDto()
                               {
                                   Name = p.Name,
                                   Price = p.Price
                               })
                               .ToArray()
                       }
                   })
                   .ToArray()
            };

            string jsonString = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText("../../../Files/Export/users-and-products.json", jsonString);

            return jsonString;
        }
    }
}