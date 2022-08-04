using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Datasets.JSONClassConverter
{
    public class CategoryInfo
    {
        public string Name { get; set; }

        public int ProductsCount { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
