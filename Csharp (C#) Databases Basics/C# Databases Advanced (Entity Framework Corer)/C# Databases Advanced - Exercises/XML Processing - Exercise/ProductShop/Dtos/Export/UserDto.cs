using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UserDto
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlIgnore()]
        public int? Age { get; set; }

        [XmlAttribute("age")]
        public string AgeValue
        {
            get
            {
                if (this.Age.HasValue)
                {
                    return this.Age.Value.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != "0")
                {
                    this.Age = int.Parse(value);
                }
                else
                {
                    this.Age = null;
                }
            }
        }

        [XmlElement("SoldProducts")]
        public SoldProductsCollectionDto SoldProducts { get; set; }
    }
}
