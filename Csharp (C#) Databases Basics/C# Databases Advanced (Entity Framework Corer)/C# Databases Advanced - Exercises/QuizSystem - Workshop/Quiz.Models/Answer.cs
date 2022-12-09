using System.Collections.Generic;

namespace Quiz.Models
{
    public class Answer
    {
        public Answer()
        {
            this.UserAnswer = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCorrect { get; set; }

        public int Points { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public ICollection<UserAnswer> UserAnswer { get; set; }
    }
}