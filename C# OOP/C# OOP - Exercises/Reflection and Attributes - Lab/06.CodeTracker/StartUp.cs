namespace AuthorProblem
{
    using System;
    using Models;

    [SoftUni("Miro")]
    public class StartUp
    {
        [SoftUni("mmiirrooss")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodByAuthor();
        }
    }
}
