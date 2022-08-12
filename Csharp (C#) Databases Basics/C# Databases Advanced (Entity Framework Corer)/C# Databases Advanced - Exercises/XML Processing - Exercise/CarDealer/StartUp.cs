namespace CarDealer
{
    using Data;
    using CarDealer.Models;
    using CarDealer.DTO.Import;
    using CarDealer.XML_Helper;
    using CarDealer.DTO.Export;
    
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    
    using AutoMapper;
    
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        private const string Import_Suppliers_Path = "../../../Datasets/Import/suppliers.xml";
        private const string Import_Parts_Path = "../../../Datasets/Import/parts.xml";
        private const string Import_Cars_Path = "../../../Datasets/Import/cars.xml";
        private const string Import_Customers_Path = "../../../Datasets/Import/customers.xml";
        private const string Import_Sales_Path = "../../../Datasets/Import/sales.xml";

        private const string Export_Car_With_Distance_Path = "../../../Datasets/Export/cars.xml";
        private const string Export_Cars_From_Make_Bmw_Path = "../../../Datasets/Export/bmw-cars.xml";
        private const string Export_Local_Suppliers_Path = "../../../Datasets/Export/local-suppliers.xml";
        private const string Export_Cars_With_List_Of_The_Parts_Path = "../../../Datasets/Export/cars-and-parts.xml";
        private const string Export_Total_Sale_Customers_Path = "../../../Datasets/Export/customers-total-sales.xml";
        private const string Export_Sale_Applyed_Discount_Path = "../../../Datasets/Export/sales-discounts.xml";
        
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext carDealerContext = new CarDealerContext();
            carDealerContext.Database.EnsureDeleted();
            carDealerContext.Database.EnsureCreated();

            InitializeAutoMapper();

            InputDataFromCarDealer(carDealerContext);
            ExportDataFromCarDealer(carDealerContext);

        }

        private static void ExportDataFromCarDealer(CarDealerContext carDealerContext)
        {
            Console.WriteLine(GetCarsWithDistance(carDealerContext));

            Console.WriteLine(GetCarsFromMakeBmw(carDealerContext));

            Console.WriteLine(GetLocalSuppliers(carDealerContext));

            Console.WriteLine(GetCarsWithTheirListOfParts(carDealerContext));

            Console.WriteLine(GetTotalSalesByCustomer(carDealerContext));

            Console.WriteLine(GetSalesWithAppliedDiscount(carDealerContext));
        }

        private static void InputDataFromCarDealer(CarDealerContext carDealerContext)
        {
            var suppliersXml = File.ReadAllText(Import_Suppliers_Path);
            string resultImportSuppliers = ImportSuppliers(carDealerContext, suppliersXml);
            Console.WriteLine(resultImportSuppliers);

            var partsXml = File.ReadAllText(Import_Parts_Path);
            string resultImportParts = ImportParts(carDealerContext, partsXml);
            Console.WriteLine(resultImportParts);

            var carsXml = File.ReadAllText(Import_Cars_Path);
            string resultImportCars = ImportCars(carDealerContext, carsXml);
            Console.WriteLine(resultImportCars);

            var customersXml = File.ReadAllText(Import_Customers_Path);
            string resultImportCustomers = ImportCustomers(carDealerContext, customersXml);
            Console.WriteLine(resultImportCustomers);

            var salesXml = File.ReadAllText(Import_Sales_Path);
            string resultImportSales = ImportSales(carDealerContext, salesXml);
            Console.WriteLine(resultImportSales);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {


            var xmlSerializer = new XmlSerializer(typeof(SupplierImportDto[]),
                                                     new XmlRootAttribute("Suppliers"));

            SupplierImportDto[] supplierDtos;

            using (var reader = new StringReader(inputXml))
            {
                supplierDtos = (SupplierImportDto[])xmlSerializer.Deserialize(reader);
            }

            //If we dont use AutoMapper we should map manually like this:
            //List<Supplier> suppliers1 = new List<Supplier>();

            //foreach (var dto in supplierDtos)
            //{
            //    Supplier supplier = new Supplier()
            //    {
            //        Name = dto.Name,
            //        IsImporter = dto.IsImporter
            //    };

            //    suppliers1.Add(supplier);
            //}

            var suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(PartImportDto[]), new XmlRootAttribute("Parts"));

            PartImportDto[] importPartDtos;

            using (var reader = new StringReader(inputXml))
            {
                importPartDtos = (PartImportDto[])xmlSerializer.Deserialize(reader);
            }

            var parts = mapper.Map<Part[]>(importPartDtos);


            foreach (var part in parts)
            {
                if (context.Suppliers.Any(x => x.Id == part.SupplierId))
                {
                    context.Parts.Add(part);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string root = "Cars";

            var carsDtos = XmlConverter.Deserializer<CarImportDto>(inputXml, root);
            var allParts = context.Parts.Select(x => x.Id).ToList();
            var cars = carsDtos.Select(x => new Car()
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TravelDsitance,
                PartCars = x.CarPartsInputDtos
                            .Select(x => x.Id)
                            .Distinct()
                            .Intersect(allParts)
                            .Select(pc => new PartCar()
                            {
                                PartId = pc
                            }).ToList()
            }).ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CustomerImportDto[]),
                               new XmlRootAttribute("Customers"));

            using (var reader = new StringReader(inputXml))
            {
                var customersDto = (CustomerImportDto[])xmlSerializer.Deserialize(reader);

                var customers = mapper.Map<Customer[]>(customersDto);

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            return $"Successfully imported {context.Customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(SaleImportDto[]),
                                 new XmlRootAttribute("Sales"));

            using (var reader = new StringReader(inputXml))
            {
                var saleDtos = (SaleImportDto[])xmlSerializer.Deserialize(reader);

                var sales = mapper.Map<Sale[]>(saleDtos);

                foreach (var sale in sales)
                {
                    if (context.Cars.Any(x => x.Id == sale.CarId))
                    {
                        context.Sales.Add(sale);
                    }
                }

                context.SaveChanges();
            }

            return $"Successfully imported {context.Sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carDTOs = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarExportDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarExportDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), carDTOs, xmlNamespaces);

            File.WriteAllText(Export_Car_With_Distance_Path, sb.ToString());
            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carDTOs = context.Cars
                .Where(c => c.Make.Equals("BMW"))
                .Select(c => new CarExportFromBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray()
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarExportFromBmwDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), carDTOs, xmlNamespaces);

            File.WriteAllText(Export_Cars_From_Make_Bmw_Path, sb.ToString());
            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSupplierDTOs = context.Suppliers
               .Where(s => s.IsImporter.Equals(false))
               .Select(s => new LocalSupplierExportDto
               {
                   Id = s.Id,
                   Name = s.Name,
                   PartsCount = s.Parts.Count
               })
               .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(LocalSupplierExportDto[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), localSupplierDTOs, xmlNamespaces);

            File.WriteAllText(Export_Local_Suppliers_Path, sb.ToString());

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carPartsDTOs = context.Cars
                .Select(c => new CarPartListExportDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    CarParts = c.PartCars.Select(pc => new PartAttributesExportDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .ToArray()
                })
                .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CarPartListExportDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), carPartsDTOs, xmlNamespaces);

            File.WriteAllText(Export_Cars_With_List_Of_The_Parts_Path
                , sb.ToString());

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerTotalSalesDTOs = context.Customers
               .Where(c => c.Sales.Count > 0)
               .Select(c => new CustomerTotalSalesExportDto
               {
                   Name = c.Name,
                   BoughtCars = c.Sales.Count,
                   SpentMoney = c.Sales
                       .Select(s => s.Car.PartCars.Sum(cp => cp.Part.Price) * (1 + s.Discount))
                       .DefaultIfEmpty(0)
                       .Sum()
               })
               .OrderByDescending(c => c.SpentMoney)
               .ThenByDescending(c => c.BoughtCars)
               .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(CustomerTotalSalesExportDto[]), new XmlRootAttribute("customers"));
            serializer.Serialize(new StringWriter(sb), customerTotalSalesDTOs, xmlNamespaces);

            File.WriteAllText(Export_Total_Sale_Customers_Path,
                sb.ToString());

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var saleDiscountsDTOs = context.Sales
           .Select(s => new SaleDiscountExportDto
           {
               Car = new CarFromSaleExportDto
               {
                   Make = s.Car.Make,
                   Model = s.Car.Model,
                   TravelledDistance = s.Car.TravelledDistance
               },
               CustomerName = s.Customer.Name,
               Discount = s.Discount,
               Price = s.Car.PartCars
                   .Select(pc => pc.Part.Price * (1 + s.Discount))
                   .DefaultIfEmpty(0)
                   .Sum(),
               PriceWithDiscount = s.Car.PartCars
                   .Select(pc => pc.Part.Price)
                   .DefaultIfEmpty(0)
                   .Sum(),
           })
           .ToArray();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(SaleDiscountExportDto[]), new XmlRootAttribute("sales"));
            serializer.Serialize(new StringWriter(sb), saleDiscountsDTOs, xmlNamespaces);

            File.WriteAllText(Export_Sale_Applyed_Discount_Path,
                sb.ToString());

            return sb.ToString().TrimEnd();
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}