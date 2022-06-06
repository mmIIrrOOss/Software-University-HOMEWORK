namespace P03_FootballBetting
{
    using System;
    using Data;

    class StartUp
    {
        static void Main(string[] args)
        { 
            var context = new FootballBettingContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
