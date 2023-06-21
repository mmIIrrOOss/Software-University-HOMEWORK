using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaporStore.DataProcessor.ImportDto
{

    public class UserJsonInputModel
    {
        private const string regularExpr = "[A-Z][a-z]{2,} [A-Z][a-z]{2,}";

        [Required]
        [RegularExpression(regularExpr)]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public IEnumerable<CardJsonInputModel> Cards { get; set; }
    }

}
