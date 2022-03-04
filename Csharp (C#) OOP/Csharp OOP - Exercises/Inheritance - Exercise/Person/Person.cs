namespace Person
{
    using System;
    using System.Text;
    public class Person
    {
        private string name;
        private int age;


        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.name}, Age: {this.age}");
            return sb.ToString().TrimEnd();
        }
    }
}
