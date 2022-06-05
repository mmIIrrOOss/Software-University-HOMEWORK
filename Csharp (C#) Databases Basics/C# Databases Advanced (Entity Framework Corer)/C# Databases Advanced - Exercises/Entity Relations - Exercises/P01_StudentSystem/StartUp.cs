namespace P01_StudentSystem
{
    using System;

    using Data;

    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
