namespace Animals.Models
{
    using System;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public virtual string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }
        public virtual string ProduceSound()
        {
            return null;
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(GetType().Name)
                .AppendLine($"{name} {age} {gender.ToString()}")
                .Append($"{ProduceSound()}");

            return builder.ToString();
        }
    }
}
