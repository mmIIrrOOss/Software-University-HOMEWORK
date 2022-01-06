namespace EgnHelper
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text.RegularExpressions;

	public class EgnValidator : IEgnValidator
	{
		private int[] weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

		private Dictionary<int, string> cities = new Dictionary<int, string>()
				{
						  {43 ,"      Благоевград "}  ,
						  {93 ,"          Бургас  "}  ,
						  {139 ,"          Варна   "}  ,
						  {169 ,"  Велико Търново  "}  ,
						  {183 ,"          Видин   "}  ,
						  {217 ,"          Враца   "}  ,
						  {233 ,"          Габрово "}  ,
						  {281 ,"      Кърджали    "}  ,
						  {301 ,"      Кюстендил   "}  ,
						  {319 ,"          Ловеч   "}  ,
						  {341 ,"          Монтана "}  ,
						  {377 ,"      Пазарджик   "}  ,
						  {395 ,"          Перник  "}  ,
						  {435 ,"          Плевен  "}  ,
						  {501 ,"          Пловдив "}  ,
						  {527 ,"          Разград "}  ,
						  {555 ,"          Русе    "}  ,
						  {575 ,"      Силистра    "}  ,
						  {601 ,"          Сливен  "}  ,
						  {623 ,"          Смолян  "}  ,
						  {721 ,"  София – град    "}  ,
						  {751 ,"  София – окръг   "}  ,
						  {789 ,"  Стара Загора    "}  ,
						  {821 ,"Добрич (Толбухин) "  },
						  {843 ,"      Търговище   "}  ,
						  {871 ,"          Хасково "}  ,
						  {903 ,"          Шумен   "}  ,
						  {925 ,"          Ямбол   "}  ,
						 { 999 ," Друг /Неизвестен "}
				};

		public bool IsValid(string egn)
		{
			if (egn == null)
			{
				throw new ArgumentNullException(nameof(egn));
			}
			int lenght = egn.Length;
			char[] arrayDigit = egn.Where(x => char.IsDigit(x)).ToArray();
			if (arrayDigit == null)
			{
				return false;
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
			else
			{
				return false;
			}

			if (!DateTime.TryParseExact
				($"{year}-{mounth}-{day}",
				"yyyy-M-d",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out _))
			{
				return false;
			}

			int chekSum = 0;
			for (int i = 0; i <= 8; i++)
			{
				var digit = egn[i] - '0';
				chekSum += digit * this.weights[i];
			}

			var lastDigit = chekSum % 11;
			if (lastDigit == 10)
			{
				lastDigit = 0;
			}
			if (int.Parse(egn[9].ToString()) != lastDigit)
			{
				return false;
			}
			return true;
		}
	}

}
