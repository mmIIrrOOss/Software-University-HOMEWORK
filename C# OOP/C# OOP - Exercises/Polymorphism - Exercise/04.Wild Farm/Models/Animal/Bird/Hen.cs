namespace _04.Wild_Farm.Models.Animal.Bird
{
    public class Hen : Bird
    {
        private const double Increase_Weight = 0.35;

        public Hen(string name, double weight, double foodEaten,double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
           
        }

        public override void ProduceSound(string typeFood)
        {
            System.Console.WriteLine("Cluck");
            if (this.FoodEaten == 1)
            {
                this.FoodEaten = 0;
            }
            this.Weight += this.FoodEaten * Increase_Weight;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
