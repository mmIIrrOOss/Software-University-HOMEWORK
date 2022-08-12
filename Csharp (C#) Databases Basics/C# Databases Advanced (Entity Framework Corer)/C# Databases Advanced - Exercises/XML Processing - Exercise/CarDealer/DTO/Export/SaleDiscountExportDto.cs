using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{

    [XmlType("sale")]
    public class SaleDiscountExportDto
    {
        [XmlElement("car")]
        public CarFromSaleExportDto Car { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
