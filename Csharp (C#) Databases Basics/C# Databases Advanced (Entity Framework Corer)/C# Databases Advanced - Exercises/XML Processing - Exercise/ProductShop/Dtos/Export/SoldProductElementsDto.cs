using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Porduct")]
    public class SoldProductElementsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
