using System.Xml.Serialization;
namespace ProductShop.Dtos.Import
{

    [XmlType("Category")]
    public class CategoryImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
