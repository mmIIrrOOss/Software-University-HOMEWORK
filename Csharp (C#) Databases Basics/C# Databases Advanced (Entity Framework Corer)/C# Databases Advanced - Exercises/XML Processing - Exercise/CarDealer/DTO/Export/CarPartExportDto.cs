using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("parts")]
    public class CarPartExportDto
    {
        [XmlAttribute("partid")]
        public int Id { get; set; }
    }
}
