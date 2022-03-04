namespace ValidationAttributes
{
    using System;
    using ValidationAttributes.Models;
    using ValidationAttributes.Utilites;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Miro AtANASOV",
                 29
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
            var personTwo = new Person
             (
                null,
                 -1
             );

            bool isValidEntityTwo = Validator.IsValid(personTwo);

            Console.WriteLine(isValidEntityTwo);
        }
    }
}
