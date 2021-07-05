using System;

namespace _9._Volleyball
{
	class Program
	{
		static void Main(string[] args)
		{
			string typeYears = Console.ReadLine();
			int p = int.Parse(Console.ReadLine());
			int numsWeek = int.Parse(Console.ReadLine());
			double gameWeekendSofia = (48-numsWeek) *3.0/ 4;
			double gameHoliday = p*2/3.0;
			double totalGames = gameWeekendSofia + gameHoliday + numsWeek;
			double bonusGame = 0;
			if (typeYears=="leap")
			{
				bonusGame = Math.Floor(totalGames + totalGames * 0.15);
			}
			else if(typeYears=="normal")
			{
				bonusGame = totalGames;
			}
			Console.WriteLine(Math.Floor(bonusGame));
		}
	}
}
