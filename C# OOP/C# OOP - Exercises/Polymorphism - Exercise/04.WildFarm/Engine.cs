
namespace WildFarm
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Engine : IEngine
    {
        private ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        public Engine()
        {
            animals = new HashSet<Animal>();
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string animalInfo;
            while ((animalInfo = Console.ReadLine()) != "End")
            {
                string foodInfo = Console.ReadLine();
                string[] animalTokens = animalInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string[] argS = animalTokens
                    .Skip(3).ToArray();
                Animal animal = null;

                try
                {
                    animal = animalFactory.Create(animalTokens[0], animalTokens[1], double.Parse(animalTokens[2]), argS);
                    animals.Add(animal);

                    Console.WriteLine(animal.ProduceSoundSForFood());
                }
                catch (InvalidOperationException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }

                string[] foodTokens = foodInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Food food = foodFactory.CreateFood(foodTokens[0], int.Parse(foodTokens[1]));

                    if (animal != null)
                    {
                        animal.Feed(food);
                    }

                }
                catch (InvalidOperationException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }
            }

            foreach (Animal animall in animals)
            {
                Console.WriteLine(animall);
            }
        }
    }
}
