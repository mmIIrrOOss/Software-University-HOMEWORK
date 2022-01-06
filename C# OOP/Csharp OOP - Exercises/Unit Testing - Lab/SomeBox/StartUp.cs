namespace SomeBox
{
    using EgnHelper;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            ValidateFromUser(new EgnValidator());
        }
        public static void ValidateFromUser(IEgnValidator egnValidator)
        {
            string egn = Console.ReadLine();
            Console.WriteLine("Valid: " + egnValidator.IsValid(egn));
        }
    }
}
