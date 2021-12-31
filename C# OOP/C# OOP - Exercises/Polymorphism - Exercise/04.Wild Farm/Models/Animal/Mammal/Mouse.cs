namespace _04.Wild_Farm.Models.Animal.Mammal
{
    using System;
    using ExceptionMessages;

    public class Mouse : Mammal
    {
        private const double Increase_Weight = 0.10;

        public Mouse(string name, double weight, double foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {

        }

        public override void ProduceSound(string typeFood)
        {
            System.Console.WriteLine("Squeak");
            if (typeFood == "Fruit" || typeFood == "Vegetable")
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
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
