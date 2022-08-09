namespace CarDealer
{
    using CarDealer.DTO.Import;
    using CarDealer.Models;
    using Data;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using System;
    using CarDealer.XML_Helper;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext carDealerContext = new CarDealerContext();
            carDealerContext.Database.EnsureDeleted();
            carDealerContext.Database.EnsureCreated();

            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string resultImportSuppliers = ImportSuppliers(carDealerContext, suppliersXml);
            Console.WriteLine(resultImportSuppliers);

            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            string resultImportParts = ImportParts(carDealerContext, partsXml);
            Console.WriteLine(resultImportParts);


        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var root = "Suppliers";

            var suppliersDto = XmlConverter.Deserializer<SupplierImportDto>(inputXml, root);

            var suppliers = suppliersDto.Select(x => new Supplier()
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
            .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var root = "Parts";
            var partsDto = XmlConverter.Deserializer<PartInputDto>(inputXml, root);

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsDto
                .Where(x=> supplierIds.Contains(x.SupplierId))
                .Select(x => new Part()
                {
                      Name = x.Name,
                       Price = x.Price,
                       Quantity = x.Quantity,
                       SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }


    }
}