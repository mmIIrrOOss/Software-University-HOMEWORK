namespace _04.Wild_Farm.Models.Animal.Mammal.Feline
{
    using System;
    using ExceptionMessages;

    public class Tiger : Feline
    {
        private const double Increase_Weight = 1.00;

        public Tiger(string name, double weight, double foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {

        }

        public override void ProduceSound(string typeFood)
        {
            Console.WriteLine("ROAR!!!");
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
