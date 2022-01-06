
namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Person
    {
        private string name;
        private string lastName;
        private int age;
        public Person(string name,string lastName,int age)
        {
            this.FirstName = name;
            this.LastName = lastName;
            this.Age = age;
        }
        public string FirstName
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
