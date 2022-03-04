
namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            Team team = new Team("Team");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var infoPlayer = Console.ReadLine().Split();
                var name = infoPlayer[0];
                var lastName = infoPlayer[1];
                var age = int.Parse(infoPlayer[2]);
                var salary = decimal.Parse(infoPlayer[3]);
                var person = new Person(name, lastName, age, salary);
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FisrtTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
