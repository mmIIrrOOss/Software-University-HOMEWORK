namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ////Entity: Course
            //modelBuilder.Entity<Course>()
            //    .Property(x => x.Price)
            //    .IsUnicode(true);

            //modelBuilder.Entity<Course>()
            //    .Property(x => x.Description)
            //    .IsUnicode(true)
            //    .IsRequired(false);


            ////Entity: Homework

            //modelBuilder.Entity<Homework>()
            //    .Property(x => x.Content)
            //    .IsUnicode(false);

            ////Entity: Resource

            //modelBuilder.Entity<Resource>()
            //    .Property(x => x.Name)
            //    .IsUnicode(true);
            //modelBuilder.Entity<Resource>()
            //    .Property(x => x.Url)
            //    .IsUnicode(false);

            ////Entity: Student
            //modelBuilder.Entity<Student>()
            //    .Property(x => x.Name)
            //    .IsUnicode(true);

            //modelBuilder.Entity<Student>()
            //    .Property(x => x.PhoneNumber)
            //    .IsUnicode(false)
            //    .IsRequired(false);

            //modelBuilder.Entity<Student>()
            //    .Property(x => x.Birthday)
            //    .IsRequired(false);

            ////Entity: StudentCourse
            modelBuilder.Entity<StudentCourse>(x =>
            {
                x.HasKey(x => new { x.CourseId, x.StudentId });
            });

           

            base.OnModelCreating(modelBuilder);
        }



    }
}
