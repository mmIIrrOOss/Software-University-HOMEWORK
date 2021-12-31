namespace _04.Wild_Farm.Models.Animal.Mammal
{
    using System;
    using ExceptionMessages;

    public class Dog : Mammal
    {
        private const double Increase_Weight = 0.40;

        public Dog(string name, double weight, double foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {

        }

        public override void ProduceSound(string typeFood)
        {
            Console.WriteLine("Woof!");
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
                
                    this.FoodEaten = 0;
              
                Console.WriteLine(string.Format(ExceptionMessages.InvalidFood, this.GetType().Name, typeFood));
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
