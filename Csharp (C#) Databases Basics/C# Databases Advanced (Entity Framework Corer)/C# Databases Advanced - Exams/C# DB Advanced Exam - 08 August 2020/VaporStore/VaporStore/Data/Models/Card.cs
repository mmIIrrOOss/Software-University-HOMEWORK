namespace VaporStore.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using VaporStore.Data.Models.Enums;

    public class Card
    {
        private const int MaxLengthDigitsNumberOfCard = 19;
        private const int MaxLengthDigitsNumberOfCvc = 3;

        public Card()
        {
            this.Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthDigitsNumberOfCard)]
        public string Number { get; set; }

        [Required]
        [MaxLength(MaxLengthDigitsNumberOfCvc)]
        public string Cvc { get; set; }

        public CardType Type { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

    }
}