namespace Quiz.Services.Models
{
    public class UserQuizViewModel
    {

        public int QuizId { get; set; }

        public string Title { get; set; }

        public QuizStatus QuizStatus { get; set; }
    }

    public enum QuizStatus
    {
        NotStarted = 1,
        InProgress = 2,
        Finished = 3,a
    }
}
