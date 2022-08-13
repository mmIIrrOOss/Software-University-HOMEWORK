using System.Xml.Serialization;
namespace ProductShop.Dtos.Export
{

    [XmlType("Product")]
    public class SoldProductAttributesDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
