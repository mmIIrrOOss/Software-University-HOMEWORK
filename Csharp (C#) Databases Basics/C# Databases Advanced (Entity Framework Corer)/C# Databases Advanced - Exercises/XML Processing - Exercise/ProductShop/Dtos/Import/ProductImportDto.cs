using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Product")]
    public class ProductImportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("sellerId")]
        public int SellerId { get; set; }

        [XmlAttribute("buyerId")]
        public int BuyerId { get; set; }
    }
}
