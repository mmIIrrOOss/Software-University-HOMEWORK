namespace _04.Wild_Farm.Models.Animal.Bird
{
    using System;
    using ExceptionMessages;

    public class Owl : Bird
    {
        private const double Increase_Weight = 0.25;

        public Owl(string name, double weight, double foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {

        }

        public override void ProduceSound(string typeFood)
        {
            Console.WriteLine("Hoot Hoot");
            if (typeFood == "Meat")
            {
                if (this.FoodEaten == 1)
                {
                    this.FoodEaten = 0;
                }
                this.Weight += this.FoodEaten * Increase_Weight;
            }
            else
            {
                if (this.FoodEaten == 1)
                {
                    this.FoodEaten = 0;
                }
                Console.WriteLine(string.Format(ExceptionMessages.InvalidFood, this.GetType().Name, typeFood));
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
