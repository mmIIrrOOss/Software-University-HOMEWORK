namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
            this.Games = new HashSet<Game>();
        }

        public int PositionId { get; set; }

        public string Name { get; set; }

        ICollection<Player> Players { get; set; }

        ICollection<Game> Games { get; set; }
    }
}
