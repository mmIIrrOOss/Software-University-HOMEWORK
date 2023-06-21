using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class PurchaseXmlInputModel
    {
        private const string RegexStringKey = "[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}";
        private const string regexCardNumber = "[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}";

        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [Required]
        public PurchaseType? Type { get; set; }
        
        [Required]
        [RegularExpression(RegexStringKey)]
        public string Key { get; set; }

        [Required]
        [RegularExpression(regexCardNumber)]
        public string Card  { get; set; }

        [Required]
        public string Date { get; set; }


    }
}
