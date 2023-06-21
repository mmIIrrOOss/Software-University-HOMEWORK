using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.ImportDto
{
    public class CardJsonInputModel
    {
        private const string regexCardNumber = "[0 - 9]{4} [0 - 9]{4} [0 - 9]{4} [0 - 9]{4}";
        private const string regexCvcNumber = "[0-9]{3}";

        [Required]
        [RegularExpression(regexCardNumber)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(regexCvcNumber)]
        public string CVC { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }

}
