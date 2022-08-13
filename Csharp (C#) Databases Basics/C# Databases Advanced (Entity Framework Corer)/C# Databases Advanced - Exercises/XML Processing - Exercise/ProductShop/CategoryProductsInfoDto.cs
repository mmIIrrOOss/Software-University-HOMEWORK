using System.Xml.Serialization;

namespace ProductShop
{
    [XmlType("Category")]
    public class CategoryProductsInfoDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
