using System.Collections.Generic;

namespace Quiz.Models
{
    public class Qestion
    {
        public Qestion()
        {
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}