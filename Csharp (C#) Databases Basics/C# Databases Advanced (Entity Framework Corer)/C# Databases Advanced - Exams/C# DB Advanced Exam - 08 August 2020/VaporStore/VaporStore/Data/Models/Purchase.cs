namespace VaporStore.Data.Models
{

    using System;
    using System.ComponentModel.DataAnnotations;

    using VaporStore.Data.Models.Enums;

    public class Purchase
    {
        private const string validationKeyPattern = @"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$";


        public int Id { get; set; }

        public PurchaseType Type { get; set; }

        [Required]
        //[RegularExpressionAttribute(validationKeyPattern)]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

    }
}