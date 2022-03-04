
namespace _05._Date_Modifier
{
	using System;
	public class StartUp
	{
		static void Main(string[] args)
		{
			string firstDate = Console.ReadLine();
			string secondDate = Console.ReadLine();
			DateModifier dateModifier = new DateModifier(firstDate, secondDate);
			Console.WriteLine(dateModifier.GetDaysDifference(firstDate,secondDate));
		}
	}
}
