namespace StudentSystem.Models
{
    using System.Collections.Generic;


    public class StudentsData
    {
        private Dictionary<string, Student> infoStudent;

        public StudentsData()
        {
            this.infoStudent = new Dictionary<string, Student>();
        }
        public void Add(string name, int age, double grade)
        {
            if (!this.infoStudent.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.infoStudent[name] = student;
            }
        }
        public Student Find(string name)
        {
            if (this.infoStudent.ContainsKey(name))
            {
                return this.infoStudent[name];
            }
            return null;
        }
    }
}
