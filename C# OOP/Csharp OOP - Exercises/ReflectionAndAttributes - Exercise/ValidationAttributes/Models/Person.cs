namespace ValidationAttributes.Models
{

    using Attributes;

    public class Person
    {
        private const int MIn_Age = 12;
        private const int Max_Age = 90;

        public Person(string fullName,int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRiquired]

        public string FullName { get; set; }

        [MyRange(MIn_Age,Max_Age)]
        public int Age { get; set; }
    }
}
