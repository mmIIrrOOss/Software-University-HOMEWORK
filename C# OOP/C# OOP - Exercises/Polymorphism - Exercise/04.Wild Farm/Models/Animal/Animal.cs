namespace _04.Wild_Farm.Models.Animal
{
    using Models.Constrains;

    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight, double foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public virtual string Name { get; set; }

        public virtual double Weight { get; set; }

        public virtual double FoodEaten { get; set; }

        public virtual void ProduceSound(string typeFood)
        {

        }
    }
}
