using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.Export;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext carDealerContext = new CarDealerContext();
            carDealerContext.Database.EnsureDeleted();
            carDealerContext.Database.EnsureCreated();
            InitializeAutoMapper();

            string inputJsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            string resultImportSuppliers = ImportSuppliers(carDealerContext, inputJsonSuppliers);
            Console.WriteLine(resultImportSuppliers);

            string inputJsonParts = File.ReadAllText("../../../Datasets/parts.json");
            string resultImportParts = ImportParts(carDealerContext, inputJsonParts);
            Console.WriteLine(resultImportParts);

            string inputJsonCars = File.ReadAllText("../../../Datasets/cars.json");
            string resultImportCars = ImportCars(carDealerContext, inputJsonCars);
            Console.WriteLine(resultImportCars);

            string imputJsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            string resultImportCustomers = ImportCustomers(carDealerContext, imputJsonCustomers);
            Console.WriteLine(resultImportCustomers);

            string imputJsonSales = File.ReadAllText("../../../Datasets/sales.json");
            string resultImportSales = ImportCustomers(carDealerContext, imputJsonSales);
            Console.WriteLine(resultImportSales);

            string resultOrderCustomers = GetOrderedCustomers(carDealerContext);
            Console.WriteLine(resultOrderCustomers);

            string resultOrderCars = GetCarsFromMakeToyota(carDealerContext);
            Console.WriteLine(resultOrderCars);

            string resultLocalSuppliers = GetLocalSuppliers(carDealerContext);
            Console.WriteLine(resultLocalSuppliers);

            string resultExportCars = GetCarsWithParts(carDealerContext);
            Console.WriteLine(resultExportCars);

            string resultTotalSelsByCustomer = GetTotalSalesByCustomer(carDealerContext);
            Console.WriteLine(resultTotalSelsByCustomer);

            string resultSalesWithDiscount = GetSalesWithAppliedDiscount(carDealerContext);
            Console.WriteLine(resultSalesWithDiscount);
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJsonSuppliers)
        {
            IEnumerable<SupplierDto> dtoUsers = JsonConvert.
               DeserializeObject<IEnumerable<SupplierDto>>(inputJsonSuppliers);

            IEnumerable<Supplier> suppliers = mapper.Map<IEnumerable<Supplier>>(dtoUsers);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputJsonParts)
        {
            IEnumerable<PartDto> dtoParts = JsonConvert.DeserializeObject<IEnumerable<PartDto>>(inputJsonParts);

            IEnumerable<Part> parts = mapper.Map<IEnumerable<Part>>(dtoParts);
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputJsonCars)
        {
            IEnumerable<CarDto> dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarDto>>(inputJsonCars);

            IEnumerable<Car> cars = mapper.Map<IEnumerable<Car>>(dtoCars);
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJsonCustomers)
        {
            IEnumerable<CustomerDto> dtoCustomer = JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(inputJsonCustomers);

            IEnumerable<Customer> customers = mapper.Map<IEnumerable<Customer>>(dtoCustomer);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputJsonSales)
        {
            IEnumerable<DTO.SaleDto> dtoSales = JsonConvert.DeserializeObject<IEnumerable<DTO.SaleDto>>(inputJsonSales);

            IEnumerable<Sale> sales = mapper.Map<IEnumerable<Sale>>(dtoSales);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            OrderCustomerDto[] orderCustomers = context.Customers
                .Select(c => new OrderCustomerDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToArray();


            var jsonOrderCustomers = JsonConvert.SerializeObject(orderCustomers, Formatting.Indented);
            File.WriteAllText("../../../Datasets/ordered-customers.json", jsonOrderCustomers);
            return jsonOrderCustomers;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            List<CarFromMakeToyotaDto> cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .OrderByDescending(x => x.TravelledDistance)
                .Select(x => new CarFromMakeToyotaDto()
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var jsonOrderCars = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText("../../../Datasets/toyota-cars.json", jsonOrderCars);
            return jsonOrderCars;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            List<LocalSupplierDto> localSuppliers = context.Suppliers
                .Select(x => new LocalSupplierDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .OrderBy(x => x.Name)
                .ToList();

            string jsonlocalSuppliers = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            File.WriteAllText("../../../Datasets/local-suppliers.json", jsonlocalSuppliers);
            return jsonlocalSuppliers;
        }

        public static string GetCarsWithParts(CarDealerContext dbContext)
        {
            CarExportDto[] cars = dbContext
                .Cars
                .Select(c => new CarExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => new PartExportDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .ToArray()
                })
                .ToArray();

            string jsonCarsExport = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText("../../../Files/Export/cars-and-parts.json", jsonCarsExport);

            return jsonCarsExport;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext dbContext)
        {
            CustomerSaleDto[] sales = dbContext
                .Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new CustomerSaleDto()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Select(s => s.Car.PartCars.Select(pc => pc.Part).Sum(pc => pc.Price)).Sum()
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            string jsonSales = JsonConvert.SerializeObject(sales, Formatting.Indented);
            File.WriteAllText("../../../Files/Export/customers-total-sales.json", jsonSales);

            return jsonSales;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext dbContext)
        {
            DTO.Export.SaleDto[] sales = dbContext
                .Sales
                .Select(s => new DTO.Export.SaleDto()
                {
                    Car = new CarSaleDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount / 100m,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100m)
                })
                .ToArray();

            string jsonSalesWithDiscount = JsonConvert.SerializeObject(sales, Formatting.Indented);
            File.WriteAllText("../../../Files/Export/sales-discounts.json", jsonSalesWithDiscount);

            return jsonSalesWithDiscount;
        }
    }
}