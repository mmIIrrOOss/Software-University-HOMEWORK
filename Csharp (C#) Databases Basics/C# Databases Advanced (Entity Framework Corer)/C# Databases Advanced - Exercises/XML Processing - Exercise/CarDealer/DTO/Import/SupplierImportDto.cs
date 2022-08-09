using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType]
    public class SupplierImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("is Importer")]
        public bool IsImporter { get; set; }

    }
}
