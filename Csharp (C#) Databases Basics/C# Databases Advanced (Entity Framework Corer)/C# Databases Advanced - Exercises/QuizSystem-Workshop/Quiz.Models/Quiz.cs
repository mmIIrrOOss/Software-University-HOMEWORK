using System;
using System.Collections.Generic;

namespace Quiz.Models
{
    public class Quiz
    {
        public Quiz()
        {
            this.Qestions = new HashSet<Qestion>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Qestion> Qestions { get; set; }
    }
}
