namespace Animals
{
    using System;
    using Animals.Models;
    using Animals.Models.Animals;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Sharo", "Whiskas");
            Animal dog = new Dog("Betoven", "Granuli");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
