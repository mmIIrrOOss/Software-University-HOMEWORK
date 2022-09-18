using System;
using System.Text;
using Microsoft.EntityFrameworkCore;


using RealEstases.Data;
using RealEstates.Services;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var dbContex = new ApplicationDbContext();
            dbContex.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1.Property Search");
                Console.WriteLine("2.Most Expensive districts");
                Console.WriteLine("3.Average price per square meter");
                Console.WriteLine("0.EXIT");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option >= 1 && option <= 3)
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
                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                    Console.WriteLine("Press any key continue ... ");
                    Console.ReadKey();
                }

            }
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
            IDistrictService districtService = new DistrictServices(dbContext);
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
