namespace _07.Custom_Exception.Models
{
    using System;
    using System.Linq;

    using Exceptions;

    public class Student
    {
        private string name;
        private string email;

        public Student(string name,string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Any(x=>char.IsSymbol(x)||char.IsDigit(x)))
                {
                    throw new InvalidPersonNameException();
                }
                this.name = value;
            }
        }

        public string Email
        {
            get => this.email;
            private set
            {
                this.email = value;
            }
        }
    }
}
