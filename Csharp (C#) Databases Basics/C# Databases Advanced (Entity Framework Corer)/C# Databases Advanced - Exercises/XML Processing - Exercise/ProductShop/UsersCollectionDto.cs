using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop
{
    using ProductShop.Dtos.Export;
    using System.Xml.Serialization;

    [XmlRoot("Users")]
    public class UsersCollectionDTO
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("users")]
        public UserDto[] UserDTOs { get; set; }
    }
}
