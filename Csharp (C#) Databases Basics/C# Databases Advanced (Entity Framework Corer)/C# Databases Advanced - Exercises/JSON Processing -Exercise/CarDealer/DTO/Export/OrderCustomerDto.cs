using System;
using System.Collections.Generic;


namespace CarDealer.DTO.Export
{
    using CarDealer.Models;

    public class OrderCustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
