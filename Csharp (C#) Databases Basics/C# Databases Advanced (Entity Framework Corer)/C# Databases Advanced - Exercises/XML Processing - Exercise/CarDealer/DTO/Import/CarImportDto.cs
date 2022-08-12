using System.Collections.Generic;

using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Car")]
    public class CarImportDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TravelDistance")]
        public long TravelDsitance { get; set; }

        [XmlElement("parts")]
        public List<CarPartImporttDto> CarPartsInputDtos { get; set; }
    }
}
