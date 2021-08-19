

namespace _05._Date_Modifier
{
	using System;

	public class DateModifier
	{
		public DateModifier(string first, string second)
		{
			this.First = DateTime.ParseExact(first, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
			this.Second = DateTime.ParseExact(second, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
		}
		public DateTime First { get; set; }
		public DateTime Second { get; set; }
		public int GetDaysDifference(string first, string second)
		{
			return Math.Abs((this.First.Date - this.Second.Date).Days);
		}
	}
}
