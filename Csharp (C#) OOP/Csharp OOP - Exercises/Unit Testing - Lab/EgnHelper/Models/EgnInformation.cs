namespace EgnHelper.Models
{
    using System;
    using System.Globalization;
    using Enums;

    public class EgnInformation
    {
        public EgnInformation(string plaseOfBirth, DateTime dayOfBirth, Sex sex)
        {
            this.PlaceOfBirth = plaseOfBirth;
            this.DayOfBirth = dayOfBirth;
            this.Sex = sex;
        }

        public string PlaceOfBirth { get; }

        public DateTime DayOfBirth { get; }

        public Sex Sex { get; }

        public override string ToString()
        {
            var sexAsText = this.Sex switch
            {
                Sex.Unknown => "неизвестен",
                Sex.Male => "мъж",
                Sex.Female => "жена",
            };

            var suffix = this.Sex switch
            {
                Sex.Unknown => string.Empty,
                Sex.Male => string.Empty,
                Sex.Female => "а",
            };

            return $"ЕГН на {sexAsText}, роден{suffix} на {this.DayOfBirth.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("bg-BG"))} г. в регион {this.PlaceOfBirth}";
        }
    }
}
