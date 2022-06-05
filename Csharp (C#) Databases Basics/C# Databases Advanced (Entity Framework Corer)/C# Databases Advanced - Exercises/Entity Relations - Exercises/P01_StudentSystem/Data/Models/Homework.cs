namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using P01_StudentSystem.Data.Models.Enums;

    public class Homework
    {
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
