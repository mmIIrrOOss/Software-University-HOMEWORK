namespace EgnHelper.Models
{
    using EgnHelper.Enums;
    using EgnHelper.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class EgnInformationExtractor
    {
        private SortedDictionary<int, string> cities = new SortedDictionary<int, string>()
                {
                          {43 ,"Благоевград"}  ,
                          {93 ,"Бургас"}  ,
                          {139 ,"Варна"}  ,
                          {169 ,"Велико Търново"}  ,
                          {183 ,"Видин"}  ,
                          {217 ,"Враца"}  ,
                          {233 ,"Габрово"}  ,
                          {281 ,"Кърджали"}  ,
                          {301 ,"Кюстендил"}  ,
                          {319 ,"Ловеч"}  ,
                          {341 ,"Монтана "}  ,
                          {377 ,"Пазарджик"}  ,
                          {395 ,"Перник"}  ,
                          {435 ,"Плевен"}  ,
                          {501 ,"Пловдив"}  ,
                          {527 ,"Разград"}  ,
                          {555 ,"Русе"}  ,
                          {575 ,"Силистра"}  ,
                          {601 ,"Сливен"}  ,
                          {623 ,"Смолян"}  ,
                          {721 ,"София - град"}  ,
                          {751 ,"София - окръг"}  ,
                          {789 ,"Стара Загора"}  ,
                          {821 ,"Добрич (Толбухин)"  },
                          {843 ,"Търговище"}  ,
                          {871 ,"Хасково "}  ,
                          {903 ,"Шумен"}  ,
                          {925 ,"Ямбол"}  ,
                         { 999 ,"Друг /Неизвестен"}
                };

        private IEgnValidator egnValidator;

        public EgnInformationExtractor(IEgnValidator egnValidator)
        {
            this.egnValidator = egnValidator;
        }

        public EgnInformation Extract(string egn)
        {

            if (!this.egnValidator.IsValid(egn))
            {
                throw new ArgumentException("Invalid EGN provider", nameof(egn));
            }

            Sex sex = Sex.Unknown;
            if (int.Parse(egn[8].ToString()) % 2 == 0)
            {
                sex = Sex.Male;
            }
            else
            {
                sex = Sex.Female;
            }
            string placeOfBirth = "";
            int placeOfBirthCode = int.Parse(egn[6].ToString() + egn[7] + egn[8]);
            foreach (var city in this.cities)
            {
                if (placeOfBirthCode <= city.Key)
                {
                    placeOfBirth = city.Value;
                    break;
                }
            }

            int yearPart = int.Parse(egn.Substring(0, 2));
            int mounthPart = int.Parse(egn.Substring(2, 2));
            int dayPart = int.Parse(egn.Substring(4, 2));

            int day = dayPart;
            int mounth = mounthPart;
            int year = yearPart;

            if (mounthPart >= 21 && mounthPart <= 32)
            {
                mounth = mounthPart - 20;
                year = year + 1800;

            }
            else if (mounthPart >= 41 && mounthPart <= 52)
            {
                mounth = mounthPart - 40;
                year = year + 2000;
            }
            else if (mounthPart >= 1 && mounthPart <= 12)
            {
                year = year + 1900;
            }

            var dayOfBirth = new DateTime(year, mounth, day);
            var egnInformation = new EgnInformation(placeOfBirth, dayOfBirth, sex);
            return egnInformation;
        }
    }
}
