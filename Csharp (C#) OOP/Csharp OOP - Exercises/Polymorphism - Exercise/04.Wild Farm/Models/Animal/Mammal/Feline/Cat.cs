namespace _04.Wild_Farm.Models.Animal.Mammal.Feline
{
    using System;
    using ExceptionMessages;

    public class Cat : Feline
    {
        private const double Increase_Weight = 0.30;

        public Cat(string name, double weight, double foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {

        }

        public override void ProduceSound(string typeFood)
        {
            Console.WriteLine("Meow");
            if (typeFood == "Meat" || typeFood == "Vegetable")
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
