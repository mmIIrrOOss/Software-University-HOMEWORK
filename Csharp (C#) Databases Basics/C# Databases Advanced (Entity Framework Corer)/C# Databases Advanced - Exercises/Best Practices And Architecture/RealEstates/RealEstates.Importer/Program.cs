using RealEstases.Data;
using RealEstates.Services;

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RealEstates.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
           //var context = new ApplicationDbContext();
           //context.Database.EnsureCreated();

            ImportJsonFile("houses-Sofia-data.json");

            Console.WriteLine(); 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ImportJsonFile("imot.bg-raw-data");


        }
        public static void ImportJsonFile(string fileName)
        {
            var dbContext = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(dbContext);

            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>
                (File.ReadAllText(fileName));
            int counterProgress = 0;
            foreach (var jsonProp in properties)
            {

                propertiesService
                    .Add
                    (   jsonProp.District,
                        jsonProp.Price,
                        jsonProp.Floor,
                        jsonProp.TotalFloors,
                        jsonProp.Size,
                        jsonProp.YardSize,
                        jsonProp.Year,
                        jsonProp.Type,
                        jsonProp.BuildingType);
                counterProgress++;
                Console.WriteLine(counterProgress);
            }
        }
    }
}
