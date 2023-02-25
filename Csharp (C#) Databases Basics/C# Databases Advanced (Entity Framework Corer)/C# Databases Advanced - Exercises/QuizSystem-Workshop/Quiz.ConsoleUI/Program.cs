using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quiz.Data;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var jsonImporter = serviceProvider.GetService<IJsonImportService>();
            jsonImporter.Import("EF-Core-Quiz.json", "EF Core Test v2");

            //var questionService = serviceProvider.GetService<IQuestionService>();
            //questionService.Add("1+1", 1);

            //var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            //dbContext.Database.Migrate();


            //var answerService = serviceProvider.GetService<IAnswerService>();
            //answerService.Add("2", 5, true, 2);

            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            //userAnswerService.AddUserAnswer("5ca9b665-ceca-41f3-a5a0-1e055772f7c8", 1, 2, 1);

            //var quizService = serviceProvider.GetService<IUserAnswerService>();
            //var quiz = quizService.GetUserResult("5ca9b665-ceca-41f3-a5a0-1e055772f7c8", 1);

            //Console.WriteLine(quiz);

            //var questionService = serviceProvider.GetService<IQuestionService>();
            //questionService.Add("Qhat is Entity Framework Core", 1);

            //var answerService = serviceProvider.GetService<IAnswerService>();
            //answerService.Add("It is a ORM", 0, true, 1);

            //var answerServiceTwo = serviceProvider.GetService<IAnswerService>();
            //answerServiceTwo.Add("It is a MicroORM", 0, false, 1);

            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            //userAnswerService.AddUserAnswer("5ca9b665-ceca-41f3-a5a0-1e055772f7c8", 1, 1, 1);

            //var quizService = serviceProvider.GetService<IUserAnswerService>();
            //var quiz = quizService.GetUserResult("5ca9b665-ceca-41f3-a5a0-1e055772f7c8", 1);
            //Console.WriteLine(quiz);

            //foreach (var question in quiz.Questions)
            //{
            //    Console.WriteLine(question.Ttitle);
            //    foreach (var answer in question.Answers)
            //    {
            //        Console.WriteLine(answer.Title);
            //    }
            //}

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(
                option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
            services.AddTransient<IJsonImportService, JsonImportService>();
        }

    }
}
