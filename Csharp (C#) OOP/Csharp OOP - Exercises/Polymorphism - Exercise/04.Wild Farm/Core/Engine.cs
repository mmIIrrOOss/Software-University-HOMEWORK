namespace _04.Wild_Farm.Core
{
    using System;
    using Contracts;
    using Models.Constrains;
    using Models.Animal.Bird;
    using Models.Animal.Mammal.Feline;
    using Models.Animal.Mammal;
    using System.Text;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private Mouse mouse;
        private Dog dog;
        private Cat cat;
        private Tiger tiger;
        private Hen hen;
        private Owl owl;

        public void Run()
        {
            List<string> printAnimals = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] argsAnimal = command.Split();
                string[] infoFood = Console.ReadLine().Split();

                string typeAnimal = argsAnimal[0];
                string typeFood = infoFood[0];

                this.CreateAnimal(argsAnimal, infoFood, typeAnimal);
                this.ProducingSound(typeAnimal, typeFood);
                printAnimals.Add(this.OverridingTostring(typeAnimal));
            }

            printAnimals.ForEach(x => Console.WriteLine(x));
        }

        private void CreateAnimal(string[] argsAnimal, string[] infoFood, string typeAnimal)
        {
            string typeFood = infoFood[0];

            if (typeAnimal == "Owl")
            {

                this.owl = (Owl)CreateBirds(argsAnimal, infoFood);
            }
            else if (typeAnimal == "Hen")
            {
                this.hen = (Hen)CreateBirds(argsAnimal, infoFood);
            }
            else if (typeAnimal == "Mouse")
            {
                this.mouse = (Mouse)CreateMammal(argsAnimal, infoFood);
            }
            else if (typeAnimal == "Dog")
            {
                this.dog = (Dog)CreateMammal(argsAnimal, infoFood);
            }
            else if (typeAnimal == "Cat")
            {
                this.cat = (Cat)CreateFelines(argsAnimal, infoFood);
            }
            else if (typeAnimal == "Tiger")
            {
                this.tiger = (Tiger)CreateFelines(argsAnimal, infoFood);
            }
        }

        private IFeline CreateFelines(string[] argsAnimal, string[] infoFood)
        {
            string typeAnimal = argsAnimal[0];
            string name = argsAnimal[1];
            double weight = double.Parse(argsAnimal[2]);
            string livingRegion = argsAnimal[3];
            string breed = argsAnimal[4];

            int quantityFood = int.Parse(infoFood[1]);
            IFeline feline = null;
            if (typeAnimal == "Cat")
            {
                feline = new Cat(name, weight, quantityFood, livingRegion, breed);
                return feline;
            }
            else if (typeAnimal == "Tiger")
            {

                feline = new Tiger(name, weight, quantityFood, livingRegion, breed);
                return feline;
            }
            return feline;
        }

        private IBird CreateBirds(string[] argsAnimal, string[] infoFood)
        {
            string typeAnimal = argsAnimal[0];
            string name = argsAnimal[1];
            double weight = double.Parse(argsAnimal[2]);
            double wingSize = double.Parse(argsAnimal[3]);

            int foodEaten = int.Parse(infoFood[1]);
            IBird bird = null;
            if (typeAnimal == "Owl")
            {
                bird = new Owl(name, weight, foodEaten, wingSize);
                return bird;
            }
            else if (typeAnimal == "Hen")
            {
                bird = new Hen(name, weight, foodEaten, wingSize);
                return bird;
            }

            return bird;
        }

        private IMammal CreateMammal(string[] argsAnimal, string[] infoFood)
        {
            string animalType = argsAnimal[0];
            string name = argsAnimal[1];
            double weight = double.Parse(argsAnimal[2]);
            string livingRegion = argsAnimal[3];

            int quantityFood = int.Parse(infoFood[1]);

            IMammal mammal = null;
            if (animalType == "Dog")
            {
                mammal = new Dog(name, weight, quantityFood, livingRegion);
            }
            else if (animalType == "Mouse")
            {
                mammal = new Mouse(name, weight, quantityFood, livingRegion);
            }
            return mammal;
        }

        private void ProducingSound(string typeAnimal, string typeFood)
        {
            if (typeAnimal == "Owl")
            {
                this.owl.ProduceSound(typeFood);
            }
            else if (typeAnimal == "Hen")
            {
                this.hen.ProduceSound(typeFood);
            }
            else if (typeAnimal == "Mouse")
            {
                this.mouse.ProduceSound(typeFood);
            }
            else if (typeAnimal == "Dog")
            {
                this.dog.ProduceSound(typeFood);
            }
            else if (typeAnimal == "Cat")
            {
                this.cat.ProduceSound(typeFood);
            }
            else if (typeAnimal == "Tiger")
            {
                this.tiger.ProduceSound(typeFood);
            }
        }

        private string OverridingTostring(string typeAnimal)
        {
            StringBuilder sb = new StringBuilder();
            if (typeAnimal == "Owl")
            {
                sb.AppendLine(this.owl.ToString());
            }
            else if (typeAnimal == "Hen")
            {
                sb.AppendLine(this.hen.ToString());
            }
            else if (typeAnimal == "Mouse")
            {
                sb.AppendLine(this.mouse.ToString());
            }
            else if (typeAnimal == "Dog")
            {
                sb.AppendLine(this.dog.ToString());
            }
            else if (typeAnimal == "Cat")
            {
                sb.AppendLine(this.cat.ToString());
            }
            else if (typeAnimal == "Tiger")
            {
                sb.AppendLine(this.tiger.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
