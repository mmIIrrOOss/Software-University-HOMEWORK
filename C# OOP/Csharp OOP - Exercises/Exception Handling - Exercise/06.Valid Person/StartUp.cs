namespace _06.Valid_Person
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {

            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Person person = new Person(firstName,lastName,age);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("Exception thrown: {0}", ae.Message);
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine("Exception thrown: {0}", ae.Message);
            }

        }
    }
}
