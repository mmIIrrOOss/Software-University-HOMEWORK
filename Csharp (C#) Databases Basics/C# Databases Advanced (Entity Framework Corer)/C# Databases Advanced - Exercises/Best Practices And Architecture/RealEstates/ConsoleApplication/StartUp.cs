using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using RealEstases.Data;
using RealEstates.Services;
using RealEstates.Services.Models;

namespace ConsoleApplication
{
    class StartUp
    {

        private static IPropertiesService propertiesService;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var dbContex = new ApplicationDbContext();
            //dbContex.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1.Property Search");
                Console.WriteLine("2.Most Expensive districts");
                Console.WriteLine("3.Average price per square meter");
                Console.WriteLine("4.Add tag");
                Console.WriteLine("5.Bulk tag to properties");
                Console.WriteLine("6.Property Full Info");
                Console.WriteLine("0.EXIT");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    Environment.Exit(0);
                }
                if (parsed && option >= 1 && option <= 6)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(dbContex);
                            break;
                        case 2:
                            MostExpensiveDistricts(dbContex);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(dbContex);
                            break;
                        case 4:
                            AddTag(dbContex);
                            break;
                        case 5:
                            BulkTagToProperties(dbContex);
                            break;
                        case 6:
                            PropertyFullInfo(dbContex);
                            break;
                    }
                    Console.WriteLine("Press any key continue ... ");
                    Console.ReadKey();
                }

            }
        }

        private static void PropertyFullInfo(ApplicationDbContext dbContex)
        {
            Console.WriteLine("Count of properties:");
            int countProperties = int.Parse(Console.ReadLine());
            propertiesService = new PropertiesService(dbContex);

            var resultProperties = propertiesService.GetFullData(countProperties).ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProperyInfoFullData[]));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter,resultProperties);
           
            Console.WriteLine(stringWriter.ToString().TrimEnd());
        }

        private static void BulkTagToProperties(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Bulk operation started!");
            propertiesService = new PropertiesService(dbContext);
            ITagService tagService = new TagService(dbContext, propertiesService);
            tagService.BulkTagToPropertiesRelation();
            Console.WriteLine("Bulk operation finished!");
        }

        private static void AddTag(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Tag name:");
            string tagName = Console.ReadLine();

            Console.WriteLine("Importance (optional):");
            bool iSImportance = int.TryParse(Console.ReadLine(), out int tagImportance);
            int? importance = iSImportance ? tagImportance : null;

            propertiesService = new PropertiesService(dbContext);
            ITagService tagService = new TagService(dbContext, propertiesService);
            tagService.Add(tagName, importance);

        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext dbContext)
        {
            IPropertiesService propertyService = new PropertiesService(dbContext);
            Console.WriteLine($"Average price per square meter: " +
                $"{propertyService.AveragePerSquareMeter()}:0.00€/m²");
        }

        private static void MostExpensiveDistricts(ApplicationDbContext dbContext)
        {
            Console.WriteLine("District count:");
            int count = int.Parse(Console.ReadLine());
            IDistrictService districtService = new DistrictService(dbContext);
            var districts = districtService.GetMostExpensiveDistricts(count);
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter:0.00}€/m²" +
                    $" ({district.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Min size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Max zise:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(dbContext);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}: {property.BuildingType}; " +
                    $"{property.PropertyType} => {property.Price}€ => {property.Size}m²");
            }
        }
    }
}
