using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("parts")]
    public class CarPartImporttDto
    {
        [XmlAttribute("partid")]
        public int Id { get; set; }
    }
}