using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{

    [XmlType("SoldProducts")]
    public class SoldProductsCollectionDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public SoldProductAttributesDto[] SoldProductDTOs { get; set; }
    }
}
