namespace StudentSystem.Models
{
    using System.Text;

    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
        public double Grade { get; private set; }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} is {this.Age} years old. ");

            if (this.Grade >= 5.00)
            {
                sb.Append("Excellent student.");
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                sb.Append("Average student.");
            }
            else
            {
                sb.Append("Very nice person.");
            }
            return sb.ToString().TrimEnd();
        }

    }
}