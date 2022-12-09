using System;
using System.Collections.Generic;

namespace Quiz.Models
{
    public class Quiz
    {
        public Quiz()
        {
            this.Questions = new HashSet<Question>();
            this.UserAnswer = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<UserAnswer> UserAnswer { get; set; }
    }
}
