using System.Collections.Generic;

namespace Quiz.Services.Models
{
    public class QuizInputModel
    {

        public int UserId { get; set; }

        public int QuizId { get; set; }

        public List<QuestionInputModel> Questions { get; set; }

    }
}
