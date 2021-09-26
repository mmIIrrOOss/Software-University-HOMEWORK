using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class TVData
    {
        static TVData()
        {
            TVs = Read(); ;
        }
        public static void Add(TV tv)
        {
            tv.Id = TVs.Count;
            TVs.Add(tv);
            Save();
        }
        public static List<TV> GetAll()
        {
            return TVs;
        }
        private static List<TV> Read() 
        {
            var tvs = new List<TV>();
            if (File.Exists("./data.txt"))
            {
                using (StreamReader reader = new StreamReader("./data.txt"))
                {
                    string[] tvsRead = reader.ReadToEnd().Split("&|&");
                    foreach (var tv in tvsRead)
                    {
                        var data = tv.Split("-");
                        var newTV = new TV();
                        if (data.Length > 2)
                        {
                            newTV.Name = data[0];
                            newTV.Image = data[1];
                            newTV.Id = int.Parse(data[2]);
                            tvs.Add(newTV);
                        }
                    }
                }
            }
            return tvs;
        }
        public static void Delete(int id)
        {
            TVs.Remove(TVs.First(tv => tv.Id == id));
            Save();
        }
        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter("./data.txt"))
            {
                foreach (var tv in TVs)
                {
                    writer.Write($"{tv.Name}-{tv.Image}-{tv.Id}&|&");
                }
            }
        }
        public static List<TV> TVs { get; set; }
    }
}
