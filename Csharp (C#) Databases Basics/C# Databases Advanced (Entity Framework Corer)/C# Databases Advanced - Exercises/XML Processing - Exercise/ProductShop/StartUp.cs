using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AutoMapper;

using System.Xml.Serialization;

using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.Dtos.Export;

namespace ProductShop
{
   

    public class StartUp
    {
        private const string Import_Users_Path_Xml = "../../../Datasets/Import/users.xml";
        private const string Import_Products_Path_Xml = "../../../Datasets/Import/products.xml";
        private const string Import_Categories_Path_Xml = "../../../Datasets/Import/categories.xml";
        private const string Import_Categories_Products_Path_Xml = "../../../Datasets/Import/users.xml";

        private const string Export_Products_Path_Xml = "../../../Datasets/Export/products.xml";
        private const string Export_SoldProducts_Path_Xml = "../../../Datasets/Export/users-sold-products.xml";
        private const string Export_Categories_ByProducts_Path_Xml = "../../../Datasets/Export/categories-by-products.xml";
        private const string Export_User_And_ProductsPath_Xml = "../../../Datasets/Export/users-and-products.xml";
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            InitializeMapper();

            ImportData(context);

            ExportData(context);

        }

        private static void ExportData(ProductShopContext context)
        {
            string gettingProductsInRange = GetProductsInRange(context);
            Console.WriteLine(gettingProductsInRange);

            string gettingSoldProducts = GetSoldProducts(context);
            Console.WriteLine(gettingSoldProducts);

            string gettingCategoriesByProductsCount = GetCategoriesByProductsCount(context);
            Console.WriteLine(gettingCategoriesByProductsCount);

            string gettingAllProductsWithUser = GetUsersWithProducts(context);
            Console.WriteLine(gettingAllProductsWithUser);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productDtos = context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                .OrderBy(p => p.Price)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName ?? p.Buyer.LastName
                })
                .ToArray();

            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), productDtos);

            File.WriteAllText(Export_Products_Path_Xml, sb.ToString());

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersSoldProductsDtos = context.Users
               .Where(u => u.ProductsSold.Count > 0)
               .Select(u => new UserSoldProductDto
               {
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   SoldProducts = u.ProductsSold.Select(p => new SoldProductElementsDto
                   {
                       Name = p.Name,
                       Price = p.Price
                   })
                   .ToArray()
               })
               .OrderBy(u => u.LastName)
               .ThenBy(u => u.FirstName)
               .ToArray();

            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(UserSoldProductDto[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), usersSoldProductsDtos);

            File.WriteAllText(Export_SoldProducts_Path_Xml, sb.ToString());

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsDtos = context.Categories
                .Select(c => new CategoryProductsInfoDto
                {
                    Name = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Select(cp => cp.Product.Price).DefaultIfEmpty(0).Average(),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderBy(cp => cp.ProductsCount)
                .ToArray();

            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(CategoryProductsInfoDto[]), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categoriesByProductsDtos);

            File.WriteAllText(Export_Categories_ByProducts_Path_Xml, sb.ToString());

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersCollectionDto = new UsersCollectionDTO
            {
                Count = context.Users.Count(),
                UserDTOs = context.Users
                    .Where(u => u.ProductsSold.Count > 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .Select(u => new UserDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        AgeValue = u.Age.ToString(),
                        SoldProducts = new SoldProductsCollectionDto
                        {
                            Count = u.ProductsSold.Count,
                            SoldProductDTOs = u.ProductsSold.Select(sp => new SoldProductAttributesDto
                            {
                                Name = sp.Name,
                                Price = sp.Price
                            })
                            .ToArray()
                        }
                    })
                    .ToArray()
            };

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(UsersCollectionDTO));
            serializer.Serialize(new StringWriter(sb), usersCollectionDto, xmlNamespaces);

            File.WriteAllText(Export_User_And_ProductsPath_Xml, sb.ToString());

            return sb.ToString().TrimEnd();
        }




        private static void ImportData(ProductShopContext context)
        {
            var xmlStringUsers = File.ReadAllText(Import_Users_Path_Xml);
            string resultimportUsers = ImportUsers(context, xmlStringUsers);
            Console.WriteLine(resultimportUsers);

            var xmlStringProducts = File.ReadAllText(Import_Products_Path_Xml);
            string resultimportProducts = ImportProducts(context, xmlStringProducts);
            Console.WriteLine(resultimportProducts);

            var xmlStringCategories = File.ReadAllText(Import_Categories_Path_Xml);
            string resultimportCategories = ImportCategories(context, xmlStringCategories);
            Console.WriteLine(resultimportCategories);

            var xmlStringCategoryProducts = File.ReadAllText(Import_Categories_Products_Path_Xml);
            string resultimportProductsCategories = ImportCategoryProducts(context, xmlStringCategoryProducts);
            Console.WriteLine(resultimportProductsCategories);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("Users"));
            var deserializedUserDtos = (UserImportDto[])serializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in deserializedUserDtos)
            {

                var user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ProductImportDto[]), new XmlRootAttribute("Products"));
            var deserializedProductDtos = (ProductImportDto[])serializer.Deserialize(new StringReader(inputXml));

            var random = new Random();
            var usersCount = context.Users.Select(u => u.Id).Count();

            var products = new List<Product>();

            for (int i = 0; i < deserializedProductDtos.Length; i++)
            {
                var productDto = deserializedProductDtos[i];

                if (IsValid(productDto))
                {
                    continue;
                }

                var product = mapper.Map<Product>(productDto);

                product.SellerId = random.Next(1, usersCount);

                if (i % 10 != 0)
                {
                    product.BuyerId = random.Next(1, usersCount);
                }

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryImportDto[]), new XmlRootAttribute("Categories"));
            var deserializedProductDtos = (CategoryImportDto[])serializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in deserializedProductDtos)
            {
                if (IsValid(categoryDto))
                {
                    var category = mapper.Map<Category>(categoryDto);
                    categories.Add(category);
                }
            }

            context.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]),
                                 new XmlRootAttribute("CategoryProducts"));
            var categoryProducts = new List<CategoryProduct>();

            using (var reader = new StringReader(inputXml))
            {
                var categoryProductsFromDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(reader);

                var categoryIds = context.Categories.Select(c => c.Id).ToList();
                var productIds = context.Products.Select(p => p.Id).ToList();

                foreach (var dto in categoryProductsFromDto)
                {
                    if (categoryIds.Any(c => c == dto.CategoryId &&
                        productIds.Any(p => p == dto.ProductId)))
                    {
                        var categoryProduct = new CategoryProduct
                        {
                            CategoryId = dto.CategoryId,
                            ProductId = dto.ProductId
                        };

                        categoryProducts.Add(categoryProduct);
                    }
                }

                context.CategoryProducts.AddRange(categoryProducts);
                context.SaveChanges();
            }

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        private static bool IsValid(object obj)
        {
            var validatonContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validatonContext, validationResults, true);
        }
    }
}