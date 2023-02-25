using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public QuizService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int Add(string title)
        {
            var quiz = new Quiz.Models.Quiz
            {
                Title = title
            };

            this.applicationDbContext.Quizes.Add(quiz);
            this.applicationDbContext.SaveChanges();

            return quiz.Id;
        }

        public QuizViewModel GetQuizById(int quizId)
        {
            var quiz = this.applicationDbContext
                .Quizes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == quizId);

            var quizViewModel = new QuizViewModel
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Questions = quiz.Questions.OrderBy(x=> Guid.NewGuid()).Select(x => new QuestionViewModel
                {
                    Id = x.Id,
                    Ttitle = x.Title,
                    Answers = x.Answers.OrderBy(x => Guid.NewGuid()).Select(a => new AnswerViewModel
                    {
                        Id = a.Id,
                        Title = a.Title
                    })
                    .ToList()
                })
                .ToList()
            };

            return quizViewModel;
        }

        public IEnumerable<UserQuizViewModel> GetQuizesByUserName(string userName)
        {
            var quizes = applicationDbContext.Quizes.Select(x => new UserQuizViewModel
            {
                QuizId = x.Id,
                Title = x.Title
            }).ToList();

            foreach (var quiz in quizes)
            {
                var questionCount = applicationDbContext.UserAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName
                                    && ua.Question.QuizId == quiz.QuizId);
                if (questionCount == 0)
                {
                    quiz.QuizStatus = QuizStatus.NotStarted;
                    continue;
                }

                var answeredQuestions = applicationDbContext.UserAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName
                                    && ua.Question.QuizId == quiz.QuizId
                                    && ua.AnswerId.HasValue);

                if (answeredQuestions == questionCount)
                {
                    quiz.QuizStatus = QuizStatus.Finished;
                    continue;
                }
                else
                {
                    quiz.QuizStatus = QuizStatus.InProgress;
                }

            }

            return quizes;
        }

        public void StartQuiz(string userName, int quizId)
        {
            if (applicationDbContext.UserAnswers.Any(x => x.IdentityUser.UserName == userName
            && x.Question.QuizId == quizId))
            {
                return;
            }
            var userId = this.applicationDbContext.Users
                .Where(x => x.UserName == userName)
                .Select(x => x.Id)
                .FirstOrDefault();

            var questions = applicationDbContext
                .Questions
                .Where(x => x.QuizId == quizId)
                .Select(x => new
                {
                    x.Id
                }).ToList();

            foreach (var question in questions)
            {
                applicationDbContext.UserAnswers.Add(new UserAnswer
                {
                    AnswerId = null,
                    IdentityUserId = userId,
                    QuestionId = question.Id,
                });
            }

            applicationDbContext.SaveChanges();
        }
    }
}
