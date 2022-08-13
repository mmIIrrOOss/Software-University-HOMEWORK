using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserSoldProductDto
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public SoldProductElementsDto[] SoldProducts { get; set; }
    }
}
