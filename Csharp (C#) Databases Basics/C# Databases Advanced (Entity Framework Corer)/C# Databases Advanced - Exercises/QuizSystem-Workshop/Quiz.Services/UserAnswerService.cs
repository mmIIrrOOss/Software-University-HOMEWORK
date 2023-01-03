using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserAnswerService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void AddUserAnswer(string userId,  int answerId)
        {
            var userAnswer = new UserAnswer
            {
                IdentityUserId = userId,
                AnswerId = answerId
            };

            this.applicationDbContext.UserAnswers.Add(userAnswer);
            this.applicationDbContext.SaveChanges();
        }

        public void BulkAddUserAnswer(QuizInputModel quizInputModel)
        {
            var userAnswers = new List<UserAnswer>();

            foreach (var questiom in quizInputModel.Questions)
            {
                var userAnswer = new UserAnswer
                {
                    IdentityUserId = quizInputModel.UserId.ToString(),
                    AnswerId = questiom.AnswerId,
                };
                userAnswers.Add(userAnswer);
            }

            this.applicationDbContext.AddRange(userAnswers);
            this.applicationDbContext.SaveChanges();
        }

        public int GetUserResult(string userId, int quizId)
        {
            var totalPoints = this.applicationDbContext.UserAnswers
                .Where(x => x.IdentityUserId == userId
                && x.Question.QuizId == quizId)
                .Sum(x => x.Answer.Points);

            return totalPoints;
        }
    }
}
