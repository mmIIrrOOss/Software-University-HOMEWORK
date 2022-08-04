using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Datasets.JSONClassConverter
{
    public class ProductBuyers
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Product> BoughtsProducts { get; set; }
    }
}
