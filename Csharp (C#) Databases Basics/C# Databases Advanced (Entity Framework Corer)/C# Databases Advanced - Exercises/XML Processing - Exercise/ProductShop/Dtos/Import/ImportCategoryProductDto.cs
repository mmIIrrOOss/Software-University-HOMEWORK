using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlAttribute("CategoryId")]
        public int CategoryId { get; set; }

        [XmlAttribute("ProductId")]
        public int ProductId { get; set; }
    }
}
