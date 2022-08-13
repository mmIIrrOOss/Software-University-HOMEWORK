using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
    public class UserImportDto
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public int Age { get; set; }
    }
}
