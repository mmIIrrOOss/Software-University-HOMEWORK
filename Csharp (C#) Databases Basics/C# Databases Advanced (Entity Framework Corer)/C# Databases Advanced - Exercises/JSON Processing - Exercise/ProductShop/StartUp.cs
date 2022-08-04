using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Datasets.JSONClassConverter;
using ProductShop.DataTransferObject;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            productShopContext.Database.EnsureDeleted();
            productShopContext.Database.EnsureCreated();

            string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            var resultUsers = ImportUsers(productShopContext, inputJsonUsers);
            Console.WriteLine(resultUsers);

            string inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            var resultProducts = ImportProducts(productShopContext, inputJsonProducts);
            Console.WriteLine(resultProducts);

            string inputJsonCategory = File.ReadAllText("../../../Datasets/categories.json");
            var resultCategories = ImportCategories(productShopContext, inputJsonCategory);
            Console.WriteLine(resultCategories);

            string inputJsonCategoryProducts =
                File.ReadAllText("../../../Datasets/categories-products.json");
            var resultCategoryProducts = ImportCategoryProducts(productShopContext, inputJsonCategoryProducts);
            Console.WriteLine(resultCategoryProducts);

            string resultGetProducts = GetProductsInRange(productShopContext);
            Console.WriteLine(resultGetProducts);

            //string resultSoldProducts = GetSoldProducts(productShopContext);
            //Console.WriteLine(resultSoldProducts);

            string resultCategoryInfo = GetCategoriesByProductsCount(productShopContext);
            Console.WriteLine(resultCategoryInfo);

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

            var dtoUsers = JsonConvert.
                DeserializeObject<IEnumerable<UserInputModel>>(inputJsonUser);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJsonProduct)
        {
            InitializeAutoMapper();

            var dtoProducts = JsonConvert.
                DeserializeObject<IEnumerable<ProductInputModel>>(inputJsonProduct);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJsonCategory)
        {
            InitializeAutoMapper();

            var dtoCategories = JsonConvert.
                DeserializeObject<IEnumerable<CategoryInputModel>>(inputJsonCategory);

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJsonProductCategory)
        {
            InitializeAutoMapper();

            var dtoCategoriesProducts = JsonConvert.
                DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJsonProductCategory);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductInfo()
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerFullName = x.Seller.FirstName + x.Seller.LastName
                })
                .OrderBy(x => x.Price)
                .ToList();
            var jsonProduct = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("../../../Datasets/products-in-range.json", jsonProduct);
            return jsonProduct;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsBought.Count >= 1)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new ProductBuyers
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BoughtsProducts = x.ProductsBought
                })
                .ToList();

            var jsonSoldProduct = JsonConvert.SerializeObject(soldProducts);
            File.WriteAllText("../../../Datasets/users-sold-products.json", jsonSoldProduct);
            return jsonSoldProduct;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryInfo = context.Categories
                .OrderBy(x => x.CategoryProducts.Count)
                .Select(x => new CategoryInfo()
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Select(s=>s.Product.Price).Average(),
                    TotalPrice = x.CategoryProducts.Select(s => s.Product.Price).Sum()
                });

            var jsonCategoryInfo = JsonConvert.SerializeObject(categoryInfo, Formatting.Indented);
            File.WriteAllText("../../../Datasets/categories-by-products.json", jsonCategoryInfo);
            return jsonCategoryInfo;
        }

    }
}