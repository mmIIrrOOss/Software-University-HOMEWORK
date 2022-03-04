
namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string name, string lastName, int age, decimal salary)
        {
            this.FirstName = name;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public decimal Salary
        {
            get => this.salary;
            set
            {
                this.salary = value;
            }
        }
        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
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
        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += this.Salary * (percentage / 200);
            }
            else
            {
                this.Salary += this.Salary * (percentage/100);
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
