
namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(";");
                var selectCommand = tokens[0];
                try
                {
                    switch (selectCommand)
                    {
                        case "Team":
                            teams.Add(new Team(tokens[1]));
                            break;
                        case "Add":
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }
                            else
                            {
                                var selectTeam = tokens[1];
                                var playerName = tokens[2];
                                int endurance = int.Parse(tokens[3]);
                                int sprint = int.Parse(tokens[4]);
                                int dribble = int.Parse(tokens[5]);
                                int passing = int.Parse(tokens[6]);
                                int shooting = int.Parse(tokens[7]);
                                var player = new Player(playerName, endurance, sprint,
                                    dribble, passing, shooting);
                                var currentTeam = teams.First(t => t.Name == tokens[1]);
                                currentTeam.AddPlayer(player);
                            }
                            break;
                            
                        case "Remove":
                            var teamToRemove = teams.First(t => t.Name == tokens[1]);
                            teamToRemove.RemovePlayer(tokens[2]);
                            break;
                        case "Rating":
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine(teams.First(t => t.Name == tokens[1]).ToString());
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
